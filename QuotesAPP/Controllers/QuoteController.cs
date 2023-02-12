using Microsoft.AspNetCore.Mvc;
using QuotesAPP.DAL;
using QuotesAPP.Services;

namespace QuotesAPP.Controllers;

[ApiController]
[Route("[controller]")]
public class QouteController : ControllerBase
{
    private readonly IQuoteService QouteService;

    public QouteController()
    {
    }

    [HttpPost]
    public void AddQuote(Quote quote)
    {
        QouteService.AddQuote(quote);
    }

    [HttpGet("List")]
    public IEnumerable<Quote> GetQuotes()
    {
        return QouteService.GetQuotes();
    }
    [HttpGet("authorId")]
    public IEnumerable<Quote> GetQuotesByAuthor(int authorId)
    {
        return QouteService.GetQuotesByAuthor(authorId);
    }
    [HttpGet("random")]
    public Quote GetRandomQuote()
    {
        return QouteService.GetRandomQuote();
    }

    [HttpDelete]
    public void DeleteQuote(int id)
    {
        QouteService.DeleteQuote(id);
    }

    [HttpPut]
    public void UpdateQuote(Quote quote)
    {
        QouteService.UpdateQuote(quote);
    }

}

