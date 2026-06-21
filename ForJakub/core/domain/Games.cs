namespace ForJakub.core.domain;

internal class Games
{
    public readonly List<Game> games = new();

    public readonly Dictionary<Player, List<Game>> peopleGamesHistory = new();
        
}