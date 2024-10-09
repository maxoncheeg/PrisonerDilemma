namespace PrisonerDilemma.Players;

public class Player(string name) : IPlayer
{
    private readonly List<bool> _choices = [];
    
    public string Name { get; set; } = name;
    public double Points { get; set; }
    public IReadOnlyList<bool> Choices => _choices;
    
    public void AddChoice(bool choice)
    {
        _choices.Add(choice);
    }
}