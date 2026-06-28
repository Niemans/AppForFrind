using System.Globalization;
using static System.Double;

namespace ForJakub.core.domain.equation;

public class Token
{
    public readonly Func<double[], double> operation;
    private readonly double _value;
    public static readonly HashSet<string> Operators =
    [
        "sin",
        "log",
        "log10",
        "^",
        "*",
        "/",
        "%",
        "+",
        "-",
        "-x"
    ];

    public Token(string tokenString)
    {
        operation = GetOperator(TryParse(tokenString, out var parsed) ? "number" : tokenString);
        _value = parsed;
    }
    
    
    private Token(double value)
    {
        operation = GetOperator(value.ToString(CultureInfo.InvariantCulture));
        _value = value;
    }

    private Func<double[], double> GetOperator(string input)
    {
        return input switch
        {
            "number"    => _ => _value,
            "sin"       => a => Math.Sin(a[0]),
            "log"       => a => Math.Log(a[0], a[1]),
            "log10"     => a => Math.Log10(a[0]),
            "^"         => a => Math.Pow(a[0], a[1]),
            "*"         => a => a[0] * a[1],
            "/"         => a => a[0] / a[1],
            "%"         => a => a[0] % a[1],
            "+"         => a => a[0] + a[1],
            "-"         => a => a[0] - a[1],
            "-x"        => a => -a[0],
            _           => _ => 0.0
        };
    }

    public static implicit operator Token(double value) => new(value);
    public static implicit operator double(Token token) => token._value;
}