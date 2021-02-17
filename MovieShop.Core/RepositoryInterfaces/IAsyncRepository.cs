using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieShop.Core.RepositoryInterfaces
{
    // Generic constraints
    public interface IAsyncRepository<T> where T : class
    {
        // CRUD
        
        // Reading
        T GetByIdAsync(int id);

        IEnumerable<T> ListAllAsync();

        // LINQ, list of movies on some where condition where m.title = "Avenger", m.revenue > 100000
        IEnumerable<T> ListAsync(Expression<Func<T, bool>> filter);

        int GetCountAsync(Expression<Func<T, bool>> filter=null);

        bool GetExistsAsync(Expression<Func<T, bool>> filter=null);

        // C Creating
        T AddAsync(T entity);

        // U Update
        T UpdateAsync(T entity);

        // D Delete
        T DeleteAsync(T entity);
    }
}
