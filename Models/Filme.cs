namespace Locadora.Models
{
  public class Filme
  {
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int ClassificacaoIndicativa { get; set; }
    public bool Lancamento { get; set; }

    public Filme(bool lancamento)
    {
      Lancamento = lancamento;
    }
  }

  
}
