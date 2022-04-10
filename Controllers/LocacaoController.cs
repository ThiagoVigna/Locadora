using System;
using System.Linq;
using System.Threading.Tasks;
using Locadora.Data;
using Locadora.Models;
using Locadora.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Controllers
{
  [ApiController]
  [Route("v1")]
  public class LocacaoController : ControllerBase
  {
    [HttpGet]
    [Route("Locacoes")]
    public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
    {
      var todos = await context
        .Locacoes
        .AsNoTracking()
        .ToListAsync();
      return Ok(todos);
    }

    [HttpGet]
    [Route("Locacoes/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context,[FromRoute] int id)
    {
      var todo = await context
        .Locacoes
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == id);
      return todo == null
        ? NotFound()
        : Ok(todo);
    }

    [HttpPost("Locacoes")]
    public async Task<IActionResult> PostAsync([FromServices] AppDbContext context,[FromBody] CreateLocacaoViewModel model)
    {
      DateTime hoje = DateTime.Now;
      var lancamento = await context.Filmes.Select(x => x.Lancamento).ToListAsync();

      if (!ModelState.IsValid)
        return BadRequest();
      var todo = new Locacao
      {
        Id_Cliente = model.Id_Cliente,
        Id_Filme = model.Id_Filme,
        Lamcamento = model.Lancamento,
        DataLocacao = DateTime.Now,
        DataDevolucao = hoje.AddDays(3),
      };

      try
      {
        await context.Locacoes.AddAsync(todo);
        await context.SaveChangesAsync();
        return Created($"v1/todos/{todo.Id}", todo);
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    [HttpPut("Locacoes/{id}")]
    public async Task<IActionResult> PutAsync([FromServices] AppDbContext context,[FromBody] CreateLocacaoViewModel model,[FromRoute] int id)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var todo = await context
        .Locacoes
        .FirstOrDefaultAsync(x => x.Id == id);

      if (todo == null) return NotFound();

      try
      {
        todo.Id_Cliente = model.Id_Cliente;
        context.Locacoes.Update(todo);
        await context.SaveChangesAsync();
        return Ok(todo);
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    [HttpDelete("Locacoes/{id}")]
    public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context,[FromRoute] int id)
    {
      var todo = await context
        .Locacoes
        .FirstOrDefaultAsync(x => x.Id == id);

      try
      {
        context.Locacoes.Remove(todo);
        await context.SaveChangesAsync();

        return Ok();
      }
      catch (Exception)
      {
       return BadRequest();
      }

    }
  }
}
