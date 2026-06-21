using ForJakub.core.interfaces;

namespace ForJakub.core.domain;

internal sealed record Game 
    (ulong GameID, DateTime Time, string Comment, List<Entry> playerEntries)
    : IData
{
    public string Comment { get; set; } = Comment;

    public readonly List<Entry> playerEntries = playerEntries;

    public bool Equals(Game? other)
    {
        if (other is null) return false;
        return GameID == other.GameID 
               && Time == other.Time 
               && Comment == other.Comment
               && playerEntries.SequenceEqual(other.playerEntries);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GameID, Time, playerEntries);
    }
}