using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MVCPeliculas.Controllers
{
    public class HelloWorldController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome(string nombre, string apellido, int numVeces = 1)
        {
            ViewData["nombre"] = "Hola " + nombre + " " + apellido + ", veces mostrado = " + numVeces;
            ViewData["numVeces"] = numVeces;

            return View();
        }

        public string Greeting(string nombre, string apellido, int id = 1)
        {
            return HtmlEncoder.Default.Encode($"Hola {nombre} , {apellido} , ID: {id}");
        }
    }
}
