using ApuntesApp.Modelo;
using ApuntesApp.Vista;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApuntesApp
{
    class Control
    {
        private Adicionales adic = new Adicionales();
        public List<Clases> ListaDeClases { set; get; } = new List<Clases>();
        public List<Materias> ListaDeMaterias { set; get; } = new List<Materias>();

        public void Inicio()
        {
            int option = 0;
            while (option != 3)
            {
                adic.Encabezado("Menu Materias");
                Console.WriteLine(" ----------------------");
                Console.WriteLine("|| 1. Agregar Materia ||");
                Console.WriteLine("|| 2. Ver Materias    ||");
                Console.WriteLine("|| 3. Salir           ||");
                Console.WriteLine(" ----------------------");
                Console.Write("Opción elegida: ");
                int.TryParse(Console.ReadLine(), out option);
                if (option != 3)
                    ManipularOpcionMateria(option);
            }
        }

        private void ManipularOpcionMateria(int option)
        {
            switch (option)
            {
                case 1:
                    Console.Clear();
                    AgregarMateria();
                    break;
                case 2:
                    Console.Clear();
                    Materias materiaElegida = ListarMaterias();
                    MenuClases(materiaElegida);
                    break;
            }
        }

        private Materias ListarMaterias()
        {
            for (int i = 0; i < ListaDeMaterias.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {ListaDeMaterias[i].materia}");
            }
            Console.WriteLine();
            return ElegirMateria();
        }

        private Materias ElegirMateria()
        {
            int materiaElegida;
            Console.Write("Materia elegida: ");
            int.TryParse(Console.ReadLine(), out materiaElegida);
            for (int i = 0; i < ListaDeMaterias.Count; i++)
            {
                if (materiaElegida == (i + 1))
                    return ListaDeMaterias[i];
            }
            Console.WriteLine("Clase elegida inexistente");
            return AgregarMateria();
        }

        private Materias AgregarMateria()
        {
            string nombreClase;
                Console.Write("Nombre de la clase: ");
                nombreClase = Console.ReadLine();
                Materias mat = new Materias(nombreClase);
                ListaDeMaterias.Add(new Materias(nombreClase));
                return mat;
        }

        private void MenuClases(Materias mat)
        {
            int option = 0;
            while (option != 3)
            {
                adic.Encabezado("Menu Clases");
                Console.WriteLine(" --------------------");
                Console.WriteLine("|| 1. Agregar clase ||");
                Console.WriteLine("|| 2. Ver clase     ||");
                Console.WriteLine("|| 3. Salir         ||");
                Console.WriteLine(" --------------------");
                Console.Write("Opción elegida: ");
                int.TryParse(Console.ReadLine(), out option);
                if (option != 3)
                    ManipularOpcion(option, mat);
            }
        }

        private void ManipularOpcion(int option, Materias mat)
        {
            switch (option)
            {
                case 1:
                    Console.Clear();
                    AgregarClase(mat);
                    break;
                case 2:
                    Console.Clear();
                    Clases claseElegida = ElegirClase(mat);
                    MostrarClase(claseElegida);
                    break;
            };
        }

        private void MostrarClase(Clases cla)
        {
            Console.Clear();
            Console.WriteLine($"Numero de clase: {cla.numero}");
            Console.WriteLine($"Fecha: {cla.Fecha}");
            for (int i = 0; i < cla.apuntes.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {cla.apuntes[i]}");
            }
            Console.ReadKey();
        }

        private Clases ElegirClase(Materias mat)
        {
            Clases cla;
            cla = mat.MostrarClases();
            if (cla == null)
            {
                Console.WriteLine("Clase elegida inexistente ¡Vamos a crearla!");
                return AgregarClase(mat);
            }
            else
            {
                return cla;
            }
        }

        private Clases AgregarClase(Materias mat)
        {
            int cantApuntes = 0;
            string apunte;
            int nroClase, dia, mes, anio;
            List<string> apuntes = new List<string>();

            Console.Write("Numero de la clase: ");
            int.TryParse(Console.ReadLine(), out nroClase);

            Console.Write("Dia de la clase(1-31): ");
            int.TryParse(Console.ReadLine(), out dia);
            Console.Write("Mes de la clase(1-12): ");
            int.TryParse(Console.ReadLine(), out mes);
            Console.Write("Año de la clase(YYYY): ");
            int.TryParse(Console.ReadLine(), out anio);

            Console.Write("Ingrese la cantidad de apuntes: ");
            int.TryParse(Console.ReadLine(), out cantApuntes);

            for (int i = 0; i < cantApuntes; i++)
            {
                Console.Write($"apunte {i + 1}: ");
                apunte = Console.ReadLine();
                apuntes.Add(apunte);
            }

            DateTime fecha = new DateTime(anio, mes, dia);

            Clases cla = new Clases(nroClase, fecha, apuntes);
            ListaDeClases.Add(new Clases(nroClase, fecha, apuntes));
            mat.AgregarApunte(cla);
            return cla;
        }
    }
}
