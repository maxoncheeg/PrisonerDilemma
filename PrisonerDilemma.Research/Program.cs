// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using PrisonerDilemma.Bots;
using PrisonerDilemma.Game;
using PrisonerDilemma.Players;

#region settings

IPlayer player1 = new Player("Игрок 1"), player2 = new Player("Игрок 2");
IGameSettings settings = new GameSettings() { SuccessPoints = 500, HalfSuccessPoints = 100, FailurePoints = 0 };
IGame game = new TimeGame(settings, player1, player2, gameTimeInMilliseconds: 1500);

IDictionary<string, IBot> bots = new Dictionary<string, IBot>()
{
    { "d", new RandomBot(0.5d) }, // типа default xDDDDD
    { "aa", new RandomBot(0.66d) },
    { "bb", new RandomBot(0.34d) }
};
IBotFactory factory = new BotFactory(bots);

#endregion

Random random = new();
var bot = factory.GetBot("d") ?? throw new ArgumentException("bot");
player2.Name = "Игрок 2";

int n = 500;
var gameTime = TimeSpan.FromMinutes(25d);

Console.WriteLine("Напишите свой паттерн (Например, 1101101): ");
string pattern = Console.ReadLine() ?? throw new ArgumentException("pattern");
if (!Regex.IsMatch(pattern, @"^[10]+$")) throw new ArgumentException("pattern");

int index = 0;

bool playerChoice = pattern[index++] == '1';
bool botChoice = bot.GetAnswer();

while (game.MakeChoice(playerChoice, botChoice))
{
    if (index >= pattern.Length) index = 0;
    
    await Task.Delay(TimeSpan.FromMilliseconds(5 + random.NextDouble() * 5));
    playerChoice = pattern[index++] == '1';
    botChoice = bot.GetAnswer();
}

Console.Clear();
Console.WriteLine("ИГРА ОКОНЧЕНА!");
Console.WriteLine($"\t{game.FirstPlayer.Name} - {game.FirstPlayer.Points}");
Console.WriteLine($"\t{game.SecondPlayer.Name} - {game.SecondPlayer.Points}");

Console.Write(game.FirstPlayer.Name + ": ");
foreach (var choice in game.FirstPlayer.Choices) Console.Write(choice ? "1" : "0");
Console.Write("\n" + game.SecondPlayer.Name + ": ");
foreach (var choice in game.SecondPlayer.Choices) Console.Write(choice ? "1" : "0");