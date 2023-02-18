using QuotesAPP.BI;
using QuotesAPP.DAL;

namespace QuotesAPP.Services;

    public interface IQuoteService
    {
        public IEnumerable<QuoteDTO> GetQuotes();

        public void AddQuote(Quote quote);

        public void DeleteQuote(int id);

        public void UpdateQuote(Quote quote);

        public QuoteDTO GetRandomQuote();

    public IEnumerable<QuoteDTO> GetQuotesByAuthor(int authorId);

    public Quote GetQuoteById(int id);

    public bool QuoteExists(int id);

    }
