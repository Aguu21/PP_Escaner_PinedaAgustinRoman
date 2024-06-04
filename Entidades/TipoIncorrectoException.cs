using System.Text;

namespace Entidades
{
    public class TipoIncorrectoException : Exception
    {
        string nombreClase;
        string nombreMetodo;


        public string NombreClase
        {
            get => this.nombreClase;
        }

        public string NombreMetodo
        {
            get => this.nombreMetodo;
        }


        public TipoIncorrectoException(string mensaje, string nombreClase,
            string nombreMetodo)
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }


        public TipoIncorrectoException(string mensaje, string nombreClase,
            string nombreMetodo, Exception innerException)
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
