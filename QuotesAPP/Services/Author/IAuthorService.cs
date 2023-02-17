using QuotesAPP.DAL;

namespace QuotesAPP.Services;

public interface IAuthorService
{

	public IEnumerable<Author> GetAuthors();

	public void AddAuthor(Author author);

	public void DeleteAuthor(int id);

	public void UpdateAuthor(Author author);

	public Author GetAuthorById(int id);
	public bool AuthorExists(int id);

}
