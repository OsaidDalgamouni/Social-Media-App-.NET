using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IService<T>where T : class
    {
       IEnumerable<T> GetAll(string? Includeproperities = null);
        T GetbyId(Expression<Func<T, bool>> filter, string? Includeproperities = null);
        void add(T item);
        void Remove(T item);
        void update(T item);    
        
    }
}
