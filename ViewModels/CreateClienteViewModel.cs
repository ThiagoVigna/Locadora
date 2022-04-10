using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.ViewModels
{
  public class CreateClienteViewModel
  {
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string CPF { get; set; }

    public DateTime DataNascimento { get; set; }
  }
}
