namespace Rock_Paper_Scissors;

class Program
{
  public static void Main(string[] args)
  {

 Battle.Directions();
 string var = Battle.Input();
 Console.WriteLine(Battle.Computer());
 Battle.Rules(var, Battle.Computer());

  }


  
}

