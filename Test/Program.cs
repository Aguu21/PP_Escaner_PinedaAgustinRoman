using Entidades;

public class Program
{
    private static void Main(string[] args)
    {
        Mapa map = new Mapa("Peronía", "Perón", 1940, "10", "1A23S4F", 20, 30);
        Console.WriteLine(map.ToString());
    }
}