using Microsoft.AspNetCore.Authorization;

namespace eBlocks.Assessment.WebAPI.Extensions 
{
    internal class EblocksApiRequirement : IAuthorizationRequirement 
    {
        public EblocksApiRequirement()

        {
        }
    }
}