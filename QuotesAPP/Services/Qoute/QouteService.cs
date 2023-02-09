using System;
using QuotesAPP.DAL;

namespace QuotesAPP.Services
{
	public class QuoteService : IQuoteService
	{
		private UnitOfWork unitOfWork = new UnitOfWork();


		public IEnumerable<Quote> GetQuotes()
		{
			return unitOfWork.QuoteRepository.GetAll()
				.OrderByDescending(x => x.CreatedAt);
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

		public Quote GetRandomQuote()
		{
			Random random = new Random();
			int randomId = random.Next(10);
			return unitOfWork.QuoteRepository.GetById(randomId);
		}

		public IEnumerable<Quote> GetQuotesByAuthor(int authorId)
		{
			return unitOfWork.QuoteRepository.GetAll(x=> x.AuthorId == authorId)
				.OrderByDescending(x=> x.CreatedAt);
		}
	}
}

