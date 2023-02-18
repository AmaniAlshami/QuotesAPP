using System;
using QuotesAPP.BI;
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
			author.CreatedAt = DateTime.Now;
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

		public Author GetAuthorById(int id)
		{
			return unitOfWork.AuthorRepository.GetById(id);
		}

		public bool AuthorExists(int id)
		{
			return unitOfWork.AuthorRepository.GetById(id) != null;
		}

		public Author AuthorLogin(Login model)
		{
			return unitOfWork.AuthorRepository.GetAll(x => x.Email == model.Email
			&& x.Password == model.Password).FirstOrDefault();
		}
	}
}

