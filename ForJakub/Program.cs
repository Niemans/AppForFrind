using ForJakub.core;
using ForJakub.gateway.csv;
using ForJakub.gateway.csv.objectsCSV;

Console.WriteLine("Hello, World!");

Player p = new(1, "11", 1.1);
Player p2 = new(2, "22", 2.2);
Entry e = new(p, 11.11, -1);
Entry e2 = new(p2, 22.22, -2);
Game g = new(3, DateTime.Now, "3", [e, e2]);

var sp = new SaveCSV<Player, PlayerCSV>().Save(p);
var se = new SaveCSV<Entry, EntryCSV>().Save(e);
var sg = new SaveCSV<Game, GameCSV>().Save(g);

Console.WriteLine($"{p}\n{sp}");
Console.WriteLine($"{e}\n{se}");
Console.WriteLine($"{g}\n{sg}");
