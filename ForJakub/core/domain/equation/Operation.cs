namespace ForJakub.core.domain.equation;

public class Operation
{
    private Func<double[], double> GetOperator(string input)
    {
        return input switch
        {
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
            _           => throw new ArgumentOutOfRangeException(nameof(input), input, "Not known operator")
        };
    }
}