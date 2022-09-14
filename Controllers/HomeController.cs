using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Torneio_de_Luta.InputModels;
using Torneio_de_Luta.Models;

namespace Torneio_de_Luta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Lutador> lutadores = null;
            try
            {
                lutadores = await GetLutadores();
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


        private static async Task<List<Lutador>> GetLutadores()
        {
            var lutadores = new List<Lutador>();
            var client = new HttpClient();

            var apiUrl = "https://apidev-mbb.t-systems.com.br:8443/edgemicro_tsdev/torneioluta/api/competidores";
            var schema = "X-API-Key";
            var apiKey = "29452a07-5ff9-4ad3-b472-c7243f548a33";
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");

            client.DefaultRequestHeaders.Add(schema, apiKey);
            client.DefaultRequestHeaders.Accept.Add(mediaType);
            var response = client.GetAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                lutadores = await response.Content.ReadFromJsonAsync<List<Lutador>>();
            }

            return lutadores;
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}