using Microsoft.AspNetCore.Mvc;
using QuotesAPP.DAL;
using QuotesAPP.Services;

namespace QuotesAPP.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService auotherService;

    public AuthorController(IAuthorService auotherService)
    {
        this.auotherService = auotherService;
    }

    [HttpPost]
    public void AddAuthor(Author author)
    {
        auotherService.AddAuthor(author);
    }

    [HttpGet("List")]
    public IEnumerable<Author> GetAuthors()
    {
        return auotherService.GetAuthors();
    }

}

