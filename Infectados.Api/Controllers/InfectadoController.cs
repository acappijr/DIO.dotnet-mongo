using Infectados.Data.Servicos;
using Infectados.Domain.Collections;
using Infectados.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.GeoJsonObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        private readonly IInfectadoRepository _infectado;

        public InfectadoController(IInfectadoRepository infectado)
        {
            _infectado = infectado;
        }

        [HttpGet("{infectadoId}", Name = "ObterInfectadoAsync")]
        public async Task<ActionResult<Infectado>> ObterInfectadoPorId(string infectadoId)
        {
            var infectado = await _infectado.ObterInfectadoPorIdAsync(infectadoId);

            if (infectado == null)
            {
                return NotFound();
            }

            return Ok(infectado);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Infectado>>> ObterInfectados()
        {
            var infectados = await _infectado.ObterTodosInfectadosAsync();

            return Ok(infectados);
        }

        [HttpPost]
        public async Task<ActionResult<Infectado>> SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado
            {
                DataNascimento = dto.DataNascimento,
                Sexo = dto.Sexo,
                Localizacao = new GeoJson2DGeographicCoordinates(dto.Longitude, dto.Latitude)
            };

            await _infectado.SalvarInfectadoAsync(infectado);

            return CreatedAtRoute("ObterInfectadoAsync",
                new { infectadoId = infectado.Id },
                infectado);
        }
    }
}
