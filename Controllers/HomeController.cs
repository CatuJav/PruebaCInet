using APLICACION.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using APLICACION.Servicios;

namespace APLICACION.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicio_Api _servicio_api;

        public HomeController(IServicio_Api servicio_api)
        {
            _servicio_api= servicio_api;
        }

        public async Task<IActionResult> Index()
        {
            List<Post> lista = await _servicio_api.Lista();
            return View(lista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}