namespace ForJakub.core
{
    internal class Games
    {
        public readonly List<Game> games;

        public readonly Dictionary<Person, List<Game>> peopleGamesHistory;

        public Games()
        {
            games = new();
            peopleGamesHistory = new();
        }


    }
}