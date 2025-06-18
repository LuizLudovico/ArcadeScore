using Arcade.Domain.Entities;
using Arcade.Domain.Interfaces.Repository;

namespace Arcade.Service.Services
{
    public class InMemoryPontuacaoRepository : IPontuacaoRepository
    {
        private readonly List<Pontuacao> _pontuacoes = new();

        public void Adicionar(Pontuacao pontuacao)
        {
            _pontuacoes.Add(pontuacao);
        }

        public List<Pontuacao> ObterTop10()
        {
            return _pontuacoes.OrderByDescending(p => p.Pontos).Take(10).ToList();
        }

        public List<Pontuacao> ObterPorJogador(string jogador)
        {
            return _pontuacoes
                .Where(p => p.Jogador.Equals(jogador, StringComparison.OrdinalIgnoreCase))
                .OrderBy(p => p.DataPartida)
                .ToList();
        }
    }
}
