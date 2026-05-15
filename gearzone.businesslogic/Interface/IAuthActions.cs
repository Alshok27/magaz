using gearzone.domains.DTOs;

namespace gearzone.businesslogic.Interface;

public interface IAuthActions
{
    ResponceAction LoginActionFlow(UserAuthDto auth);
}
