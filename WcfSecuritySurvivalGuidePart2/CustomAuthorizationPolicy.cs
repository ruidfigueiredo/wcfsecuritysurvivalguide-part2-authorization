using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;

namespace WcfSecuritySurvivalGuidePart2
{
    public class CustomAuthorizationPolicy : IAuthorizationPolicy
    {
        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            var identity = (evaluationContext.Properties["Identities"] as List<IIdentity>).Single(i => i.AuthenticationType == "CustomUserNamePasswordValidator");

            var claimsIdentity = new ClaimsIdentity(identity);
            claimsIdentity.AddClaim(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, "Admin"));

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            evaluationContext.Properties["Principal"] = claimsPrincipal;

            Thread.CurrentPrincipal = claimsPrincipal;
            return true;
        }

        public System.IdentityModel.Claims.ClaimSet Issuer
        {
            get { return ClaimSet.System; }
        }

        public string Id
        {
            get { return Guid.NewGuid().ToString(); }
        }
    }
}