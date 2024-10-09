using PrisonerDilemma.Players;

namespace PrisonerDilemma.Game;

public interface IGame
{
    public IGameSettings Settings { get; }
    public IPlayer FirstPlayer { get; }
    public IPlayer SecondPlayer { get; }
    
    public bool MakeChoice(bool firstChoice, bool secondChoice);
}