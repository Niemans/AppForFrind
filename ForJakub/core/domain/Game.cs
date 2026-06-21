using ForJakub.core.interfaces;

namespace ForJakub.core.domain;

internal readonly record struct Game 
    (ulong GameID, DateTime Time, string Comment, List<Entry> playerEntries)
    : IData
{
    public readonly List<Entry> playerEntries = playerEntries;

    public override string ToString()
    {
        return $$$"""
        Game: { {{{nameof(GameID)}}}: {{{GameID}}}, {{{nameof(Time)}}}: {{{Time}}}, {{{nameof(Comment)}}}: {{{Comment}}}, {{{nameof(playerEntries)}}}: {
            {{{string.Join("\n    ", playerEntries.Select(entry => entry.ToString()))}}} }}
        """;
    }
}