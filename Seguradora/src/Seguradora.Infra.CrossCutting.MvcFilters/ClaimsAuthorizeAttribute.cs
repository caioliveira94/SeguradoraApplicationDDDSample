using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace Seguradora.Infra.CrossCutting.MvcFilters
{
    //Não precisa adicionar esse filtro no FilterConfig, pois esse filtro não é global, só sera chamado quando a action tiver ClaimsAuthorize.
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _claimName;
        private readonly string _claimValue;

        public ClaimsAuthorizeAttribute(string claimName, string claimValue)
        {
            _claimName = claimName;
            _claimValue = claimValue;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var identity = (ClaimsIdentity)httpContext.User.Identity;
            var claim = identity.Claims.FirstOrDefault(c => c.Type == _claimName);

            if(claim != null)
            {
                return claim.Value.Contains(_claimValue);
            }

            return false;
        }
    }
}
