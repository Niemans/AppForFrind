namespace ForJakub.core.domain.equation;

public readonly struct Operator(string sign, string name, int value, bool associativityLeft = true) : IEquatable<Operator>
{
    public string Sign { get; } = sign;
    public string Name { get; } = name;
    public int Value { get; } = value;
    public bool AssociativityLeft { get; } = associativityLeft;
    
    public override int GetHashCode() => HashCode.Combine(Sign);
    public bool Equals(Operator other) => string.Equals(Sign, other.Sign) && string.Equals(Name, other.Name);
    public override bool Equals(object? obj) => obj is Operator other && Equals(other);
    
    public static bool operator ==(Operator a, Operator b) => string.Equals(a.Sign, b.Sign);
    public static bool operator !=(Operator a, Operator b) => !(a == b);
    public static bool operator ==(Operator a, string b) => string.Equals(a.Sign, b) || string.Equals(a.Name, b);
    public static bool operator !=(Operator a, string b) => !(a == b);
    public static bool operator ==(Operator a, int b) => a.Value == b;
    public static bool operator !=(Operator a, int b) => !(a == b);
}