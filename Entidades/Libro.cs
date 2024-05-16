﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
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
            string numNormalizado, string barcode, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, barcode)
        {
            this.numPaginas = numPaginas;
        }

        public static bool operator ==(Libro l1, Libro l2)
        {
            if ((l1.Barcode == l2.Barcode) || 
                (l1.ISBN == l2.ISBN) ||
                (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Libro l1, Libro l2) 
        {
            return !(l1 == l2);
        }
        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.Append(base.ToString());
            text.AppendLine($"ISBN: {this.ISBN}");
            text.AppendLine($"Cód. de barras: {this.Barcode}");
            text.AppendLine($"Número de Páginas: {this.NumPaginas}.");
            return text.ToString();
        }
    }
}
