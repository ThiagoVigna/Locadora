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
    //[Key]
    public dynamic Id { get; set; }
    //[Required]
    public dynamic Titulo { get; set; }
    //[Required]
    public dynamic ClassificacaoIndicativa { get; set; }
    //[Required]
    public dynamic Lancamento { get; set; }

        public CreateFilmeViewModel(dynamic indexId, dynamic indexTitulo, dynamic indexClassificacaoIndicativa, dynamic indexLancamento)
        {
            Id = indexId;
            Titulo = indexTitulo;
            ClassificacaoIndicativa = indexClassificacaoIndicativa;
            Lancamento = indexLancamento;
        }

        public CreateFilmeViewModel()
        {
        }
    }
   

}
