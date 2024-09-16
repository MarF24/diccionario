using System;
using System.Collections.Generic;

namespace Diccionario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema s = new Sistema();

            int op = -1;

            while (op != 0)
            {
                Console.Clear();
                Console.WriteLine("Bienvenido/a");
                Console.WriteLine("Seleccione una op");
                Console.WriteLine("1- Significado de una palabra");
                Console.WriteLine("2- Palabras que contengan otras palabras");
                Console.WriteLine("3-Listar todas las palabras que contienen todas las vocales");
                Console.WriteLine("4-Palabra mas larga");


                Console.WriteLine("0- Salir");
                Console.WriteLine(s.PalabraMasConsonantes());

                op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    Console.WriteLine("Escribe una palabra");
                    string palabra = Console.ReadLine().ToLower();
                    Console.WriteLine(s.BuscarPalabra(palabra));
                    Console.ReadKey();
                }

                if(op == 2)
                {
                    Console.WriteLine("Escribe una palabra");
                    string palabra = Console.ReadLine().ToLower();
                    Console.WriteLine(s.SignificadoVariasP(palabra));
                    Console.ReadKey();

                }

                if(op == 3)
                {

                    Console.WriteLine(s.PalabrasConVocales());
                    Console.ReadKey();

                }
                if (op == 4)
                {
                    Console.WriteLine(s.PalabraMasLarga());
                    Console.ReadKey();
                }
                
            }
        }
    }
}
