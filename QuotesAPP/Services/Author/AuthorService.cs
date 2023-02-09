using System;
using QuotesAPP.DAL;

namespace QuotesAPP.Services
{
	public class AuthorService : IAuthorService
	{
		private UnitOfWork unitOfWork = new UnitOfWork();

		public IEnumerable<Author> GetAuthors()
		{
			return unitOfWork.AuthorRepository.GetAll();
		}

		public void AddAuthor(Author author)
		{
			unitOfWork.AuthorRepository.Insert(author);
			unitOfWork.Save();
		}

		public void DeleteAuthor(int id)
		{
			unitOfWork.AuthorRepository.Delete(id);
			unitOfWork.Save();
		}

		public void UpdateAuthor(Author author)
		{
			unitOfWork.AuthorRepository.Update(author);
			unitOfWork.Save();
		}
	}
}

