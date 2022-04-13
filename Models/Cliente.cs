using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
  public class Cliente
  {
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
  }
}
