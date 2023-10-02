using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class PagedList<T>:List<T>
    {
        public PagedList(IEnumerable<T> items, int total, int pageSize, int pageNumber)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(Count/(double) pageSize);
            PageSize = pageSize;
            TotalCount = total;
            AddRange(items);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize {get; set; }
        public int TotalCount {get; set; }
        public static PagedList<T>Create(IEnumerable<T> source,int pageNumber,int pageSize)
        {
            var count =  source.Count();
            var items = source.Skip((pageNumber -1)*pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageSize, pageNumber);
            

        }
    }
}
