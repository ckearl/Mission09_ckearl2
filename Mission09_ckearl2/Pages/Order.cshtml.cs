using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_ckearl2.Infrastructure;
using Mission09_ckearl2.Models;

namespace Mission09_ckearl2.Pages
{
    public class OrderModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public OrderModel(IBookstoreRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.AddItem(b, 1);
            
            HttpContext.Session.SetJson("cart", cart);
            
            return RedirectToPage(new{ReturnUrl = returnUrl});
        }
    }
}