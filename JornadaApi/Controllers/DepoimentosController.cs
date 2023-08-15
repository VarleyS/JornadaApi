using AutoMapper;
using Azure;
using JornadaApi.Data;
using JornadaApi.Data.Dtos;
using JornadaApi.Images;
using JornadaApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JornadaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepoimentosController : ControllerBase
    {
        private DepoimentoContext _context;
        private IMapper _mapper;
        private Img _img = new Img();

        public DepoimentosController(DepoimentoContext depomentoContext, IMapper mapper)
        {
            _context = depomentoContext;
            _mapper = mapper;
        }
        /// <summary>
        /// Adiciona um depoimento ao banco de dados
        /// </summary>
        /// <param name="depoimentoDto">Objeto com os campos necessários para criação de um depoimento</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>-
        [HttpPost]
        public async Task<IActionResult> AdicionaDepoimento([FromBody] CreateDepoimentoDto depoimentoDto)
        {
            Depoimento depoimento = new Depoimento();

            if (depoimentoDto != null)
            {
                depoimento = _mapper.Map<Depoimento>(depoimentoDto);
                _context.Depoimentos.Add(depoimento);
                _img.Save(depoimentoDto.Foto);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(RetornaDepoimentoId), new { id = depoimento.Id }, depoimento);
        }

        /// <summary>
        /// Retorna uma collection com todos os depoimentos armazenados no banco de dados
        /// </summary>
        /// <param name="skip">Parametro utilizado para ignorar um número especifico de elementos e retornar o restante"</param>
        /// <param name="take">Retorna um número especifico de elementos contíguos do início de uma sequência</param>
        /// <returns>IEnumerable</returns>
        /// <response code="200">Caso retorno seja feito com sucesso</response>
        [HttpGet]
        public IEnumerable<ReadDepoimentoDto> RetornaDepoimentos([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadDepoimentoDto>>(_context.Depoimentos.Skip(skip).Take(take));
        }

        /// <summary>
        /// Retorna um depoimento armazenado no banco de dados utilizando o Id de indetificação
        /// </summary>
        /// <param name="id">Identificador do objeto armazenado no banco de dados</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso retorno seja feito com sucesso</response>
        [HttpGet("{id}")]
        public IActionResult RetornaDepoimentoId(Guid id)
        {
            var depoimento = _context.Depoimentos.FirstOrDefault(depoimentos => depoimentos.Id == id);

            if (depoimento == null)
            {
                return NotFound();
            }
            var imageBytes = _img.ConvertBase64ToImage(depoimento.Foto);
            
            var depoimentoDto = _mapper.Map<ReadDepoimentoDto>(depoimento);
            return Ok(depoimentoDto);
            //return File(imageBytes, "image/jpeg");
        }

        /// <summary>
        /// Atualizada depoimento com base no Id repassado
        /// </summary>
        /// <param name="id">Identificador do objeto armazenado no banco de dados</param>
        /// <param name="depoimentoDto">Informações do elementos que serão atualizadas no banco de dados</param>
        /// <returns>IActionResult</returns>
        /// <response code="204 NoContent">Caso atualização seja feita com sucesso</response>
        [HttpPut("{id}")]
        public IActionResult AtualizaDepoimento(Guid id, [FromBody] UpdateDepoimentoDto depoimentoDto)
        {
            var depoimento = _context.Depoimentos.FirstOrDefault(depoimento => depoimento.Id == id);
            if (depoimento == null)
            {
                return NotFound();
            }
            _mapper.Map(depoimentoDto, depoimento);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Atualiza depoimentos parcial através do método Patch
        /// </summary>
        /// <param name="id">Identificados do elemento</param>
        /// <param name="patch">Parametro utilizado para atualização parcial do elemento</param>
        /// [{"op": "replace", "path": "/nome", "value": "nome a atualizar"}]
        /// <returns>IActionResult</returns>
        /// <response code="204 NoContent">Caso atualização seja realizada corretamente</response>
        [HttpPatch("{id}")]
        public IActionResult AtualizaDepoimentoParcial(Guid id, JsonPatchDocument<UpdateDepoimentoDto> patch)
        {
            var depoimento = _context.Depoimentos.FirstOrDefault(depoimento => depoimento.Id == id);
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

        /// <summary>
        /// Realiza deleção de depoimento no banco de dados
        /// </summary>
        /// <param name="id">Identificador do elemento a ser deletado</param>
        /// <returns>IActionResult</returns>
        /// <response code="204 NoContent">Caso deleção seja realizada</response>
        [HttpDelete("{id}")]
        public IActionResult DeletaDepoimento(Guid id)
        {
            var depoimento = _context.Depoimentos.FirstOrDefault(depoimento => depoimento.Id == id);
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
