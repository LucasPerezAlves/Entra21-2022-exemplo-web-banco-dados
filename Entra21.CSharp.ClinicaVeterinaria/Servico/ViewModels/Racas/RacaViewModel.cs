using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Racas
{
    public class RacaViewModel
    {
        //[Display(name = "Nome")]
        [Display(Name = nameof(Nome))]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(4, ErrorMessage = "{0} deve conter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Nome { get; set; }
        [Display(Name = "Especie")]
        [Required(ErrorMessage = "{0} deve ser escolhida")]
        public string Especie { get; set; }
    }
}