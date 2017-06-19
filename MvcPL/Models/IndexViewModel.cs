using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPL.Models.AccountModel;

namespace MvcPL.Models
{
    public class IndexViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}