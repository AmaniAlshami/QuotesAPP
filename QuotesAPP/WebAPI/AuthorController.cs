using Microsoft.AspNetCore.Mvc;
using QuotesAPP.DAL;
using QuotesAPP.Services;

namespace QuotesAPP.WebAPI;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : Controller
{
    private readonly IAuthorService auotherService;
    private readonly IQuoteService qouteService;

    public AuthorController(IAuthorService auotherService, IQuoteService qouteService)
    {
        this.auotherService = auotherService;
        this.qouteService = qouteService;
    }

    [HttpPost]
    public void AddAuthor(Author author)
    {
        auotherService.AddAuthor(author);
    }

    [HttpGet("list")]
    public IEnumerable<Author> GetAuthors()
    {
        return auotherService.GetAuthors();
    }

    [HttpDelete]
    public void DeleteAuthor(int id)
    {
         auotherService.DeleteAuthor(id);
    }

    [HttpPut]
    public void UpdateAuthor(Author author)
    {
        auotherService.UpdateAuthor(author);
    }

    [HttpGet("{authorId}/quotes")]
    public IEnumerable<Quote> GetQuotesByAuthor(int authorId)
    {
        return qouteService.GetQuotesByAuthor(authorId);
    }
}

