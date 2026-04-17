using ForJakub.core;

Console.WriteLine("Hello, World!");

var p = new Person { ID = 2, Name = "asd", Points = 12.234 };
var p2 = new Person { ID = 123123, Name = "qwe", Points = -678.456 };
var s = new SaveCSV();
var b = s.Save(p);
var b2 = s.Save(p2);

Console.WriteLine("asd  " + b + b2);