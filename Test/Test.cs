using Entidades;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // LIBROS
            // Caminos felices
            Libro l1 = new Libro("Yerma", "García Lorca, Federico", 1995, "11111", "22222", 100);

            //MAPAS 
            // Caminos felices
            Mapa m1 = new Mapa("Buenos Aires", "Instituto Geográfico de Buenos Aires", 2005, "", "99999", 30, 15); //450

            //ESCANERS
            Escaner l = new Escaner("HP", Escaner.TipoDoc.libro);
            Escaner m = new Escaner("HP", Escaner.TipoDoc.mapa);

            bool pudo = l + l1;

            try
            {
                pudo = l + m1;
            }
            catch (TipoIncorrectoException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                try
                {
                    pudo = m + l1;
                }
                catch (TipoIncorrectoException ex)
                {
                    string result = ex.InnerException != null ? ex.InnerException.ToString() : "No hay innerException";
                    Console.WriteLine(result);
                }
            }
        }
    }
}