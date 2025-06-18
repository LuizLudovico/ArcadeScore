namespace Arcade.Domain.Entities
{
    public class Pontuacao
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Jogador { get; set; } = string.Empty;
        public int Pontos { get; set; }
        public DateTime DataPartida { get; set; }
    }
}
