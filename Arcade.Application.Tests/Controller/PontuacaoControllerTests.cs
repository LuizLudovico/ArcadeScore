using Arcade.Application.Controllers;
using Arcade.Domain.Entities;
using Arcade.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace Arcade.Application.Tests.Controller
{
    public class PontuacaoControllerTests
    {
        private readonly IPontuacaoRepository _repository;
        private readonly PontuacaoController _controller;

        public PontuacaoControllerTests()
        {
            _repository = Substitute.For<IPontuacaoRepository>();
            _controller = new PontuacaoController(_repository);
        }

        [Fact]
        public void Registrar_DeveRetornarOkComPontuacao()
        {
            var pontuacao = new Pontuacao
            {
                Jogador = "Luiz",
                Pontos = 1500,
                DataPartida = new DateTime(2025, 6, 18, 15, 30, 0)
            };

            var resultado = _controller.Registrar(pontuacao) as OkObjectResult;

            Assert.NotNull(resultado);
            Assert.Equal(200, resultado!.StatusCode); 
            Assert.Equal(pontuacao, resultado.Value);
            _repository.Received(1).Adicionar(pontuacao);
        }

        [Fact]
        public void Ranking_DeveRetornarTop10()
        {
            var lista = new List<Pontuacao> { new Pontuacao { Jogador = "Luiz", Pontos = 2000 } };
            _repository.ObterTop10().Returns(lista);

            var resultado = _controller.Ranking() as OkObjectResult;

            Assert.NotNull(resultado);
            Assert.Equal(200, resultado!.StatusCode); 
            Assert.Equal(lista, resultado.Value);
        }

        [Fact]
        public void Estatisticas_DeveRetornarNotFound_QuandoJogadorNaoExiste()
        {
            _repository.ObterPorJogador("Inexistente").Returns(new List<Pontuacao>());

            var resultado = _controller.Estatisticas("Inexistente") as NotFoundObjectResult;

            Assert.NotNull(resultado);
            Assert.Equal(404, resultado!.StatusCode); 
        }

        [Fact]
        public void Estatisticas_DeveRetornarEstatisticasCompletas()
        {
            var partidas = new List<Pontuacao>
                {
                    new Pontuacao { Jogador = "Luiz", Pontos = 1000, DataPartida = DateTime.Now.AddDays(-2) },
                    new Pontuacao { Jogador = "Luiz", Pontos = 1500, DataPartida = DateTime.Now }
                };

            _repository.ObterPorJogador("Luiz").Returns(partidas);

            var resultado = _controller.Estatisticas("Luiz") as OkObjectResult;

            Assert.NotNull(resultado);
            Assert.Equal(200, resultado!.StatusCode); 
        }

        [Fact]
        public void AtualizarPontuacao_DeveRetornarNotFound_SeNaoExistir()
        {
            var id = Guid.NewGuid();
            _repository.ObterPorId(id).Returns((Pontuacao?)null); 

            var resultado = _controller.AtualizarPontuacao(id, new Pontuacao()) as NotFoundObjectResult;

            Assert.NotNull(resultado);
            Assert.Equal(404, resultado!.StatusCode);
        }

        [Fact]
        public void AtualizarPontuacao_DeveAtualizarERetornarOk()
        {
            var id = Guid.NewGuid();
            var pontuacao = new Pontuacao { Jogador = "Luiz", Pontos = 2000 };
            _repository.ObterPorId(id).Returns(pontuacao);

            var resultado = _controller.AtualizarPontuacao(id, pontuacao) as OkObjectResult;

            Assert.NotNull(resultado);
            Assert.Equal(200, resultado!.StatusCode); 
            _repository.Received(1).Atualizar(id, pontuacao);
        }

        [Fact]
        public void RemoverPontuacao_DeveRetornarNotFound_SeNaoExistir()
        {
            var id = Guid.NewGuid();
            _repository.ObterPorId(id).Returns((Pontuacao?)null);

            var resultado = _controller.RemoverPontuacao(id) as NotFoundObjectResult;

            Assert.NotNull(resultado);
            Assert.Equal(404, resultado!.StatusCode);
        }

        [Fact]
        public void RemoverPontuacao_DeveRemoverERetornarNoContent()
        {
            var id = Guid.NewGuid();
            var pontuacao = new Pontuacao { Jogador = "Luiz", Pontos = 1000 };
            _repository.ObterPorId(id).Returns(pontuacao);

            var resultado = _controller.RemoverPontuacao(id) as NoContentResult;

            Assert.NotNull(resultado);
            Assert.Equal(204, resultado!.StatusCode);
            _repository.Received(1).Remover(id);
        }
    }
}