using Locadora.Data;
using Locadora.Models;
using Locadora.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Locadora.Controllers
{
  [ApiController]
  [Route("v1")]
  public class ClienteController : ControllerBase
  {
    [HttpGet]
    [Route("Cliente")]
    public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
    {
      var todos = await context
        .Clientes
        .AsNoTracking()
        .ToListAsync();
      return Ok(todos);
    }

    [HttpGet]
    [Route("Cliente/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, [FromRoute] int id)
    {
      var todo = await context
        .Clientes
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == id);
      return todo == null
        ? NotFound()
        : Ok(todo);
    }

    [HttpPost("Cliente")]
    public async Task<IActionResult> PostAsync([FromServices] AppDbContext context, [FromBody] CreateClienteViewModel model)
    {
      if (!ModelState.IsValid)
        return BadRequest();
      var todo = new Cliente
      {
        Id = model.Id,
        Nome= model.Nome,
        CPF = model.CPF,
        DataNascimento = model.DataNascimento,
      };

      try
      {
        await context.Clientes.AddAsync(todo);
        await context.SaveChangesAsync();
        return Created($"v1/todos/{todo.Id}", todo);
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    [HttpPut("Cliente/{id}")]
    public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromBody] CreateClienteViewModel model, [FromRoute] int id)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var todo = await context
        .Clientes
        .FirstOrDefaultAsync(x => x.Id == id);

      if (todo == null) return NotFound();

      try
      {
        todo.Id = model.Id;
        context.Clientes.Update(todo);
        await context.SaveChangesAsync();
        return Ok(todo);
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    [HttpDelete("Cliente/{id}")]
    public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context, [FromRoute] int id)
    {
      var todo = await context
        .Clientes
        .FirstOrDefaultAsync(x => x.Id == id);

      try
      {
        context.Clientes.Remove(todo);
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
