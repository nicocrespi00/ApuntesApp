using System;
using System.Collections.Generic;
using System.Text;

namespace ApuntesApp.Modelo
{
    class Materias
    {
        public string materia { get; set; }
        public List<Clases> clases { set; get; } = new List<Clases>();

        public Materias(string materia)
        {
            this.materia = materia;
        }

        public void AgregarApunte(Clases cla)
        {
            clases.Add(cla);
        }
        public Clases MostrarClases()
        {
            int claseElegida;            
            for (int i = 0; i < clases.Count; i++)
            {
                Console.WriteLine($"{clases[i].numero} - {clases[i].Fecha}");
            }
            Console.WriteLine();
            Console.Write("Clase elegida: ");
            int.TryParse(Console.ReadLine(), out claseElegida);
            foreach (Clases cla in clases)
            {
                if (claseElegida == cla.numero)
                    return cla;
            }
            return null;
        }
    }
}
