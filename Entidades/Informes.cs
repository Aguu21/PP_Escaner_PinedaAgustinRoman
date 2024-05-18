using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Informes
    {
        public static void MostrarDistribuidos(Escaner e,
            out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido,
                out extension, out cantidad, out resumen);
        }

        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado,
            out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            
            StringBuilder text = new StringBuilder();
            foreach (Documento documento in e.ListaDocumentos)
            {
                if (documento.Estado == estado)
                {
                    if(documento is Libro l)
                    {
                        extension += l.NumPaginas;
                    }
                    else if (documento is Mapa m)
                    {
                        extension += m.Superficie;    
                    }
                    cantidad++;
                    text.AppendLine(documento.ToString());
                }
            }

            resumen = text.ToString();
        }

        public static void MostrarEnEscaner(Escaner e,
            out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner,
                out extension, out cantidad, out resumen);
        }

        public static void MostrarEnRevisión(Escaner e,
            out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision,
                out extension, out cantidad, out resumen);
        }

        public static void MostrarTerminados(Escaner e, 
            out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado,
                out extension, out cantidad, out resumen);
        }
    }
}
