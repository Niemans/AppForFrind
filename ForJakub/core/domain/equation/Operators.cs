namespace ForJakub.core.domain.equation;

public static class Operators
{
    public static Dictionary<string, Operator> Ops { get; } = new()
    {
        { "(", new("(", "Left Parenthesis", 1000) },
        { ")", new(")", "Right Parenthesis", 1000) },

        { "^", new("^", "Power", 100, false) },

        { "sin", new("sin", "Sin", 90) },
        { "cos", new("cos", "Cos", 90) },
        { "tan", new("tan", "Tan", 90) },
        { "log", new("log", "log", 90) },
        { "log10", new("sqrt", "Sqrt", 90) },

        { "*", new("*", "Multiply", 80) },
        { "/", new("/", "Divide", 80) },
        { "%", new("%", "Modulo", 80) },

        { "+", new("+", "Plus", 70) },
        { "-", new("-", "Minus", 70) },
    };
    
}