using System;
namespace QuotesAPP.DAL
{
	public class UnitOfWork : IDisposable
	{
		private QuoteContext context = new QuoteContext();
		private GenericRepository<Author> authorRepository;
		private GenericRepository<Quote> quoteRepository;
        private bool disposed = false;


        public GenericRepository<Author> AuthorRepository
        {
            get
            {

                if (authorRepository == null)
                {
                    authorRepository = new GenericRepository<Author>(context);
                }
                return authorRepository;
            }
        }

        public GenericRepository<Quote> QuoteRepository
        {
            get
            {

                if (quoteRepository == null)
                {
                    quoteRepository = new GenericRepository<Quote>(context);
                }
                return quoteRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

