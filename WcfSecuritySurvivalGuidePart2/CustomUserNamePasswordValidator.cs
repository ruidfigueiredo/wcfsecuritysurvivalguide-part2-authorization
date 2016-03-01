using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace WcfSecuritySurvivalGuidePart2
{
    public class CustomUserNamePasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName != "johndoe" && password != "P@ssw0rd")
                throw new FaultException("Wrong username/password combination");
        }
    }
}