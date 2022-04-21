using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.ViewModels
{
  public class CreateFilmeViewModel
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Titulo { get; set; }
    [Required]
    public int ClassificacaoIndicativa { get; set; }
    [Required]
    public bool Lancamento { get; set; }
  }
}
