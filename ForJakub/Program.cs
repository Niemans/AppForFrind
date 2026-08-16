using ForJakub.core.domain.equation;

const string a = "21+(89-56)*(21/34)";
var e = new Equation(a);
Console.WriteLine("1: " + a);
Console.WriteLine("2: " + string.Join("\t", e.tokens));
Console.WriteLine("3: " + string.Join("\t", e.parserQueue));
Console.WriteLine("3: " + string.Join("\t", e.parserQueue.Select(t => t.ToSimpleString())));