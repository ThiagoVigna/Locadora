using Locadora.Models;
using System.ComponentModel.DataAnnotations;

namespace Locadora.ViewModels
{
  public class CreateLocacaoViewModel
  {
    [Required]
    public int Id_Cliente { get; set; }
    [Required]
    public int Id_Filme { get; set; }
  }
}
