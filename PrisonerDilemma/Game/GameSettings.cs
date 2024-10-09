namespace PrisonerDilemma.Game;

public class GameSettings : IGameSettings
{
    public double SuccessPoints { get; set; } = 2;
    public double FailurePoints { get; set; } = 0;
    public double HalfSuccessPoints { get; set; } = 1;
}