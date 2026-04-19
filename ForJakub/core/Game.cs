using ForJakub.core.interfaces;

namespace ForJakub.core
{
    internal class Game : IData
    {
        public required ulong GameID { get; init; }
        public required DateTime Time { get; init; }
        public required string Comment { get; set; }

        public required List<Entry> playerEntries = [];

    }
}
