using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Compi_20187335
{
    class Remplazo
    {
       object Tabla;
       object Columna;
       object Remplazos;

        public Remplazo(String Tabla ,object Columna,object Remplazos)
        {
            this.Tabla = Tabla;
            this.Columna = Columna;
            this.Remplazos = Remplazos;
        }
        public object GetTabla()
        {
            return this.Tabla;
        }
        public object GetColumna()
        {
            return this.Columna;
        }
        public object GetRemplazo()
        {
            return this.Remplazos;
        }

    }
}
