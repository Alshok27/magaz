using gearzone.businesslogic.Functions.Auth;
using gearzone.businesslogic.Interface;

namespace gearzone.businesslogic;

public class BusinessLogic
{
    public BusinessLogic() { }

    public IAuthActions GetAuthActions()
    {
        return new AuthFlow();
    }

    public IRegisterActions GetRegisterActions()
    {
        return new RegisterFlow();
    }
}
