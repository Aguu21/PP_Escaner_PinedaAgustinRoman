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
            : base(mensaje)
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }


        public TipoIncorrectoException(string mensaje, string nombreClase,
            string nombreMetodo, Exception innerException)
            : base(mensaje, innerException)
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            string innerException = InnerException != null ? 
                InnerException.Message : "N/A";

            text.AppendLine($"- Excepción en el método {this.NombreMetodo} de la clase {this.NombreClase}.");
            text.AppendLine($"- Algo salió mal, revisa los detalles.");
            text.AppendLine($"- Detalles: {innerException}.");

            return text.ToString();
        }
    }
}
