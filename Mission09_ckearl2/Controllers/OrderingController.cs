using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mission09_ckearl2.Models;

namespace Mission09_ckearl2.Controllers
{
    public class OrderingController : Controller
    {
        private IOrderRepository repo { get; set; }
        private Cart cart { get; set; }

        public OrderingController(IOrderRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.Items.ToArray();
                repo.SaveOrder(order);
                cart.ClearCart();
                return RedirectToPage("/DonationCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}