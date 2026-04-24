using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Domain.ValueObject
{
    public class PaginationResult<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }  
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < PageCount;
        public PaginationResult(int totalItems, int pageNumber, int pageSize, IEnumerable<T> items)
        {
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Items = items;
            PageCount = (int)Math.Ceiling(totalItems / (double)pageSize);
        }
    }
}
