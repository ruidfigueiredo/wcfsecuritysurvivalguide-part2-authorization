using System.Collections.Generic;

namespace WCFSecuritySurvivalGuidePart2.Services
{
    public class UserInformation
    {
        public string UserName { get; set; }
        public IEnumerable<string> Roles { get; set; }        
    }

}
