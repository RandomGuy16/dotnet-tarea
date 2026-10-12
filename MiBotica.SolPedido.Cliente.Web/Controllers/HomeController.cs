using System.Web.Mvc;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Error500()
        {
            return View();
        }

        public ActionResult PaginaNoEncontrada()
        {
            return View();
        }
    }
}
