using Locadora.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Controllers
{
  [ApiController]
  [Route("v1")]
  public class LeituraController :ControllerBase
  {
    [HttpGet]
    [Route("Leitura")]
    public IActionResult Get([FromServices] Reader reade)
    {
      var todos = reade;
      

      return Ok(todos);
    }

  }
}
