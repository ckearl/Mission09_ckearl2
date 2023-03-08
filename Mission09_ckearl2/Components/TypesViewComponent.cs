using Microsoft.AspNetCore.Mvc;
using Mission09_ckearl2.Models;
using System.Collections;
using System.Linq;

namespace WaterProject.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }
        public TypesViewComponent(IBookstoreRepository temp) => repo = temp;
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["projectType"];
            
            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(types);
        }
        
    }
}