using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAccess.Data;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWorkRepository
	{
		private ApplicationDbContext _db;
		public ICategoryRepository Category { get; private set; }	

		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Category = new CategoryRepository(_db);
		}

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}