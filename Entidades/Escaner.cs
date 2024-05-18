using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
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

            if(tipo == TipoDoc.mapa)
            {
                this.locacion = Departamento.mapoteca;
            }
            else if(tipo == TipoDoc.libro)
            {
                this.locacion = Departamento.procesosTecnicos;
            }
            else
            {
                this.locacion = Departamento.nulo;
            }
        }

        public bool CambiarEstadoDocumento(Documento d)
        {

            foreach (Documento documento in this.ListaDocumentos)
            {
                if (d == documento)
                {
                    return documento.AvanzarEstado();
                }
            }
            return false;
        }

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

        public static bool operator +(Escaner e, Documento d)
        {
            if((e != d) && (d.Estado == Documento.Paso.Inicio))
            {
                e.CambiarEstadoDocumento(d);
                e.ListaDocumentos.Add(d);
                return true;
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
