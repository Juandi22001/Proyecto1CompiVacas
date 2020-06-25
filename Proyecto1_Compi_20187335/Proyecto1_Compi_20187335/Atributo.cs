using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Compi_20187335
{
    class Atributo
    {
        String Nombre;
        String Tipo;
        String Procedencia;
        String Tabla;
        public LinkedList<Object> Objetos;
        public Atributo()
        {
            Objetos = new LinkedList<Object>();

        }
        public Atributo (String Nombre , String Tipo)
        {
            this.Nombre = Nombre;
            this.Tipo = Tipo;
            Objetos = new LinkedList<Object>();
        }
        public Atributo(String Nombre, String Tipo, String Precedencia)
        {
            this.Nombre = Nombre;
            this.Tipo = Tipo;
            this.Procedencia = Precedencia;
            this.Tabla = Tabla;
            Objetos = new LinkedList<Object>();
        }
        public String GetPrecedencia()
        {
            return this.Procedencia;
        }
        public String GetTabla()
        {
            return this.Tabla;
        }
        public String GetNombre()
        {
            return this.Nombre;
        }
        public String GetTIPO()
        {
            return this.Tipo;
        }
        
        public void SetNombre(String Nombre)
        {
            this.Nombre = Nombre;
        }
        public void SetTipo(String Tipo)
        {
            this.Tipo = Tipo;
        }
    }
}
