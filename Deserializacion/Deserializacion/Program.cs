using System.Text.Json;

var santiago = new People()
{
    Name = " Santiago",
    Age = 29
};


string json = JsonSerializer.Serialize(santiago);   
Console.WriteLine(json);

string myJson = @"{
""Name"":"" Juan"",
""Age"":29}
";



People? juan =JsonSerializer.Deserialize<People>(myJson);

Console.WriteLine(juan?.Name + " " + juan?.Age);

public class People
{
    public string Name { get; set; }
    public int Age { get; set; }    



}