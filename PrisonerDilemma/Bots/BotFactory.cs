namespace PrisonerDilemma.Bots;

public class BotFactory : IBotFactory
{
    private readonly IDictionary<string, IBot> _bots;
    
    public BotFactory(IDictionary<string, IBot> bots)
    {
        if (bots.Count <= 0) throw new ArgumentException("bots count <= 0");

        _bots = bots;
    }
    
    public IBot? GetBot(string name)
    {
        return _bots.TryGetValue(name, out var bot) ? bot : null;
    }
}