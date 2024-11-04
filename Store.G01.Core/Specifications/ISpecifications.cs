﻿using Store.G01.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Core.Specifications
{
	public interface ISpecifications <TEntity,TKey> where TEntity : BaseEntity< TKey>
	{
        public Expression<Func<TEntity,bool>> Criteria { get; set; }
        public List<Expression<Func<TEntity,object>>> Include { get; set; }

        public Expression<Func<TEntity,object>> OrderBy { get; set; }
        public Expression<Func<TEntity,object>> OrderByDesc { get; set; }

    }
}
