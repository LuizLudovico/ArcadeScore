using Microsoft.AspNetCore.Mvc;
using Arcade.Domain.Interfaces.Repository;

namespace Arcade.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PontuacaoController : ControllerBase
    {
        private readonly IPontuacaoRepository _repository;

        public PontuacaoController(IPontuacaoRepository repository)
        {
            _repository = repository;
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
            var top10 = _repository.ObterTop10();
            return Ok(top10);
        }

        [HttpGet("{jogador}")]
        public IActionResult Estatisticas(string jogador)
        {
            var partidas = _repository.ObterPorJogador(jogador);
            if (!partidas.Any()) return NotFound("Jogador não encontrado.");

            var estatisticas = new
            {
                Jogador = jogador,
                PartidasJogadas = partidas.Count,
                MediaPontuacao = partidas.Average(p => p.Pontos),
                MaiorPontuacao = partidas.Max(p => p.Pontos),
                MenorPontuacao = partidas.Min(p => p.Pontos),
                RecordesBatidos = CalcularRecordes(partidas),
                TempoDeJogo = (partidas.Last().DataPartida - partidas.First().DataPartida).TotalDays + " dias"
            };

            return Ok(estatisticas);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPontuacao(Guid id, [FromBody] Pontuacao pontuacao)
        {
            var existe = _repository.ObterPorId(id);
            if (existe == null)
                return NotFound($"Pontuação com ID {id} não encontrada.");

            _repository.Atualizar(id, pontuacao);
            return Ok(pontuacao);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverPontuacao(Guid id)
        {
            var existe = _repository.ObterPorId(id);
            if (existe == null)
                return NotFound($"Pontuação com ID {id} não encontrada.");

            _repository.Remover(id);
            return NoContent();
        }

        private int CalcularRecordes(List<Pontuacao> partidas)
        {
            int recordes = 0, max = 0;
            foreach (var p in partidas)
            {
                if (p.Pontos > max)
                {
                    recordes++;
                    max = p.Pontos;
                }
            }
            return recordes - 1;
        }
    }
}
