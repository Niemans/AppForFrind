namespace ForJakub.core
{
    internal class Games
    {
        public readonly List<Game> games;

        public readonly Dictionary<Player, List<Game>> peopleGamesHistory;

        public Games()
        {
            games = new();
            peopleGamesHistory = new();
        }


    }
}