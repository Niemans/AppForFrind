using ForJakub.core.domain.equation;

const string a = "21+(89-56)";
Console.WriteLine(a);
var e = new Equation(a);
Console.WriteLine(string.Join("\t", e.tokens));