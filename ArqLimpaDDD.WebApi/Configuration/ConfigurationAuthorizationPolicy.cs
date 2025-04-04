using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ArqLimpaDDD.WebApi.Configuration
{
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimType, string claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { claimType, claimValue };
        }
    }

    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        private readonly string _claimType;
        private readonly string _claimValue;
        public ClaimRequirementFilter(string claimType, string claimValue)
        {
            _claimType = claimType;
            _claimValue = claimValue;
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (user == null || !user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!user.HasClaim(c => c.Type == _claimType && c.Value == _claimValue))
            {
                context.Result = new ForbidResult();
            }
        }
    }

    public static class ClaimsTypes
    {
        public const string Categoria = nameof(Categoria);
        public const string Vendas = nameof(Vendas);
        public const string Analista = nameof(Analista);
        public const string UserRole = nameof(UserRole);
        public const string UserPermission = nameof(UserPermission);
    }

        public static class PolicyConstants 
        {
            public const string RoleVendas = "Vendas";
            public const string RoleGerente = "Gerente";
            public const string RoleVendedor = "Vendedor";
            public const string RoleAdministrador = "Administrador";
        }
}
