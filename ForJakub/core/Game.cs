using ForJakub.core.interfaces;

namespace ForJakub.core
{
    internal class Game 
        (ulong gameId, DateTime time, string comment, List<Entry> entries)
        : IData
    {
        public ulong GameID { get; init; } = gameId;
        public DateTime Time { get; init; } = time;
        public string Comment { get; set; } = comment;

        public List<Entry> playerEntries = entries;
    }
}
