using System.Text;

namespace Entidades
{
    //La clase padre para cualquier item que se quiera escanear.
    public abstract class Documento
    {
        int anio;
        string autor;
        string barcode;
        Paso estado;
        string numNormalizado;
        string titulo;


        public int Anio
        {
            get => this.anio;
        }


        public string Autor
        {
            get => this.autor;
        }


        public string Barcode
        {
            get => this.barcode;
        }


        public Paso Estado
        {
            get => this.estado;
        }


        protected string NumNormalizado
        {
            get => this.numNormalizado;
        }


        public string Titulo
        {
            get => this.titulo;
        }


        public Documento(string titulo, string autor, int anio, 
            string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = (anio < 0) ? 0 : anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }


        //Avanza un estado hasta haber llegado al estado "Terminado".
        public bool AvanzarEstado()
        {
            if (this.Estado != Paso.Terminado)
            {
                this.estado = (Paso)((int)this.Estado + 1);
                return true;
            }
            return false;
        }

        
        //Se modifica el método para que muestre las variables correctas.
        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($" Titulo: {this.Titulo}");
            text.AppendLine($" Autor: {this.Autor}");
            text.AppendLine($" Año: {this.Anio}");
            text.AppendLine($" Cód. de barras: {this.Barcode}");
            return text.ToString();
        }


        //Los pasos en los que el documento puede estar al ser escaneado.
        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }
    }
}
