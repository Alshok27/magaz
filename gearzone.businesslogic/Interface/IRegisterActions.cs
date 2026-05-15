using gearzone.domains.DTOs;

namespace gearzone.businesslogic.Interface;

public interface IRegisterActions
{
    ResponceAction RegisterActionFlow(UserRegisterDto uReg);
}
