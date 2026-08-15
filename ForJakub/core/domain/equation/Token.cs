
using static System.Double;

namespace ForJakub.core.domain.equation;

public class Token
{
    private EType _EType { get; }
    private readonly double? _numberValue;
    private readonly string? _variableName;
    private readonly Operator? _operator;
    
    public Token(string tokenString)
    {
        _operator = null;
        _numberValue = null;
        _variableName = null;
        
        if (Operators.Ops.TryGetValue(tokenString, out var op))
        {
            _EType = EType.Operation;
            _operator =  op;
        }
        else if (TryParse(tokenString, out var parsedValue))
        {
            _EType = EType.Number;
            _numberValue = parsedValue;
        }
        else
        {
            _EType = EType.Variable;
            _variableName = tokenString;
        }
    }
    
    private Token(double numberValue)
    {
        _EType = EType.Number;
        _numberValue = numberValue;
    }

    public override string ToString()
    {
        return _EType switch
        {
            EType.Operation => _operator!.Value.Name,
            EType.Number => "Number(" + _numberValue + ")",
            EType.Variable => _variableName!,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public static implicit operator Token(double value) => new(value);
    public static implicit operator double?(Token token) => token._numberValue;

    private enum EType
    {
        Operation,
        Number,
        Variable
    }
}