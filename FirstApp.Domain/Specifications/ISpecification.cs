using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FirstApp.Domain.Specifications
{
    public interface ISpecification<T>
    {
        // Критерий, допустим Products.Where(p => p.productBrandId == 1)
        Expression<Func<T, bool>> Criteria { get; }
        // лист инклюдов. T - текущий элемент, object - какой содержит
        List<Expression<Func<T, object>>> Includes { get; }
    }
}
