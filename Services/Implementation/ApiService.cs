using System.Net.Http.Headers;
using Torneio_de_Luta.Models;
using Torneio_de_Luta.Services.Interfaces;

namespace Torneio_de_Luta.Services.Implementation
{
    public class ApiService : IApiService
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly string _schema;
        public ApiService(IConfiguration configuration)
        {
            _baseUrl = configuration.GetSection("ApiSettings:Url").Value;
            _apiKey = configuration.GetSection("ApiSettings:ApiKey").Value;
            _schema = configuration.GetSection("ApiSettings:Schema").Value;
        }
        public async Task<List<Lutador>> GetLutadores()
        {
            var lutadores = new List<Lutador>();
            var client = new HttpClient();

            var apiUrl = $"{_baseUrl}/edgemicro_tsdev/torneioluta/api/competidores";
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");

            client.DefaultRequestHeaders.Add(_schema, _apiKey);
            client.DefaultRequestHeaders.Accept.Add(mediaType);
            var response = client.GetAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                lutadores = await response.Content.ReadFromJsonAsync<List<Lutador>>();
            }

            return lutadores;
        }
    }
}
