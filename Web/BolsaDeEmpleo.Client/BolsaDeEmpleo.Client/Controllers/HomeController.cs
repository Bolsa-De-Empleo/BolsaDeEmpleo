
using BolsaDeEmpleo.Api.Data.Interfaces;
using BolsaDeEmpleo.Shared;
using BolsaDeEmpleo.Shared.NewFolder;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace BolsaDeEmpleo.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient _Client;

        public HomeController(ILogger<HomeController> logger, HttpClient client)
        {
            _logger = logger;
            _Client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        public async Task<IActionResult> BuscarEmpleo(string searchString)
        {
            //aqui va la logica para buscar en la base de datos el empleo
            //se necesita agregar al vew que retorna esto un view para que sea vea la lista de empleos 

            var emeplos = await _Client.GetAsync(Common.apiBaseURL + searchString);
            var list = await emeplos.Content.ReadFromJsonAsync<List<Empleo>>();

            return View("Index", emeplos);
        }
        

    }
}