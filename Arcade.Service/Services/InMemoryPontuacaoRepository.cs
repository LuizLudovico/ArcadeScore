using Arcade.Domain.Interfaces.Repository;

namespace Arcade.Service.Services
{
    public class InMemoryPontuacaoRepository : IPontuacaoRepository
    {
        private readonly List<Pontuacao> _pontuacoes;

        public InMemoryPontuacaoRepository()
        {
            _pontuacoes = new List<Pontuacao>
            {                
                new Pontuacao("Ludovico", 200, DateTime.UtcNow.AddDays(-5)),
                new Pontuacao("Ludovico", 300, DateTime.UtcNow.AddDays(-3)),
                new Pontuacao("Ludovico", 350, DateTime.UtcNow.AddDays(-1)),
               
                new Pontuacao("Machado", 270, DateTime.UtcNow.AddDays(-4)),
                new Pontuacao("Machado", 270, DateTime.UtcNow.AddDays(-2)),
                
                new Pontuacao("Beatriz", 100, DateTime.UtcNow.AddDays(-10)),
                new Pontuacao("Beatriz", 200, DateTime.UtcNow.AddDays(-8)),
                new Pontuacao("Beatriz", 300, DateTime.UtcNow.AddDays(-6)),
                new Pontuacao("Beatriz", 400, DateTime.UtcNow.AddDays(-2)),

                
                new Pontuacao("João", 320, DateTime.UtcNow.AddDays(-6)),
               
                new Pontuacao("Marina", 250, DateTime.UtcNow.AddDays(-7)),
                new Pontuacao("Marina", 410, DateTime.UtcNow.AddDays(-2))
            };
        }

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
