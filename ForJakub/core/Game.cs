using ForJakub.core.interdaces;
using System;
using System.Collections.Generic;
using System.Text;

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
