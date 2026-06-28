using System.Buffers;
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
        [
            ..
            Token.Operators
                .Where(equation.Contains)
                .Select(c => c)
        ];

        var dict = operators.ToDictionary(op => op, _ => new List<int>());
        var matches = Regex.Matches(equation, string.Join("|", operators.Select(Regex.Escape)));
        foreach (Match match in matches)
        {
            dict[match.Value].Add(match.Index);
        }

        List<(int start, int end)> operatorsPlaces = [..dict.SelectMany(t => t.Value, (t, op) => (op, t.Key.Length))];
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
}