namespace PrisonerDilemma.Game;

public interface IGameSettings
{
    public double SuccessPoints { get; set; }
    public double FailurePoints { get; set; }
    public double HalfSuccessPoints { get; set; }
}