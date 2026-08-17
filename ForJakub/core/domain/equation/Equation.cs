using System.Text.RegularExpressions;

namespace ForJakub.core.domain.equation;

internal record Equation
{
    public readonly List<Token> tokens = [];
    public readonly Queue<Token> parserQueue = [];
    
    public Equation(string input)
    {
        Lexer(input);
        Parser();
    }

    private void Lexer(string input)
    {
        var equation = string.Concat(input.Where(c => !char.IsWhiteSpace(c))).ToLower();

        List<string> operators =
        [..
            Operators.Ops
                .Where(op => equation.Contains(op.Key))
                .Select(op => op.Value.Sign)
        ];
        
        var operatorIndexesDict = operators.ToDictionary(op => op, _ => new List<int>());
        var matches = Regex.Matches(equation, string.Join("|", operators.Select(Regex.Escape)));
        foreach (Match match in matches)
        {
            operatorIndexesDict[match.Value].Add(match.Index);
        }

        List<(int start, int length)> operatorsPlaces = 
        [..
            operatorIndexesDict.SelectMany(t => t.Value, (t, op) => (op, t.Key.Length))
        ];
        HashSet<int> uniqueIndexes = [0];
        uniqueIndexes.UnionWith(operatorsPlaces.Select(res => res.start));
        uniqueIndexes.UnionWith(operatorsPlaces.Select(res => res.start + res.length));
        uniqueIndexes = [.. uniqueIndexes.OrderBy(i => i)];

        var uIndexesList = uniqueIndexes.ToList();
        for (var i = 0; i < uIndexesList.Count - 1; i++)
        {
            tokens.Add(new Token(equation[uIndexesList[i]..uIndexesList[i + 1]]));
        }
    }

    //shunting yard algorithm
    private void Parser()
    {
        parserQueue.Clear();
        Stack<Token> operatorStack = [];
        
        foreach (var token in tokens)
        {
            switch (token.Type)
            {
                case Token.EType.Number:
                case Token.EType.Variable:
                    parserQueue.Enqueue(token);
                    break;
                case Token.EType.Operation:
                    if (token.GetOperatorSign() == null)
                    {
                        throw new InvalidOperationException("Operation without Operator");
                    }
                    
                    if (operatorStack.Count == 0 || token.GetOperatorSign()!.Equals("("))
                    {
                        operatorStack.Push(token);
                        break;
                    }
                    
                    if (token.GetOperatorSign()!.Equals(")"))
                    {
                        while (operatorStack.Count != 0 && !operatorStack.Peek().GetOperatorSign()!.Equals("("))
                        {
                            var op = operatorStack.Pop();
                            parserQueue.Enqueue(op);
                        }

                        if (operatorStack.Count != 0)
                        {
                            operatorStack.Pop();
                        }
                        break;
                    }
                    
                    while (operatorStack.Count != 0 
                        && operatorStack.Peek().GetOperatorSign() != "("
                        && (token.GetOperatorValue() < operatorStack.Peek().GetOperatorValue()
                        || (token.GetOperatorLeftAssociative()!.Value 
                            && token.GetOperatorValue() == operatorStack.Peek().GetOperatorValue())))
                    {
                        var op = operatorStack.Pop();
                        parserQueue.Enqueue(op);
                    }
                    operatorStack.Push(token);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        while (operatorStack.Count != 0)
        {
            var op = operatorStack.Pop();
            parserQueue.Enqueue(op);
        }
    }
}