using gearzone.businesslogic.Core.Auth;
using gearzone.businesslogic.Interface;
using gearzone.domains.DTOs;

namespace gearzone.businesslogic.Functions.Auth;

public class AuthFlow : AuthActions, IAuthActions
{
    public ResponceAction LoginActionFlow(UserAuthDto auth)
    {
        var user = ValidateLoginExecution(auth);
        if (user == null)
        {
            return new ResponceAction
            {
                IsSuccess = false,
                Message = "Invalid username or password."
            };
        }

        var token = GenerateUserToken(user);

        return new ResponceAction
        {
            IsSuccess = true,
            Message = token,
            Id = user.Id
        };
    }
}
