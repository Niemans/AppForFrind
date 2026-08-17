
using static System.Double;

namespace ForJakub.core.domain.equation;

public class Token
{
    public EType Type { get; }
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
            Type = EType.Operation;
            _operator =  op;
        }
        else if (TryParse(tokenString, out var parsedValue))
        {
            Type = EType.Number;
            _numberValue = parsedValue;
        }
        else
        {
            Type = EType.Variable;
            _variableName = tokenString;
        }
    }

    public override string ToString()
    {
        return Type switch
        {
            EType.Operation => _operator?.Name ?? "_o_",
            EType.Number => _numberValue.ToString() != null ? $"Number({_numberValue})" : "_n_",
            EType.Variable => _variableName ?? "_v_",
            _ => "_t_"
        };
    }

    public string ToSimpleString()
    {
        return Type switch
        {
            EType.Operation => _operator?.Sign ?? "_o_",
            EType.Number => _numberValue.ToString() ?? "_n_",
            EType.Variable => _variableName ?? "_v_",
            _ => "_t_"
        };
    }

    //TODO: change from X to X?
    public string? GetOperatorSign() => _operator?.Sign;
    public int? GetOperatorValue() => _operator?.Value;
    public bool? GetOperatorLeftAssociative() => _operator?.AssociativityLeft;
    
    public enum EType
    {
        Operation,
        Number,
        Variable
    }
}