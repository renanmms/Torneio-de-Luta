using Torneio_de_Luta.Models;

namespace Torneio_de_Luta.Services.Interfaces
{
    public interface IApiService
    {
        public Task<List<Lutador>> GetLutadores();
    }
}
