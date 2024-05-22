using System.Text;

namespace Entidades
{ 
    //Entrega información de los Escaneres y sus Documentos.
    public static class Informes
    {
        //Trae la información de los Documentos en estado Distribuidos.
        public static void MostrarDistribuidos(Escaner e,
            out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido,
                out extension, out cantidad, out resumen);
        }


        //Recopila la extensión, la cantidad y un resumen dado un Estado
        //sobre la ListaDocumentos.
        private static void MostrarDocumentosPorEstado(Escaner e, 
            Documento.Paso estado, out int extension, out int cantidad, 
            out string resumen)
        {
            extension = 0;
            cantidad = 0;
            StringBuilder text = new StringBuilder();

            foreach (Documento d in e.ListaDocumentos)
            {
                if (d.Estado == estado)
                {
                    if(d is Libro l)
                    {
                        extension += l.NumPaginas;
                    }
                    else if (d is Mapa m)
                    {
                        extension += m.Superficie;    
                    }
                    cantidad++;
                    text.AppendLine(d.ToString() + "\n");
                }
            }
            resumen = text.ToString();
        }


        //Trae la información de los Documentos en estado EnEscaner.
        public static void MostrarEnEscaner(Escaner e,
            out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner,
                out extension, out cantidad, out resumen);
        }


        //Trae la información de los Documentos en estado EnRevisión.
        public static void MostrarEnRevision(Escaner e,
            out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision,
                out extension, out cantidad, out resumen);
        }


        //Trae la información de los Documentos en estado Terminado.
        public static void MostrarTerminados(Escaner e, 
            out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado,
                out extension, out cantidad, out resumen);
        }
    }
}
