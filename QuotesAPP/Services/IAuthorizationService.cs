using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using QuotesAPP.BI;
namespace QuotesAPP.Services
{
    public interface IAuthorizationService
    {
        public Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user);
        public Task<AuthorizationResult> AuthorizeUserQuoteAction(ClaimsPrincipal user, QuoteDTO model);

    }
}