string [] names = 
{
    "Hector", "Francisco", "Ana", "Hugo", "Pedro"
};

var namesResult = from n in names
                  orderby n descending
                  select n;

foreach (var name in namesResult)
{
    Console.WriteLine(name);
}