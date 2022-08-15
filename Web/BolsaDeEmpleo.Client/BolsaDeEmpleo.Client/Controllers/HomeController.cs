using BolsaDeEmpleo.Client.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace BolsaDeEmpleo.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public async Task<IActionResult> BuscarEmpleo(string searchString)
        {
            //aqui va la logica para buscar en la base de datos el empleo
            //se necesita agregar al vew que retorna esto un view para que sea vea la lista de empleos 
            // juntarnos
            return View("EmpleoVIew");
        }

    }
}