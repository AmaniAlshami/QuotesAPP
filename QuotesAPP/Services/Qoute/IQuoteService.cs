using QuotesAPP.DAL;

namespace QuotesAPP.Services;

    public interface IQuoteService
    {
        public IEnumerable<Quote> GetQuotes();

        public void AddQuote(Quote quote);

        public void DeleteQuote(int id);

        public void UpdateQuote(Quote quote);

        public Quote GetRandomQuote();

        public IEnumerable<Quote> GetQuotesByAuthor(int authorId);

    public Quote GetQuoteById(int id);

    public bool QuoteExists(int id);

    }
