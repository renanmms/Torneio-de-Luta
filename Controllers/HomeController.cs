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

        [HttpGet]
        public IActionResult Resultado()
        {
            var dadosDeTeste = new List<Lutador> {
                new Lutador { Nome="Renan", Vitorias=32, Idade=22, Lutas=40, ArtesMarciais = new List<string>{ "Karate" } },
                new Lutador { Nome="Luis", Vitorias=20, Idade=33, Lutas=30, ArtesMarciais = new List<string>{ "Jiu-Jitsu" } },
                new Lutador { Nome="Rafael", Vitorias=40, Idade=18, Lutas=50, ArtesMarciais = new List<string>{ "Boxe" } },
                new Lutador { Nome="Lucas", Vitorias=19, Idade=30, Lutas=55, ArtesMarciais = new List<string>{ "Muay-thai" } },
                new Lutador { Nome="Thiago", Vitorias=10, Idade=20, Lutas=15, ArtesMarciais = new List<string>{ "Kung-Fu" } },
                new Lutador { Nome="Rocky", Vitorias=15, Idade=25, Lutas=16, ArtesMarciais = new List<string>{ "Boxe" } },
                new Lutador { Nome="Ryu", Vitorias=29, Idade=30, Lutas=30, ArtesMarciais = new List<string>{ "Karate", "Kung-Fu" } },
                new Lutador { Nome="Kyo", Vitorias=20, Idade=32, Lutas=30, ArtesMarciais = new List<string>{ "Karate" } },
                new Lutador { Nome="Akuma", Vitorias=99, Idade=150, Lutas=100, ArtesMarciais = new List<string>{ "Karate", "Kung-Fu" } },
                new Lutador { Nome="Muhammad Ali", Vitorias=20, Idade=33, Lutas=30, ArtesMarciais = new List<string>{ "Boxe"} },
                new Lutador { Nome="Anderson Silva", Vitorias=20, Idade=47, Lutas=30, ArtesMarciais = new List<string>{ "Boxe", "Jiu-jítsu", "Muay thai, Taekwondo", "Judô", "Capoeira" } },
                new Lutador { Nome="Fulano", Vitorias=20, Idade=28, Lutas=30, ArtesMarciais = new List<string>{ "Sansho", "Jiu-Jitsu" } },
                new Lutador { Nome="Sicrano", Vitorias=20, Idade=27, Lutas=30, ArtesMarciais = new List<string>{ "Boxe", "Kung-Fu" } },
                new Lutador { Nome="Whindersson Nunes", Vitorias=27, Idade=33, Lutas=30, ArtesMarciais = new List<string>{ "Boxe" } },
                new Lutador { Nome="Mike Tyson", Vitorias=20, Idade=56, Lutas=30, ArtesMarciais = new List<string>{ "Boxe" } },
                new Lutador { Nome="Jon Jones", Vitorias=35, Idade=35, Lutas=60, ArtesMarciais = new List<string>{ "Boxe" , "Wrestling"} }
            };

            Torneio campeonato = new Torneio(dadosDeTeste);
            campeonato.Iniciar();
            var vencedor = campeonato.Campeao;

            return View(vencedor);
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