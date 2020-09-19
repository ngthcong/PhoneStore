using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models
{
    public class PageinatedList<T> :List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public PageinatedList(List<T> items, int count , int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages =  (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }
        public bool HasPreviosPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        public static  PageinatedList<T> CreateAsync (IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count =  source.Count();
            var items =  source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PageinatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
