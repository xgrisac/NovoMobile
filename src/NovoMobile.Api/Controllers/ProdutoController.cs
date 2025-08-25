using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovoMobile.Api.Data;
using NovoMobile.Api.Models;

namespace NovoMobile.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProdutoController> _logger;
        public ProdutoController(AppDbContext context, ILogger<ProdutoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Retorna a lista de veículos estacionados no pátio.
        /// </summary>
        [HttpGet("Estoque")]
        public ActionResult<List<Estacionamento>> BuscarVeiculos()
        {
            _logger.LogInformation("Buscando veículos no pátio...");

            try
            {
                var veiculos = _context.VeiculosEstacionados.ToList();

                _logger.LogInformation("Veículos encontrados: {Total}", veiculos.Count);

                return Ok(veiculos); // Sucesso 200
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar veículos no pátio");
                return StatusCode(500, $"Ocorreu um erro ao processar a solicitação. {ex.Message}");
            }

        }

        /// <summary>
        /// Adciona novo veículo ao pátio.
        /// </summary>
        [HttpPost("Entrada")]
        public ActionResult<Estacionamento> EntradaVeiculo([FromBody] Estacionamento novoVeiculo)
        { 
            _logger.LogInformation("Iniciante requisição de entrada de veículo...");

            if (novoVeiculo == null) // Verifica se foi informado o novo veículo
            {
                _logger.LogWarning("Tentativa de inserir veículo com valor nulo.");
                return BadRequest("Novo veículo não informado"); // Bad Request 400
            }

            _context.VeiculosEstacionados.Add(novoVeiculo);
            _context.SaveChanges();

            _logger.LogInformation("Veículo adicionado com sucesso: {Placa}", novoVeiculo.Placa);

            return CreatedAtAction(nameof(BuscarVeiculos), new { id = novoVeiculo.Id }, novoVeiculo); // Created 201

        }
    }
}
