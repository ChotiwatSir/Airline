using ToToAirline.DTOs.SecurityCheck;

namespace ToToAirline.IService
{
    public interface ISecurityCheckService
    {
        public GetSecurityCheckDto GetSecurityCheck(Guid passengerId);
        public void CreateSecurityCheck(CreateSecurityCheckDto create);
    }
}