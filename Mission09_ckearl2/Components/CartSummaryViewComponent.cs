using Microsoft.AspNetCore.Mvc;
using Mission09_ckearl2.Models;
namespace Mission09_ckearl2.Components {
    public class CartSummaryViewComponent : ViewComponent {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService) {
            cart = cartService;
        }
        public IViewComponentResult Invoke() {
            return View(cart);
        }
    }
}