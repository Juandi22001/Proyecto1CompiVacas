using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Compi_20187335
{
    class Tablas
    {
        string Nombre = "";
        public LinkedList<Atributo> A;
        public Tablas Sig;
        public Tablas Ant;
        public Tablas()
        {
            A = new LinkedList<Atributo>();
        }

        public Tablas(String Nombre)
        {
            this.Nombre = Nombre;
            A = new LinkedList<Atributo>();
        }
        public String GetNombre()
        {
            return this.Nombre;
        }
        public void SetNombre(String Nombre)
        {
            this.Nombre = Nombre;
        }
    }
}
