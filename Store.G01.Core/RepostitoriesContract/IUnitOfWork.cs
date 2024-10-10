using Store.G01.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Core.RepostitoriesContract
{
     public interface IUnitOfWork
    {
        Task<int> CompleteAsync();

        // create Repositores<T> and Return

        IGenericRepository<TEntity,TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;



    }
}
