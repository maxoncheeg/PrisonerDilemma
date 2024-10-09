namespace PrisonerDilemma.Bots;

public class RandomBot : IBot
{
    
    private readonly Random _random = new();
    private readonly double _trueChance;

    public RandomBot(double trueChance)
    {
        if (trueChance <= 0 || trueChance >= 1) throw new ArgumentException("trueChance > 0 and trueChance < 1");
        _trueChance = trueChance;
    }

    public bool GetAnswer()
    {
        return _random.NextDouble() < _trueChance;
    }
}