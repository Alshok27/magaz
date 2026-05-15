using gearzone.businesslogic.Structure;
using gearzone.dataaccess.Data;
using gearzone.domains.DTOs;
using gearzone.domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace gearzone.businesslogic.Core.Auth;

public class AuthActions
{
    internal User? ValidateLoginExecution(UserAuthDto data)
    {
        if (string.IsNullOrEmpty(data.Login) || string.IsNullOrEmpty(data.Password))
            return null;

        var passwordHash = PasswordHasher.Hash(data.Password);

        using (var db = new UserContext())
        {
            return db.Users.FirstOrDefault(
                u => (u.Username == data.Login || u.Email == data.Login)
                     && u.Password == passwordHash);
        }
    }

    internal string GenerateUserToken(User user)
    {
        var token = new TokenService();
        return token.GenerateToken(user.Id, user.Username, user.Role.ToString());
    }
}
