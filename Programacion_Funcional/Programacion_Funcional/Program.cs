

var show = Show;

Some(show, "hola como estas ?");


void Show (string message)
{
        Console.WriteLine (message);

}


void Some(Action <string>fn, string message)
{
    Console.WriteLine("Hace algo al inicio ");
    fn ( message );
    Console.WriteLine("Hace algo al final:");
}



//var beer = new Beer()
//{
//    Name = "Guiness"

//};


//   Console.WriteLine(ToUpper(beer).Name);
//   Console.WriteLine(beer.Name);

//Beer ToUpper  (Beer beer){

//    var beer2 = new Beer()
//    {
//        Name = beer.Name.ToUpper()
//    };

//    return beer2;
// }





//class Beer
//{

//    public string Name { get; set; }
     
//}

