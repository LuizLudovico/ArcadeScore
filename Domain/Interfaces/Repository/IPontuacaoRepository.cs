using Arcade.Domain.Entities;

namespace Arcade.Domain.Interfaces.Repository
{
    public interface IPontuacaoRepository
    {
        void Adicionar(Pontuacao pontuacao);
        List<Pontuacao> ObterTop10();
        List<Pontuacao> ObterPorJogador(string jogador);
    }
}
