namespace Trading.Infrastucture.Data.Repositories
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Trading.Domain.Entities;

	public class UserRepository : Repository<User, DataContext>
	{
		private readonly DataContext _context;

		public UserRepository(DataContext context) : base(context)
		{
			_context = context;
		}
	}
}
