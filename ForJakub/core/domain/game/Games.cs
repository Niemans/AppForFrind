namespace ForJakub.core.domain.game;

internal class Games
{
    public readonly List<Game> games = new();

    public readonly Dictionary<Player, List<Game>> peopleGamesHistory = new();
}