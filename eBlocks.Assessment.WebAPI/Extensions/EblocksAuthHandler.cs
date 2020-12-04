using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eBlocks.Assessment.WebAPI.Extensions
{
    internal class EblocksAuthHandler : AuthorizationHandler<EblocksApiRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
               EblocksApiRequirement requirement)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (requirement == null)
                throw new ArgumentNullException(nameof(requirement));

            var clientId = context.User.Claims
                .FirstOrDefault(t => t.Type == "client_id");
            var scope = context.User.Claims
                .FirstOrDefault(t => t.Type == "scope");

            if (AccessTokenValid(clientId, scope))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }


        private bool AccessTokenValid(Claim clientId, Claim scope)
        {
            if (clientId != null && clientId.Value == "CC_STS_ZA")
                return ValidateScopeZa(scope, clientId);

            if (clientId != null && clientId.Value == "CC_STS_ROW")
                return ValidateScopeRow(scope, clientId);

            return false;
        }

        private bool ValidateScopeZa(Claim scope, Claim clientId)
        {
            if (scope != null && scope.Value == "scopeZa")
            {
                return true;
            }

            return false;
        }

        private bool ValidateScopeRow(Claim scope, Claim clientId)
        {
            if (scope != null && scope.Value == "scopeRow")
            {
                return true;
            }

            return false;
        }
    }
}