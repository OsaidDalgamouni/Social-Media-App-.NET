using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
         IEnumerable<T> GetAll(string?Includeproperities =null);
        T GetFirstOrDefualt(Expression<Func<T, bool>> filter, string? includeproperty = null);
       void add(T item);
       void Remove(T item);
        void Update(T item);
    }
}
