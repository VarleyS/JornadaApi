using AutoMapper;
using Azure;
using JornadaApi.Data;
using JornadaApi.Data.Dtos;
using JornadaApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace JornadaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepoimentosController : ControllerBase
    {
        private DepoimentoContext _context;
        private IMapper _mapper;

        public DepoimentosController(DepoimentoContext depomentoContext, IMapper mapper)
        {
            _context = depomentoContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaDepoimento([FromBody] CreateDepoimentoDto depoimentoDto)
        {
            Depoimento depoimento = _mapper.Map<Depoimento>(depoimentoDto);
            _context.Depoiementos.Add(depoimento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetornaDepoimentoId), new { id = depoimento.Id }, depoimento);
        }

        [HttpGet]
        public IEnumerable<ReadDepoimentoDto> RetornaDepoimentos([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadDepoimentoDto>>(_context.Depoiementos.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult RetornaDepoimentoId(Guid id)
        {
            var depoimento = _context.Depoiementos.FirstOrDefault(depoimentos => depoimentos.Id == id);

            if (depoimento == null)
            {
                return NotFound();
            }
            var depoimentoDto = _mapper.Map<ReadDepoimentoDto>(depoimento);
            return Ok(depoimentoDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaDepoimento(Guid id, [FromBody] UpdateDepoimentoDto depoimentoDto)
        {
            var depoimento = _context.Depoiementos.FirstOrDefault(depoimento => depoimento.Id == id);
            if (depoimento == null)
            {
                return NotFound();
            }
            _mapper.Map(depoimentoDto, depoimento);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizaDepoimentoParcial(Guid id, JsonPatchDocument<UpdateDepoimentoDto> patch)
        {
            var depoimento = _context.Depoiementos.FirstOrDefault(depoimento => depoimento.Id == id);
            if (depoimento == null)
            {
                return NotFound();
            }

            var depoimentoParaAtualizar = _mapper.Map<UpdateDepoimentoDto>(depoimento);
            patch.ApplyTo(depoimentoParaAtualizar, ModelState);

            if (!TryValidateModel(depoimentoParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(depoimentoParaAtualizar, depoimento);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaDepoimento(Guid id)
        {
            var depoimento = _context.Depoiementos.FirstOrDefault(depoimento => depoimento.Id == id);
            if (depoimento == null)
            {
                return NotFound();
            }

            _context.Remove(depoimento);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
