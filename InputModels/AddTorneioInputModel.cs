using System.Linq;
using System.ComponentModel.DataAnnotations;
using Torneio_de_Luta.Models;

namespace Torneio_de_Luta.InputModels
{
    public class AddTorneioInputModel
    {
        [LutadoresDoTorneio]
        public List<Lutador> Lutadores { get; }

        public AddTorneioInputModel(List<Lutador> lutadores)
        {
            Lutadores = lutadores;
        }
    }

    public class LutadoresDoTorneioAttribute : ValidationAttribute
    {
        public List<Lutador> Participantes { get; }

        public string GetErrorMessage()
        {
            return $"Favor selecionar 16 lutadores!";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var lutadores = (List<Lutador>)value;
            var numeroDeLutadores = lutadores.Select(l => l).Where(l => l.Selecionado).Count();

            if (numeroDeLutadores == 16)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(GetErrorMessage());
        }
    }
}
