using ForJakub.core.domain.game;

namespace ForJakub.core.utilities;

internal static class GameUtilities
{
    public static List<Game> GroupGames(this IEnumerable<Game> games)
    {
        return [.. games
            .GroupBy(g => new {g.GameID, g.Comment, g.Time})
            .Select(group => new Game(
                GameID: group.Key.GameID,
                Time: group.Key.Time,
                Comment: group.Key.Comment,
                playerEntries: [.. group.SelectMany(game =>  game.playerEntries)]
            ))];
    }
}