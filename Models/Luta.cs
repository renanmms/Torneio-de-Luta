
namespace Torneio_de_Luta.Models
{
    public class Luta
    {
        private readonly Lutador _primeiroLutador;
        private readonly Lutador _segundoLutador;
        public Lutador Vencedor { get; private set; }

        public Luta(Lutador primeiroLutador, Lutador segundoLutador)
        {
            _primeiroLutador = primeiroLutador;
            _segundoLutador = segundoLutador;
        }

        public Lutador DefinirVencedor()
        {
            var numeroDeVitoriasDoPrimeiroAtleta = (float)_primeiroLutador.Vitorias;
            var numeroTotalDeLutasDoPrimeiroAtleta = (float)_primeiroLutador.Lutas;

            var numeroDeVitoriasDoSegundoAtleta = (float)_segundoLutador.Vitorias;
            var numeroTotalDeLutasDoSegundoAtleta = (float)_segundoLutador.Lutas;

            var porcentagemDeVitoriasDoPrimeiroAtleta = (numeroDeVitoriasDoPrimeiroAtleta / numeroTotalDeLutasDoPrimeiroAtleta) * 100.0f;
            var porcentagemDeVitoriasDoSegundoAtleta = (numeroDeVitoriasDoSegundoAtleta / numeroTotalDeLutasDoSegundoAtleta) * 100.0f;

            if((int)porcentagemDeVitoriasDoPrimeiroAtleta > (int)porcentagemDeVitoriasDoSegundoAtleta)
            {
                Vencedor = _primeiroLutador;
            }else if ((int)porcentagemDeVitoriasDoPrimeiroAtleta == (int)porcentagemDeVitoriasDoSegundoAtleta)
            {
                Vencedor = DefinirDesempate();
            }
            else
            {
                Vencedor = _segundoLutador;
            }

            Vencedor.Vitorias++;
            Vencedor.Lutas++;
            MudarClassificacao(Vencedor);

            return Vencedor;
        }

        private Lutador DefinirDesempate()
        {
            var resultadoDoDesempate = new Lutador();
            var qtdDeArtesMarciaisDoPrimeiroAtleta = _primeiroLutador.ArtesMarciais.Count;
            var qtdDeArtesMarciaisDoSegundoAtleta = _segundoLutador.ArtesMarciais.Count;

            if(qtdDeArtesMarciaisDoPrimeiroAtleta > qtdDeArtesMarciaisDoSegundoAtleta)
            {
                resultadoDoDesempate = _primeiroLutador;
            }
            else if (qtdDeArtesMarciaisDoPrimeiroAtleta == qtdDeArtesMarciaisDoSegundoAtleta)
            {
                resultadoDoDesempate = (_primeiroLutador.Lutas > _segundoLutador.Lutas) ? _primeiroLutador : _segundoLutador;
            }
            else
            {
                resultadoDoDesempate = _segundoLutador;
            }

            return resultadoDoDesempate;
        }

        private void MudarClassificacao(Lutador vencedor)
        {
            var classificacao = vencedor.Classificado;
            switch (classificacao)
            {
                case Classificacao.OITAVAS:
                    vencedor.Classificado = Classificacao.QUARTAS;
                    break;
                case Classificacao.QUARTAS:
                    vencedor.Classificado = Classificacao.SEMIFINAL;
                    break;
                case Classificacao.SEMIFINAL:
                    vencedor.Classificado = Classificacao.FINAL;
                    break;
                default:
                    classificacao = Classificacao.OITAVAS;
                    break;
            }
        }
    }
}
