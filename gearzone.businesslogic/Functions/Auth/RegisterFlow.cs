using gearzone.businesslogic.Core.Auth;
using gearzone.businesslogic.Interface;
using gearzone.domains.DTOs;

namespace gearzone.businesslogic.Functions.Auth;

public class RegisterFlow : RegisterActions, IRegisterActions
{
    public ResponceAction RegisterActionFlow(UserRegisterDto uReg)
    {
        return RegisterUserExecution(uReg);
    }
}
