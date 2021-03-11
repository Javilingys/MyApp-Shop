using FirstApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstApp.Domain.Specifications
{
    // Проеобразователь входящего query с спецификации в IQueryable. 
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        // На вход подаем ентити asQueryable и спецификацию
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query, (entity, include) => entity.Include(include));

            return query;
        }
    }
}
