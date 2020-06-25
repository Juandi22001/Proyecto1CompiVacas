using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Compi_20187335
{
    class ObjetoCool

    {


Object  Nombre;
        String Tabla;
        int pos;

      public  ObjetoCool (Object Nombre , String Tabla , int pos)
        {
            this.Nombre = Nombre;
            this.Tabla = Tabla;
            this.pos = pos;



        }
        public String GetTabla()
        {
            return this.Tabla;
        }
        public int GetpOS()
        {
            return this.pos;
        }


        public Object GetNombre()
        {
            return this.Nombre;
        }
    }
}
