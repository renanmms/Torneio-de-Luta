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

        private Lutador DefinirVencedor()
        {
            
            int porcentagemDeVitoriasDoAtleta1 = (_atleta1.Vitorias / _atleta1.Lutas) * 100;
            int porcentagemDeVitoriasDoAtleta2 = (_atleta2.Vitorias / _atleta2.Lutas) * 100;

            if(porcentagemDeVitoriasDoAtleta1 > porcentagemDeVitoriasDoAtleta2)
            {
                Vencedor = _atleta1;
            }else if (porcentagemDeVitoriasDoAtleta1 == porcentagemDeVitoriasDoAtleta2)
            {
                Vencedor = DefinirDesempate();
            }
            else
            {
                Vencedor = _atleta2;
            }
            //TODO: Mudar Classificação do Lutador Vencedor
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
    }
}
