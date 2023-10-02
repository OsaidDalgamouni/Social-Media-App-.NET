using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ModelContext _db;
        internal DbSet<T> dbset;

        public Repository(ModelContext db)
        {
            _db = db;
            this.dbset = _db.Set<T>();
        }

        public void add(T item)
        {
            dbset.Add(item);
        }

        public IEnumerable<T> GetAll(string? Includeproperities = null)
        {
            IQueryable<T> query = dbset;
            if (Includeproperities != null)
            {
                foreach (var properity in Includeproperities.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(properity);

                }
            }
            return query;
        }

        public T GetFirstOrDefualt(Expression<Func<T, bool>> filter,string? includeproperty=null)
        {
            IQueryable<T> query = dbset;
            
            query = query.Where(filter);
            if(includeproperty != null)
            {
                foreach (var prp in includeproperty.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query=query.Include(prp);
                }
            }
            query.AsTracking();
            return query.FirstOrDefault();
        }
        

        public void Remove(T item)
        {
            dbset.Remove(item);
        }

        public void Update(T item)
        {
            dbset.Update(item);

        }
    }
}
