using Microsoft.AspNetCore.Mvc;
using Arcade.Domain.Interfaces.Repository;
using Arcade.Service.Services;
using Arcade.Domain.DTOs;

namespace Arcade.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PontuacaoController : ControllerBase
    {
        private readonly IPontuacaoRepository _repository;
        private readonly EstatisticaService _estatisticaService;

        public PontuacaoController(IPontuacaoRepository repository, EstatisticaService estatisticaService)
        {
            _repository = repository;
            _estatisticaService = estatisticaService;
        }

        [HttpPost]
        public IActionResult Registrar([FromBody] Pontuacao pontuacao)
        {
            _repository.Adicionar(pontuacao);
            return Ok(pontuacao);
        }

        [HttpGet("ranking")]
        public IActionResult Ranking()
        {
            var ranking = _repository.ObterTop10();
            return Ok(ranking);
        }        

        [HttpGet("estatisticas/{jogador}")]
        public ActionResult<EstatisticaJogadorDto> ObterEstatisticas(string jogador)
        {
            jogador = Uri.UnescapeDataString(jogador);

            var partidas = _repository.ObterPorJogador(jogador)
                                      .OrderBy(p => p.DataPartida)
                                      .ToList();

            if (!partidas.Any())
                return NotFound("Jogador não encontrado.");

            var estatisticas = _estatisticaService.CalcularEstatisticas(jogador, partidas);
            return Ok(estatisticas);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPontuacao(Guid id, [FromBody] Pontuacao pontuacao)
        {
            var existente = _repository.ObterPorId(id);
            if (existente == null)
                return NotFound($"Pontuação com ID {id} não encontrada.");

            _repository.Atualizar(id, pontuacao);
            return Ok(pontuacao);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverPontuacao(Guid id)
        {
            var existente = _repository.ObterPorId(id);
            if (existente == null)
                return NotFound($"Pontuação com ID {id} não encontrada.");

            _repository.Remover(id);
            return NoContent();
        }
    }
}
