using System;
using System.Collections.Generic;
using System.Text;

namespace Diccionario
{
    public class Palabra
    {
        public string Nombre { get; set; }
        public string Significado { get; set; }

        public Palabra(string nombre, string significado)
        {
            Nombre = nombre;
            Significado = significado;
        }
    }
}
