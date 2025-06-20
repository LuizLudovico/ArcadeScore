namespace Arcade.Domain.DTOs
{
    public class EstatisticaJogadorDto
    {
        public string Jogador { get; set; }
        public int PartidasJogadas { get; set; }
        public double MediaPontuacao { get; set; }
        public int MaiorPontuacao { get; set; }
        public int MenorPontuacao { get; set; }
        public int VezesRecorde { get; set; }
        public string TempoQueJoga { get; set; }
    }
}
