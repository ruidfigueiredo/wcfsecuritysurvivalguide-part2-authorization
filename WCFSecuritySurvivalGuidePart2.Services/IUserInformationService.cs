using System.ServiceModel;

namespace WCFSecuritySurvivalGuidePart2.Services
{
    [ServiceContract]
    public interface IUserInformationService
    {
        [OperationContract]
        UserInformation GetUserInfo();
    }
}
