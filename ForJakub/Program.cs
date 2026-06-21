using ForJakub.core;
using ForJakub.core.domain;
using ForJakub.gateway.csv;
using ForJakub.gateway.csv.objectsCSV;
using ForJakub.gateway.interfaces;

Console.WriteLine("Hello, World!");

Player p = new(1, "11", 1.1);
Player p2 = new(2, "22", 2.2);
Entry e = new(p, 11.11, -1);
Entry e2 = new(p2, 22.22, -2);
Game g = new(3, DateTime.Now, "3", [e, e2]);

IHandler<Player> hp = new HandlerCSV<Player, PlayerCSV>();
IHandler<Entry> he =  new HandlerCSV<Entry, EntryCSV>();
IHandler<Game> hg = new HandlerCSV<Game, GameCSV>();

hp.SaveAll([p, p2]);
he.SaveAll([e, e2]);
hg.Save(g);

var ps = hp.Read();
var es = he.Read();
var gs = hg.Read();

Console.WriteLine($"{string.Join("\n",ps)}\n");
Console.WriteLine($"{string.Join("\n",es)}\n");
Console.WriteLine($"{string.Join("\n",gs)}\n");
