using gearzone.businesslogic.Structure;
using gearzone.dataaccess.Data;
using gearzone.domains.DTOs;
using gearzone.domains.Entities;

namespace gearzone.businesslogic.Core.Auth;

public class RegisterActions
{
    internal ResponceAction RegisterUserExecution(UserRegisterDto uReg)
    {
        if (string.IsNullOrEmpty(uReg.Username) ||
            string.IsNullOrEmpty(uReg.Password) ||
            string.IsNullOrEmpty(uReg.Email))
        {
            return new ResponceAction
            {
                IsSuccess = false,
                Message = "Username, Password and Email are required."
            };
        }

        using (var db = new UserContext())
        {
            var existing = db.Users.FirstOrDefault(
                u => u.Email == uReg.Email || u.Username == uReg.Username);

            if (existing != null)
            {
                return new ResponceAction
                {
                    IsSuccess = false,
                    Message = "Email or username already exists."
                };
            }

            var user = new User
            {
                Username = uReg.Username,
                Password = PasswordHasher.Hash(uReg.Password),
                Email = uReg.Email,
                Role = UserRole.User
            };

            db.Users.Add(user);
            db.SaveChanges();

            return new ResponceAction
            {
                IsSuccess = true,
                Message = "User registration successful.",
                Id = user.Id
            };
        }
    }
}
