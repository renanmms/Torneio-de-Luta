using System.Linq;

namespace Torneio_de_Luta.Models
{
    public class Torneio
    {
        public Lutador Campeao { get; private set; }
        public List<Luta> Lutas { get; private set; }
        
        private bool FimDoTorneio;
        private readonly List<Lutador> _lutadores;
        private Dictionary<Classificacao, List<Lutador>> LutadoresClassificados;

        public Torneio(List<Lutador> lutadores)
        {
            _lutadores = lutadores;
            FimDoTorneio = false;
            LutadoresClassificados = new Dictionary<Classificacao, List<Lutador>>
            {
                { Classificacao.OITAVAS, new List<Lutador>(_lutadores) },
                { Classificacao.QUARTAS, new List<Lutador>() },
                { Classificacao.SEMIFINAL, new List<Lutador>() },
                { Classificacao.FINAL, new List<Lutador>() }
            };
        }    

        public void Iniciar()
        {
            OrdenarLutadoresPorIdade();

            while (!FimDoTorneio)
            {
                Partidas();
            }
        }

        private void OrdenarLutadoresPorIdade()
        {
            var lutadoresOrdenados = LutadoresClassificados[Classificacao.OITAVAS]
                .OrderBy(l => l.Idade)
                .ToList();

            LutadoresClassificados[Classificacao.OITAVAS] = lutadoresOrdenados;
        }

        private void Partidas()
        {
            foreach (var key in LutadoresClassificados.Keys)
            {
                SimularLutas(LutadoresClassificados[key]);
            }

        }

        private void SimularLutas(List<Lutador> lutadores)
        {
            var numeroDeLutadoresNaClassificacao = lutadores.Count();
            var vencedor = new Lutador();
            
            while (numeroDeLutadoresNaClassificacao > 1)
            {
                var primeiroLutador = lutadores[0];
                var segundoLutador = lutadores[1];
                var luta = new Luta(primeiroLutador, segundoLutador);
                vencedor = luta.DefinirVencedor();

                ClassificarLutador(vencedor);
                lutadores = lutadores.Skip(2).ToList();
                numeroDeLutadoresNaClassificacao = lutadores.Count();
            }
        }

        private void ClassificarLutador(Lutador vencedor)
        {
            var classificacao = vencedor.Classificado;
            if(classificacao == Classificacao.FINAL)
            {
                Campeao = vencedor;
                FimDoTorneio = true;
            }

            LutadoresClassificados[classificacao].Add(vencedor);
        }

    }
}
