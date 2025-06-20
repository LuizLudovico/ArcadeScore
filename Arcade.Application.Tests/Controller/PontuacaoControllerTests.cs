using Arcade.Application.Controllers;
using Arcade.Domain.DTOs;
using Arcade.Domain.Interfaces.Repository;
using Arcade.Service.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace Arcade.Application.Tests.Controller
{
    public class PontuacaoControllerTests
    {
        private readonly IPontuacaoRepository _repository;
        private readonly PontuacaoController _controller;
        private readonly EstatisticaService _estatisticaService;

        public PontuacaoControllerTests()
        {
            _repository = Substitute.For<IPontuacaoRepository>();
            _estatisticaService = Substitute.For<EstatisticaService>(); 
            _controller = new PontuacaoController(_repository, _estatisticaService); 
        }

        [Fact]
        public void Registrar_DeveRetornarOkComPontuacao()
        {
            // Arrange
            var pontuacao = new Pontuacao("Luiz", 1500, new DateTime(2025, 6, 18, 15, 30, 0));

            // Act
            var resultado = _controller.Registrar(pontuacao) as OkObjectResult;

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(200, resultado!.StatusCode);
            Assert.Equal(pontuacao, resultado.Value);
            _repository.Received(1).Adicionar(pontuacao);
        }

        [Fact]
        public void Ranking_DeveRetornarTop10()
        {
            // Arrange
            var lista = new List<Pontuacao>
            {
                new Pontuacao("Luiz", 2000, DateTime.Now)
            };
            _repository.ObterTop10().Returns(lista);

            // Act
            var resultado = _controller.Ranking() as OkObjectResult;

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(200, resultado!.StatusCode);
            Assert.Equal(lista, resultado.Value);
        }      


        [Fact]
        public void AtualizarPontuacao_DeveRetornarNotFound_SeNaoExistir()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repository.ObterPorId(id).Returns((Pontuacao?)null);

            var novaPontuacao = new Pontuacao("Luiz", 1100, DateTime.Now);

            // Act
            var resultado = _controller.AtualizarPontuacao(id, novaPontuacao) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(404, resultado!.StatusCode);
        }

        [Fact]
        public void AtualizarPontuacao_DeveAtualizarERetornarOk()
        {
            // Arrange
            var id = Guid.NewGuid();
            var pontuacao = new Pontuacao("Luiz", 2000, DateTime.Now);
            _repository.ObterPorId(id).Returns(pontuacao);

            // Act
            var resultado = _controller.AtualizarPontuacao(id, pontuacao) as OkObjectResult;

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(200, resultado!.StatusCode);
            _repository.Received(1).Atualizar(id, pontuacao);
        }

        [Fact]
        public void RemoverPontuacao_DeveRetornarNotFound_SeNaoExistir()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repository.ObterPorId(id).Returns((Pontuacao?)null);

            // Act
            var resultado = _controller.RemoverPontuacao(id) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(404, resultado!.StatusCode);
        }

        [Fact]
        public void RemoverPontuacao_DeveRemoverERetornarNoContent()
        {
            // Arrange
            var id = Guid.NewGuid();
            var pontuacao = new Pontuacao("Luiz", 1000, DateTime.Now);
            _repository.ObterPorId(id).Returns(pontuacao);

            // Act
            var resultado = _controller.RemoverPontuacao(id) as NoContentResult;

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(204, resultado!.StatusCode);
            _repository.Received(1).Remover(id);
        }
    }
}