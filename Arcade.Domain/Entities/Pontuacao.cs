public class Pontuacao
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Jogador { get; set; } = string.Empty;
    public int Pontos { get; set; }
    public DateTime DataPartida { get; set; }

    public Pontuacao(string jogador, int pontos, DateTime dataPartida)
    {
        Jogador = jogador;
        Pontos = pontos;
        DataPartida = dataPartida;
    }
}
