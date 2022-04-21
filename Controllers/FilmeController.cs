using Locadora.Data;
using Locadora.Models;
using Locadora.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Locadora.Controllers
{
    public class FilmeController : ControllerBase
    {
        [HttpGet]
        [Route("Filme")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var todos = await context
              .Filmes
              .AsNoTracking()
              .ToListAsync();
            return Ok(todos);
        }

        [HttpGet]
        [Route("Filme/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var todo = await context
              .Filmes
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == id);
            return todo == null
              ? NotFound()
              : Ok(todo);
        }

        [HttpPost("Filme")]
        public async Task<IActionResult> PostAsync([FromServices] AppDbContext context, [FromBody] CreateFilmeViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var todo = new Filme
            {
                Titulo = model.Titulo,
                ClassificacaoIndicativa = model.ClassificacaoIndicativa,
                Lancamento = model.Lancamento,
            };

            try
            {
                await context.Filmes.AddAsync(todo);
                await context.SaveChangesAsync();
                return Created($"v1/todos/{todo.Id}", todo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Filme/{id}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromBody] CreateFilmeViewModel model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var todo = await context
              .Filmes
              .FirstOrDefaultAsync(x => x.Id == id);

            if (todo == null) return NotFound();

            try
            {
                todo.Id = model.Id;
                context.Filmes.Update(todo);
                await context.SaveChangesAsync();
                return Ok(todo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Filme/{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var todo = await context
              .Filmes
              .FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.Filmes.Remove(todo);
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
