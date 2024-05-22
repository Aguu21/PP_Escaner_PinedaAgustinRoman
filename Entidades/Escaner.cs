namespace Entidades
{ 
    //Recopila aquellos Documentos a escanear y los escanea.
    public class Escaner
    {
        List<Documento> listaDocumentos;
        Departamento locacion;
        string marca;
        TipoDoc tipo;


        public List<Documento> ListaDocumentos
        {
            get => this.listaDocumentos;
        }


        public Departamento Locacion
        {
            get => this.locacion;
        }


        public string Marca
        {
            get => this.marca;
        }


        public TipoDoc Tipo
        {
            get => this.tipo;
        }


        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();

            //Dado el tipo de Documento a escanear, la locacion varia.
            this.locacion = (this.Tipo == TipoDoc.mapa) ? Departamento.mapoteca :
                 (this.Tipo == TipoDoc.libro) ? Departamento.procesosTecnicos :
                 Departamento.nulo;
        }


        public bool CambiarEstadoDocumento(Documento d)
        {

            foreach (Documento documento in ListaDocumentos)
            {
                if (d == documento)
                {
                    return documento.AvanzarEstado();
                }
            }
            return false;
        }


        //Dada la lista del escaner, se chequea si existe una copia.
        public static bool operator ==(Escaner e, Documento d)
        {
            foreach (Documento documento in e.ListaDocumentos)
            {
                if (d == documento)
                {
                    return true;
                }
            }
            return false;
        }


        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }


        //Añade un documento a ListaDocumentos segun corresponda.
        public static bool operator +(Escaner e, Documento d)
        {
            if (e.Tipo == TipoDoc.mapa && d is Mapa ||
                e.Tipo == TipoDoc.libro && d is Libro)
            {
                if ((e != d) && (d.Estado == Documento.Paso.Inicio))
                {
                    d.AvanzarEstado();
                    e.ListaDocumentos.Add(d);
                    return true;
                }
            }
            return false;
        }


        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }


        public enum TipoDoc
        {
            libro,
            mapa
        }
    }
}
