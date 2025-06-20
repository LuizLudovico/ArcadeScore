using Xunit;

namespace Arcade.Domain.Tests.Entities;

public class PontuacaoTests
{
    [Fact]
    public void CriarPontuacao_Valida_DevePreencherPropriedades()
    {
        // Arrange
        var jogador = "Luiz";
        var pontos = 1200;
        var dataPartida = DateTime.Now;

        // Act
        var pontuacao = new Pontuacao(jogador, pontos, dataPartida);

        // Assert
        Assert.Equal(jogador, pontuacao.Jogador);
        Assert.Equal(pontos, pontuacao.Pontos);
        Assert.Equal(dataPartida, pontuacao.DataPartida);
        Assert.NotEqual(Guid.Empty, pontuacao.Id); 
    }
}