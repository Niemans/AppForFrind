using System.Text.RegularExpressions;

namespace ForJakub.core.domain.equation;

internal record Equation
{
    public readonly List<Token> tokens = [];
    
    public Equation(string input)
    {
        Lexer(input);
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

        List<(int start, int end)> operatorsPlaces = 
        [..
            operatorIndexesDict.SelectMany(t => t.Value, (t, op) => (op, t.Key.Length))
        ];
        HashSet<int> uniqueIndexes = [0];
        uniqueIndexes.UnionWith(operatorsPlaces.Select(res => res.start));
        uniqueIndexes.UnionWith(operatorsPlaces.Select(res => res.start + res.end));
        uniqueIndexes = [.. uniqueIndexes.OrderBy(i => i)];

        var uIndexesList = uniqueIndexes.ToList();
        for (var i = 0; i < uIndexesList.Count - 1; i++)
        {
            tokens.Add(new Token(equation[uIndexesList[i]..uIndexesList[i + 1]]));
        }
        tokens.Add(new Token(equation[uIndexesList[^1]..]));
    }

    //shunting yard algorithm
    private void Parser()
    {
        List<Token> output = [];
        Stack<Token> operatorsStack = [];
        
        foreach (var token in tokens)
        {
            
        }
    }
}