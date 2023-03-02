using System;
using System.Linq;

namespace Mission09_ckearl2.Models.ViewModels
{
    public class BooksViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
        
    }
}