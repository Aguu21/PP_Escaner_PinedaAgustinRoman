using System.Text;

namespace Entidades
{
    //Item a escanear
    public class Mapa : Documento
    {
        int alto;
        int ancho;

        public int Alto
        {
            get => this.alto;
        }


        public int Ancho
        {
            get => this.ancho;
        }
        
        
        public int Superficie
        {
            get => this.ancho * this.alto;
        }
        
        
        public Mapa(string titulo, string autor, int anio,
            string numNormalizado, string codebar, int ancho, int alto)
            : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.ancho = ancho;
            this.alto = alto;
        }


        //Dos mapas serán iguales si comparten las características marcadas.
        public static bool operator ==(Mapa m1, Mapa m2)
        {
            return ((m1.Barcode == m2.Barcode) ||
                    (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor &&
                    m1.Anio == m2.Anio && m1.Superficie == m2.Superficie));
        }


        public static bool operator !=(Mapa m1, Mapa m2)
        {
            return !(m1 == m2);
        }


        //Se agrega al método las variables correspondientes a los mapas.
        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.Append(base.ToString());

            text.Append($"Superficie: {this.Alto} * {this.Ancho} = {this.Superficie} cm2.");
            
            return text.ToString();
        }
    }
}
