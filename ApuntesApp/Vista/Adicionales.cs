using System;
using System.Collections.Generic;
using System.Text;

namespace ApuntesApp.Vista
{
    class Adicionales
    {
        public void Encabezado(string categoria)
        {
            Console.Clear();
            string aux = "Appuntes";
            string titulo = $"|>>>>>>>> {aux,-14} <<<<<<<<|";
            string subtitulo = $"|>>>>>>>> {categoria,-14} <<<<<<<<|";
            string asterisquitos = string.Empty;

            for (int i = 0; i<titulo.Length; i++)
            {
                asterisquitos += "-";
            }

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(asterisquitos);
            Console.WriteLine(titulo);

            Console.BackgroundColor = ConsoleColor.DarkGray;

            Console.WriteLine(subtitulo);

            Console.BackgroundColor = ConsoleColor.Cyan;

            Console.WriteLine(asterisquitos);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}
