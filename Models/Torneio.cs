namespace Torneio_de_Luta.Models
{
    public class Torneio
    {
        private List<Lutador> _lutadores;
        private Lutador Campeao;
        public Torneio(List<Lutador> lutadores)
        {
            _lutadores = lutadores;
        }    
    }
}
