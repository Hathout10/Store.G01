using Microsoft.EntityFrameworkCore;
using Store.G01.Core.Entites;
using Store.G01.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Repository
{
	public static class SpecificationEvaluator<TEntity , TKey> where TEntity : BaseEntity<TKey>
	{
		public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery , ISpecifications<TEntity, TKey> spec)
		{
			var query = inputQuery;

			if(spec.Criteria != null)
			{
				query=query.Where(spec.Criteria);
			}

			query = spec.Include.Aggregate(query, (current, include) => current.Include(include));

			return query;

		}


	}
}
