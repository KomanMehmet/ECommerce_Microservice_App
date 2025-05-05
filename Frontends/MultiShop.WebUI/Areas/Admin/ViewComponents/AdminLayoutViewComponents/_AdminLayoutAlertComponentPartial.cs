using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutAlertComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            ViewBag.CreateSuccess = TempData["CreateSuccess"];
            ViewBag.UpdateSuccess = TempData["UpdateSuccess"];

            return View();
        }
    }
}
