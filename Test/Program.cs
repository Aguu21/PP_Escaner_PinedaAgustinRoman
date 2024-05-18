using Entidades;

public class Program
{
    private static void Main(string[] args)
    {
        Mapa map = new Mapa("Peronía", "Perón", 1940, "10", "1A23S4F", 20, 30);
        Libro lib = new Libro("Argentina", "Perón", 1941, "895", "5A4E8D", 48);
        Escaner esc = new Escaner("Pepito", Escaner.TipoDoc.mapa);
        Console.WriteLine(lib.ToString());
    }
}