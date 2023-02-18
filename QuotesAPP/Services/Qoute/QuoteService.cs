using System;
using QuotesAPP.DAL;
using QuotesAPP.BI;

namespace QuotesAPP.Services
{
	public class QuoteService : IQuoteService
	{
		private UnitOfWork unitOfWork = new UnitOfWork();


		public IEnumerable<QuoteDTO> GetQuotes()
		{
			var data = unitOfWork.QuoteRepository.GetAll()
				.OrderByDescending(x => x.CreatedAt);
			var list = new List<QuoteDTO>();
			foreach(var quote in data)
            {
				var authorName = unitOfWork.AuthorRepository.GetById(quote.AuthorId).Name;
				list.Add(new QuoteDTO(quote.Id, quote.Text, authorName, quote.AuthorId.ToString(), quote.CreatedAt));

			}
			return list;
		}

		public void AddQuote(Quote quote)
		{
			unitOfWork.QuoteRepository.Insert(quote);
			unitOfWork.Save();
		}

		public void DeleteQuote(int id)
		{
			unitOfWork.QuoteRepository.Delete(id);
			unitOfWork.Save();
		}

		public void UpdateQuote(Quote quote)
		{
			unitOfWork.QuoteRepository.Update(quote);
			unitOfWork.Save();
		}

		public QuoteDTO GetRandomQuote()
		{
			var quotes = GetQuotes().ToList();
			Random random = new Random();
			int index = random.Next(quotes.Count());
			return quotes[index];
		}

		public IEnumerable<QuoteDTO> GetQuotesByAuthor(int authorId)
		{
			var data = unitOfWork.QuoteRepository.GetAll(x => x.AuthorId == authorId)
				.OrderByDescending(x => x.CreatedAt);
			var list = new List<QuoteDTO>();
			foreach (var quote in data)
			{
				var authorName = unitOfWork.AuthorRepository.GetById(quote.AuthorId).Name;
				list.Add(new QuoteDTO(quote.Id, quote.Text, authorName, quote.AuthorId.ToString(), quote.CreatedAt));

			}
			return list;
		}

		public Quote GetQuoteById(int id)
		{
			return unitOfWork.QuoteRepository.GetById(id);
		}
		public bool QuoteExists(int id)
		{
			return unitOfWork.QuoteRepository.GetById(id) != null;
		}
	}
}

