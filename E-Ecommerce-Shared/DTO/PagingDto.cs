﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ecommerce_Shared.DTO
{
    public class PagingListDto<T>:List<T>
    {
        public int PageIndex { get; set; } = 1;
        public int TotaPage { get; set; }
        public PagingListDto(List<T> items, int count,int pageIdex,int pageSize)
        {
            PageIndex = pageIdex;
            TotaPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }


    }
}
