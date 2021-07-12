using System;
using System.Collections.Generic;
using System.Text;

namespace ApuntesApp
{
    class Clases
    {
        public int numero { get; set; }
        public DateTime Fecha { get; set; }
        public List<string> apuntes { get; set; }

        public Clases(int numeroDeClase, DateTime FechaClase, List<string> apuntesClase)
        {
            this.numero = numeroDeClase;
            this.Fecha = FechaClase;
            this.apuntes = apuntesClase;
        }
    }
}
