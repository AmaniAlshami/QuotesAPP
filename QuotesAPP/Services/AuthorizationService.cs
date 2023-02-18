using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using QuotesAPP.BI;
namespace QuotesAPP.Services
{
	public class AuthorizationService : IAuthorizationService
	{
		public AuthorizationService()
		{
		}

		public bool Authorize(HttpContext HttpContext)
        {
			ClaimsPrincipal claimUser = HttpContext.User;
			return claimUser.Identity.IsAuthenticated ;

		}

        public async Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user)
        {
             if(user.Identity.IsAuthenticated)
                return AuthorizationResult.Success();
             else
                return AuthorizationResult.Failed();
        }

        public async Task<AuthorizationResult> AuthorizeUserQuoteAction(ClaimsPrincipal user, QuoteDTO model)
        {
            if (user.Identity.IsAuthenticated && model.AuthorId.ToString() == user.Identity.GetUserId())
                return AuthorizationResult.Success();
            else
                return AuthorizationResult.Failed();
        }


    }
}

