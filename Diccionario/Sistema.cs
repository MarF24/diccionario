using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace Diccionario
{
    public class Sistema
    {
        List<Palabra> palabras = new List<Palabra>();

        public List<Palabra> Palabras;
      
        public Sistema()
        {
            Precarga();
        }

        private void Precarga()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName+"/diccionario_espanol.txt";
           
            using (StreamReader file = new StreamReader(path))
            {
                int counter = 0;
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                  string[] parts = ln.Split('#');
                    palabras.Add(new Palabra(parts[0],parts[1]));
                }
                file.Close();
            }
        }

        public string BuscarPalabra(string pal)
        {
            foreach (Palabra p in palabras)
            {
                if(p.Nombre == pal)
                {
                    return p.Significado;
                }
            }

            return "Palabra no encontrada";
        }

        public string SignificadoVariasP(string pal)
        {
            string respuesta ="";
            foreach (Palabra p in palabras)
            {
                if (p.Nombre.Contains(pal))
                {
                    respuesta += " /////////////////////////// "+ p.Nombre + p.Significado +" /////////////////////////// ";
                }
            }
            return respuesta;
        }

        public string PalabrasConVocales()
        {
            string palabraContiene = "";
            string[] vocales = { "a", "e", "i", "o", "u" };
            
            foreach(Palabra p in palabras)
            {
                bool contiene = true;

                foreach (string v in vocales)
                {
                    if (!p.Nombre.Contains(v))
                    {
                        contiene = false;
                        break;
                    }
                }

                if (contiene)
                {
                    palabraContiene += p.Nombre + "/";
                }
            }

            return palabraContiene;
        }

        public string PalabraMasLarga()
        {
            int largoP = 0;
            string palabraLarga = string.Empty;

            foreach(Palabra p in palabras)
            {
                int comaIndex = p.Nombre.IndexOf(",");
                string aux = "";

                if (comaIndex == -1)
                {
                    aux = p.Nombre;
                }
                else
                {
                    aux = p.Nombre.Substring(0, comaIndex);

                }

                if(!aux.Contains(" "))
                {
                    if (aux.Length > largoP)
                    {
                        largoP = aux.Length;
                        palabraLarga = aux;

                    }
                    else if (aux.Length == largoP)
                    {
                        palabraLarga += " // " + aux;
                    }
                }
            }
            
            return palabraLarga;
        }

        public string PalabraMasConsonantes()
        {
            int maxCon = 0;
            string palabra = string.Empty;
            string vocales = "aeiouáéíóú";

            foreach (Palabra p in palabras)
            {
                int canCon = 0;

                foreach (char c in p.Nombre)
                {
                    if (!vocales.Contains(c))
                    {
                        canCon++;
                    }
                }

                if (canCon > maxCon)
                {
                    palabra = p.Nombre;
                    maxCon = canCon;
                }
            }

            return palabra;
        }
    }
}
