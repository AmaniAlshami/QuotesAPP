using System;
namespace QuotesAPP.BI
{
	public record QuoteDTO
	(int id, string Text, string Author, string AuthorId, DateTime CreateAt);
}

