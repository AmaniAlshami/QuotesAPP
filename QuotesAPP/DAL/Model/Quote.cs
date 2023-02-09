using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuotesAPP.DAL
{
	[Table("Quotes")]
	public class Quote
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		public string Text { get; set; }
		[Required]
		public DateTime CreatedAt { get; set; }

		[ForeignKey("Author")]
		public int AuthorId { get; set; }

	}
}

