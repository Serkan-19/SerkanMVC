using Microsoft.AspNetCore.Mvc;

namespace Serkan_MVC.Controllers
{
    public class LoginController : Controller
    {
        public ViewResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(string KullaniciAdi, string Sifre)
        {
            return View();
        }
    }
}
