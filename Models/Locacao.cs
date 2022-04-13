using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
  public class Locacao
  {
    [Key]
    public int Id { get; set; }
    public int Id_Cliente { get; set; }
    public int Id_Filme{ get; set; }
    public DateTime DataLocacao{ get; set; } = DateTime.Now;
    public DateTime DataDevolucao { get; set; }

   // public Filme Lamcamento { get; set; }
  }
}
