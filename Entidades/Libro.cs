using System.Text;

namespace Entidades
{
    //Item a escanear
    public class Libro : Documento
    {
        int numPaginas;

        public int NumPaginas
        {
            get => this.numPaginas;
        }
        
        
        public string ISBN
        {
            get => this.NumNormalizado;
        }
        
        
        public Libro(string titulo, string autor, int anio,
            string numNormalizado, string codebar, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.numPaginas = (numPaginas < 1) ? 1 : numPaginas; ;
        }


        //Dos lirbos serán iguales si comparten las características marcadas.
        public static bool operator ==(Libro l1, Libro l2)
        {
            return ((l1.Barcode == l2.Barcode) || 
                    (l1.ISBN == l2.ISBN) ||
                    (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor));
        }


        public static bool operator !=(Libro l1, Libro l2) 
        {
            return !(l1 == l2);
        }


        //Se agrega al método las variables correspondientes a los libros.
        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.Append(base.ToString());

            //Ubicar el valor de "ISBN" previo al valor de "Cód. de barras"
            //también se puede lograr con este código pero no es tan fiable:
            //int index = text.ToString().IndexOf("Cód. de barras:");
            //text.Insert(index, $"ISBN: {this.ISBN}\n");
            int index = 0;
            for (int i = 0; i < 3; i++)
            {
                index = text.ToString().IndexOf("\n", index + 1);
            }
            text.Insert(index + 1, $"ISBN: {this.ISBN} \n");
            
            text.AppendLine($"Número de Páginas: {this.NumPaginas}.");

            return text.ToString();
        }
    }
}
