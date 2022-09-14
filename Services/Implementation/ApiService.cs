using System.Net.Http.Headers;
using Torneio_de_Luta.Models;
using Torneio_de_Luta.Services.Interfaces;

namespace Torneio_de_Luta.Services.Implementation
{
    public class ApiService : IApiService
    {
        public async Task<List<Lutador>> GetLutadores()
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
    }
}
