namespace ForJakub.core
{
    internal class Games
    {
        public readonly List<Game> games = new();

        public readonly Dictionary<Player, List<Game>> peopleGamesHistory = new();
        
    }
}