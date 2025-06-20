using Arcade.Service.Services;
using Xunit;

namespace Arcade.Domain.Tests.Entities;

public class InMemoryPontuacaoRepositoryTests
{
    [Fact]
    public void Adicionar_DeveAdicionarPontuacaoNaLista()
    {
        // Arrange
        var repo = new InMemoryPontuacaoRepository();
        var pontuacao = new Pontuacao("Jogador1", 1000, DateTime.Now);

        // Act
        repo.Adicionar(pontuacao);
        var resultado = repo.ObterPorJogador("Jogador1");

        // Assert
        Assert.Single(resultado);
        Assert.Equal(1000, resultado[0].Pontos);
    }

    [Fact]
    public void ObterTop10_DeveRetornar10MaioresPontuacoes()
    {
        // Arrange
        var repo = new InMemoryPontuacaoRepository();

        for (int i = 1; i <= 15; i++)
            repo.Adicionar(new Pontuacao($"Jogador{i}", i * 100, DateTime.Now));

        // Act
        var top10 = repo.ObterTop10();

        // Assert
        Assert.Equal(10, top10.Count);
        Assert.Equal(1500, top10.First().Pontos);
    }

    [Fact]
    public void ObterPorJogador_DeveRetornarPartidasOrdenadasPorData()
    {
        // Arrange
        var repo = new InMemoryPontuacaoRepository();
        var jogador = "JogadorTeste";

        var partida1 = new Pontuacao(jogador, 800, new DateTime(2025, 6, 10));
        var partida2 = new Pontuacao(jogador, 1200, new DateTime(2025, 6, 15));
        var partida3 = new Pontuacao(jogador, 900, new DateTime(2025, 6, 12));

        repo.Adicionar(partida1);
        repo.Adicionar(partida2);
        repo.Adicionar(partida3);

        // Act
        var partidas = repo.ObterPorJogador(jogador);

        // Assert
        Assert.Equal(3, partidas.Count);
        Assert.Equal(800, partidas[0].Pontos);  
        Assert.Equal(900, partidas[1].Pontos);
        Assert.Equal(1200, partidas[2].Pontos); 
    }
}