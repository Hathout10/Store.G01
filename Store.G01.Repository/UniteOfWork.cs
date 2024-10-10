using Store.G01.Core.Entites;
using Store.G01.Core.RepostitoriesContract;
using Store.G01.Repository.Data.Contexts;
using Store.G01.Repository.Repositores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Repository
{
	public class UniteOfWork : IUnitOfWork
	{
		private readonly StoreDbContext _context;
		private Hashtable _repositories;

		public UniteOfWork(StoreDbContext context)
        {
			_context = context;
			_repositories = new Hashtable();
		}
        public async Task<int> CompleteAsync() =>	 await _context.SaveChangesAsync();
		

		public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
		{
			var type=typeof(TEntity).Name;
			if(!_repositories.ContainsKey(type))
			{
				var repository = new GenericRepository<TEntity, TKey>(_context);
				_repositories.Add(type, repository);
			}

			return _repositories[type] as IGenericRepository<TEntity, TKey>;

		}
	}
}
