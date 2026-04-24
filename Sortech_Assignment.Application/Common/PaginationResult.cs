using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Application.Common
{
    public class PaginationResult<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }   = Enumerable.Empty<T>();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < PageCount;
        public PaginationResult(int totalItems, int pageNumber, int pageSize)
        {
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
            PageCount = (int)Math.Ceiling(totalItems / (double)pageSize);
        }
    }
}
