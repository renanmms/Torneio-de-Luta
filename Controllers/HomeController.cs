using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Torneio_de_Luta.Models;
using Torneio_de_Luta.Services.Interfaces;

namespace Torneio_de_Luta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiService _service;

        public HomeController(ILogger<HomeController> logger, IApiService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Lutador> lutadores = null;
            try
            {
                lutadores = await _service.GetLutadores();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View(lutadores);
        }

        [HttpPost]
        public IActionResult Index(List<Lutador> lutadores)
        {
            var selecionados = lutadores.Where(l => l.Selecionado).ToList();

            if(selecionados.Count == 16)
            {
                Torneio campeonato = new Torneio(selecionados);
                campeonato.Iniciar();
                var vencedor = campeonato.Campeao;

                return RedirectToAction("Resultado", vencedor);
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        public IActionResult Resultado(Lutador campeao)
        {
            return View(campeao);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}