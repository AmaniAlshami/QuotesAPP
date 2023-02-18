using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using QuotesAPP.BI;
using QuotesAPP.DAL;
using QuotesAPP.Services;

namespace QuotesAPP.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IAuthorService auotherService;

        public AccountController(IAuthorService auotherService)
        {
            this.auotherService = auotherService;

        }
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("Register")]
        public IActionResult Register(Register model)
        {
            var author = new Author
            {
                Name = model.Name,
                Password = model.Password,
                CreatedAt = DateTime.Now,
                Email = model.Email
            };
            auotherService.AddAuthor(author);

            return RedirectToAction(nameof(Login), new Login(model.Email, model.Password));

        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if(claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Quote");
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login model)
        {
            var author = auotherService.AuthorLogin(model);
            if (author != null)
            {
                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.NameIdentifier, author.Id.ToString())
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new()
                {
                    AllowRefresh = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),properties);


                return RedirectToAction("Index", "Quote");
            }
            else
                return RedirectToAction(nameof(Register));

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Quote");
        }
    }
}