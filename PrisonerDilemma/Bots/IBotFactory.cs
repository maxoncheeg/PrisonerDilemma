namespace PrisonerDilemma.Bots;

public interface IBotFactory
{
    public IBot? GetBot(string name);
}