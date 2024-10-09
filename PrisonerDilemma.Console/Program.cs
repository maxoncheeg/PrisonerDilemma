// See https://aka.ms/new-console-template for more information

using PrisonerDilemma.Bots;
using PrisonerDilemma.Game;
using PrisonerDilemma.Players;

#region settings

IPlayer player1 = new Player("Sergio"), player2 = new Player("Denix");
IGameSettings settings = new GameSettings() { SuccessPoints = 500, HalfSuccessPoints = 100, FailurePoints = 0 };
IGame game = new TimeGame(settings, player1, player2, gameTimeInMilliseconds: 1 * 60 * 1000);

IDictionary<string, IBot> bots = new Dictionary<string, IBot>()
{
    { "d", new RandomBot(0.5d) }, // типа default xDDDDD
    { "aa", new RandomBot(0.66d) },
    { "bb", new RandomBot(0.34d) }
};
IBotFactory factory = new BotFactory(bots);

double botTimeoutInSeconds = 3d;
Random random = new();

#endregion


Console.Write("Выберите тип игрока: ");
var input = Console.ReadLine();
var bot = factory.GetBot(input ?? throw new ArgumentNullException(nameof(input))) ??
          throw new ArgumentNullException($"bot");


Console.WriteLine("ПОИСК ИГРОКА В СЕТИ...");
await Task.Delay(TimeSpan.FromSeconds(random.NextDouble() * 20));

bool playerChoice, botChoice;
do
{
    Console.Clear();

    Console.WriteLine("ДЕНЬГИ:");
    Console.WriteLine($"\t{game.FirstPlayer.Name} - {game.FirstPlayer.Points} RUB");
    Console.WriteLine($"\t{game.SecondPlayer.Name} - {game.SecondPlayer.Points} RUB");

    Console.Write("\n\n\tДелайте выбор: ");
    var choiceKey = Console.ReadKey().Key;
    playerChoice = choiceKey != ConsoleKey.D0;

    Console.WriteLine($"\n\n\t{game.SecondPlayer.Name} думает...");
    await Task.Delay(TimeSpan.FromSeconds(random.NextDouble() * botTimeoutInSeconds));
    botChoice = bot.GetAnswer();
} while (game.MakeChoice(playerChoice, botChoice));


Console.Clear();
Console.WriteLine("ИГРА ОКОНЧЕНА!");
Console.WriteLine($"\t{game.FirstPlayer.Name} - {game.FirstPlayer.Points}");
Console.WriteLine($"\t{game.SecondPlayer.Name} - {game.SecondPlayer.Points}");

Console.Write(game.FirstPlayer.Name + ": ");
foreach (var choice in game.FirstPlayer.Choices) Console.Write(choice ? "1" : "0");
Console.Write("\n" + game.SecondPlayer.Name + ": ");
foreach (var choice in game.SecondPlayer.Choices) Console.Write(choice ? "1" : "0");