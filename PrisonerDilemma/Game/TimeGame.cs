using PrisonerDilemma.Players;

namespace PrisonerDilemma.Game;

public class TimeGame : IGame
{
    private readonly double _gameTimeInMilliseconds;
    private DateTime? _startedAt;
    
    public IGameSettings Settings { get; }
    public IPlayer FirstPlayer { get; }
    public IPlayer SecondPlayer { get; }

    public TimeGame(IGameSettings settings, IPlayer firstPlayer, IPlayer secondPlayer, double gameTimeInMilliseconds)
    {
        if (firstPlayer.Name == secondPlayer.Name) throw new ArgumentException("ну как так!");

        Settings = settings;
        FirstPlayer = firstPlayer;
        SecondPlayer = secondPlayer;
        _gameTimeInMilliseconds = gameTimeInMilliseconds;
    }
    
    public bool MakeChoice(bool firstChoice, bool secondChoice)
    {
        _startedAt ??= DateTime.Now;
        
        FirstPlayer.AddChoice(firstChoice);
        SecondPlayer.AddChoice(secondChoice);

        if (firstChoice == secondChoice)
        {
            if (firstChoice)
            {
                FirstPlayer.Points += Settings.HalfSuccessPoints;
                SecondPlayer.Points += Settings.HalfSuccessPoints;
            }
            else
            {
                FirstPlayer.Points += Settings.FailurePoints;
                SecondPlayer.Points += Settings.FailurePoints;
            }
        }
        else
        {
            if (firstChoice)
            {
                FirstPlayer.Points += Settings.FailurePoints;
                SecondPlayer.Points += Settings.SuccessPoints;
            }
            else
            {
                FirstPlayer.Points += Settings.SuccessPoints;
                SecondPlayer.Points += Settings.FailurePoints;
            }
        }

        return _startedAt + TimeSpan.FromMilliseconds(_gameTimeInMilliseconds) > DateTime.Now;
    }
}