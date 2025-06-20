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

        public Pontuacao? ObterPorId(Guid id)
        {
            return _pontuacoes.FirstOrDefault(p => p.Id == id);
        }

        public void Atualizar(Guid id, Pontuacao novaPontuacao)
        {
            var existente = _pontuacoes.FirstOrDefault(p => p.Id == id);
            if (existente != null)
            {
                existente.Jogador = novaPontuacao.Jogador;
                existente.Pontos = novaPontuacao.Pontos;
                existente.DataPartida = novaPontuacao.DataPartida;
            }
        }

        public void Remover(Guid id)
        {
            var existente = _pontuacoes.FirstOrDefault(p => p.Id == id);
            if (existente != null)
            {
                _pontuacoes.Remove(existente);
            }
        }
    }
}
