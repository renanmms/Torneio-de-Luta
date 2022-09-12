using Torneio_de_Luta.Services.Interfaces;

namespace Torneio_de_Luta.Models
{
    public class Luta
    {
        private readonly Lutador _atleta1;
        private readonly Lutador _atleta2;
        public Lutador Vencedor { get; private set; }

        public Luta(Lutador atleta1, Lutador atleta2)
        {
            _atleta1 = atleta1;
            _atleta2 = atleta2;
        }

        public Lutador DefinirVencedor()
        {
            
            float porcentagemDeVitoriasDoAtleta1 = ((float)_atleta1.Vitorias / (float)_atleta1.Lutas) * 100.0f;
            float porcentagemDeVitoriasDoAtleta2 = ((float)_atleta2.Vitorias / (float)_atleta2.Lutas) * 100.0f;

            if((int)porcentagemDeVitoriasDoAtleta1 > (int)porcentagemDeVitoriasDoAtleta2)
            {
                Vencedor = _atleta1;
            }else if ((int)porcentagemDeVitoriasDoAtleta1 == (int)porcentagemDeVitoriasDoAtleta2)
            {
                Vencedor = DefinirDesempate();
            }
            else
            {
                Vencedor = _atleta2;
            }

            Vencedor.Vitorias++;
            Vencedor.Lutas++;
            MudarClassificacao(Vencedor);

            return Vencedor;
        }

        private Lutador DefinirDesempate()
        {
            var resultadoDoDesempate = new Lutador();
            if(_atleta1.ArtesMarciais.Count() > _atleta2.ArtesMarciais.Count())
            {
                resultadoDoDesempate = _atleta1;
            }
            else if (_atleta1.ArtesMarciais.Count() == _atleta2.ArtesMarciais.Count())
            {
                resultadoDoDesempate = (_atleta1.Lutas > _atleta2.Lutas) ? _atleta1 : _atleta2;
            }
            else
            {
                resultadoDoDesempate = _atleta2;
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
