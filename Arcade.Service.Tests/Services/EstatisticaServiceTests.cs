using Arcade.Service.Services;
using Xunit;

namespace Arcade.Tests.Services
{
    public class EstatisticaServiceTests
    {
        private readonly EstatisticaService _service;

        public EstatisticaServiceTests()
        {
            _service = new EstatisticaService();
        }

        [Fact]
        public void CalcularEstatisticas_DeveRetornarDadosCorretos()
        {
            // Arrange
            var jogador = "Luiz";
            var partidas = new List<Pontuacao>
            {
                new Pontuacao(jogador, 500, new DateTime(2025, 6, 1)),
                new Pontuacao(jogador, 700, new DateTime(2025, 6, 10)),
                new Pontuacao(jogador, 800, new DateTime(2025, 6, 20)),
                new Pontuacao(jogador, 600, new DateTime(2025, 6, 25)),
                new Pontuacao(jogador, 900, new DateTime(2025, 6, 30))
            };

            // Act
            var resultado = _service.CalcularEstatisticas(jogador, partidas);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(jogador, resultado.Jogador);
            Assert.Equal(5, resultado.PartidasJogadas);
            Assert.Equal(700, resultado.MediaPontuacao); 
            Assert.Equal(900, resultado.MaiorPontuacao);
            Assert.Equal(500, resultado.MenorPontuacao);
            Assert.Equal(3, resultado.VezesRecorde); 
            Assert.Equal("1 meses", resultado.TempoQueJoga);
        }

        [Fact]
        public void CalcularEstatisticas_DeveRetornarNull_SeListaVazia()
        {
            // Arrange
            var resultado = _service.CalcularEstatisticas("Jogador", new List<Pontuacao>());

            // Assert
            Assert.Null(resultado);
        }
    }
}
