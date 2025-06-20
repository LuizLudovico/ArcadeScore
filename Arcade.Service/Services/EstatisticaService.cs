using Arcade.Domain.DTOs;

namespace Arcade.Service.Services
{
    public class EstatisticaService
    {
        public EstatisticaJogadorDto CalcularEstatisticas(string jogador, List<Pontuacao> partidas)
        {
            if (!partidas.Any()) return null;

            var maiorPontuacao = partidas.Max(p => p.Pontos);
            var menorPontuacao = partidas.Min(p => p.Pontos);
            var media = partidas.Average(p => p.Pontos);
            var tempo = partidas.Last().DataPartida - partidas.First().DataPartida;
            var tempoJogo = $"{Math.Max(1, (int)Math.Round(tempo.TotalDays / 30))} meses"; 

            return new EstatisticaJogadorDto
            {
                Jogador = jogador,
                PartidasJogadas = partidas.Count,
                MediaPontuacao = Math.Round(media, 2),
                MaiorPontuacao = maiorPontuacao,
                MenorPontuacao = menorPontuacao,
                VezesRecorde = CalcularRecordes(partidas),
                TempoQueJoga = tempoJogo
            };
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
            return Math.Max(0, recordes - 1);
        }
    }
}
