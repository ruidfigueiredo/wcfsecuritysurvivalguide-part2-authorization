using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading;

namespace WCFSecuritySurvivalGuidePart2.Services
{
    public class UserInformationService : IUserInformationService
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public UserInformation GetUserInfo()
        {
            var claimsIdentity = Thread.CurrentPrincipal as System.Security.Claims.ClaimsPrincipal;
            IEnumerable<string> roles = Enumerable.Empty<string>();
            if (claimsIdentity != null)
            {
                roles = claimsIdentity.FindAll(System.Security.Claims.ClaimTypes.Role).Select(c => c.Value);
            }
            var userName = Thread.CurrentPrincipal.Identity.Name;

            return new UserInformation
            {
                UserName = claimsIdentity.Identity.Name,
                Roles = roles
            };
        }
    }

}
