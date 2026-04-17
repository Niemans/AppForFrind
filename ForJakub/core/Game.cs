using System;
using System.Collections.Generic;
using System.Text;

namespace ForJakub.core
{
    internal class Game
    {
        public required long ID { get; init; }
        public required DateTime Time { get; init; }
        public string Comment { get; set; }

        public required List<Entry> players;

    }
}
