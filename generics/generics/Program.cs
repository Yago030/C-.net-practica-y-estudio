var numbers = new MyList<int>(5);
var names = new MyList<string>(5); 
var beers = new MyList<Beer>(3);



numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);
numbers.Add(5);
numbers.Add(6);

names.Add("Adrian");
names.Add("Roco");
names.Add("Pedro");
names.Add("Narciso");
names.Add("Mateo");
names.Add("Lujan");

beers.Add(new Beer()
{
    Name = "Delirium",
    Price = 5
}
);

beers.Add(new Beer()
{
    Name = "Corona",
    Price = 2
}
);

beers.Add(new Beer()
{
    Name = "Erdinger",
    Price = 9
}
);

beers.Add(new Beer()
{
    Name = "Paulaner",
    Price = 5
}
);





Console.WriteLine(numbers.GetContent());
Console.WriteLine(names.GetContent());
Console.WriteLine(beers.GetContent());


public class MyList<T>
{
    private List<T> _list;
    private int _limit;


    public MyList(int limit)
    {
        _limit = limit;
        _list = new List<T>();
    }

    public void Add(T element)
    {
        if (_list.Count < _limit)
        {
            _list.Add(element);
        }
    }

    public string GetContent()
    {
        string content = "";
        foreach (var element in _list)
        {
            content += element + ",";
        }


        return content;
    }



}



public class Beer
{
    public string Name { get; set; }
    public decimal Price { get; set; }


    public override string ToString()
    {
        return "La cerveza es : " + Name + "  y su precio es : " + Price ;
    }

}