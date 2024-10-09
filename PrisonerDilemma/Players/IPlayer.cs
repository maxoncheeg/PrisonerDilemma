namespace PrisonerDilemma.Players;

public interface IPlayer
{
    public string Name { get; set; }
    public double Points { get; set; }
    public IReadOnlyList<bool> Choices { get; }

    public void AddChoice(bool choice);
}