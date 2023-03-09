using Microsoft.AspNetCore.Mvc;
using Mission09_ckearl2.Models;
using Mission09_ckearl2.Models.ViewModels;
using System.Linq;

namespace Mission09_ckearl2.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        public HomeController(IBookstoreRepository temp) => repo = temp;

        // GET
        public IActionResult Index(string bookType, int pageNum = 1)
        {
            int pageSize = 10;

            var indexRenderInfo = new BooksViewModel
            {
                Books = repo.Books
                    .Where(b => b.Category == bookType || bookType == null)
                    .OrderBy(b => b.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookType == null
                        ? repo.Books.Count()
                        : repo.Books.Where(b => b.Category == bookType).Count()),
                    
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(indexRenderInfo);
        }
    }
}