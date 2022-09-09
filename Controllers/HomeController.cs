using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View(lutadores);
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}