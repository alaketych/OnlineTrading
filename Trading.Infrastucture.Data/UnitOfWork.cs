namespace Trading.Infrastucture.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private readonly DataContext _context;

		public UnitOfWork(DataContext context)
		{
			_context = context;
		}

		public void Commit()
		{
			_context.SaveChanges();
		}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
    }
}
