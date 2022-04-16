using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
  public class Filme
  {
    [Key]
    public int Id { get; set; }
    public dynamic Titulo { get; set; }
    public int ClassificacaoIndicativa { get; set; }
    public bool Lancamento { get; set; }
  }  
}
