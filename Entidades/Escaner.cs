using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        List<Documento> listaDocuemntos;
        Departamento locacion;
        string marca;
        TipoDoc tipo;

        public List<Documento> ListaDocumentos
        {
            get => this.listaDocuemntos;
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
            this.listaDocuemntos = new List<Documento>();

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
