using Microsoft.AspNetCore.Mvc;
using QuotesAPP.BI;
using QuotesAPP.DAL;
using QuotesAPP.Services;

namespace QuotesAPP.WebAPI;

[ApiController]
[Route("api/[controller]")]
public class QouteController : Controller
{
    private readonly IQuoteService QouteService;

    public QouteController(IQuoteService QouteService)
    {
        this.QouteService = QouteService;
    }

    [HttpPost]
    public void AddQuote(Quote quote)
    {
        QouteService.AddQuote(quote);
    }

    [HttpGet("list")]
    public IEnumerable<QuoteDTO> GetQuotes()
    {
        return QouteService.GetQuotes();
    }

    [HttpGet("random")]
    public QuoteDTO GetRandomQuote()
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

