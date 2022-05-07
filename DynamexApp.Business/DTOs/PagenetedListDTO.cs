using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.DTOs
{
    public class PagenetedListDTO<T>
    {
        public PagenetedListDTO(IEnumerable<T> items,int pageIndex,int totalCount, int pageSize)
        {
            Items = items;
            PageSize = pageSize;
            TotalPage = (int)Math.Ceiling(totalCount / (double)pageSize);
            HasNext = pageIndex < TotalPage;
            HasPrev = pageIndex>1;

        }
        public IEnumerable<T> Items { get; }
        public int PageSize { get; }
        public int TotalPage { get; }
        public bool HasNext { get; }
        public bool HasPrev { get; }

    }
}
