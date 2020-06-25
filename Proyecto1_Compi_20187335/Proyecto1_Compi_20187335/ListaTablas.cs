using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Compi_20187335
{
    class ListaTablas
    {

       public  Tablas Inicio;
       public  Tablas Fin;
        public ListaTablas()
        {
            Inicio = null;
            Fin = null;

        }
        public void Agregar(String Nombre)
        {

            Tablas alv = new Tablas(Nombre);
            alv.SetNombre(Nombre);

            if (  Inicio==null)
            {
                Inicio = alv;
                Inicio.Sig = null;
                Inicio.Ant = null;
                Fin = Inicio;
            }
            else
            {
                this.Fin.Sig = alv;
                alv.Ant = this.Fin;
                alv.Sig = null;
                this.Fin = alv;
            }

        }
        public Tablas Bucar(String Nombre)
        {
            Tablas alv = this.Inicio;
            while (alv != null)
            {
                if (alv.GetNombre().Equals(Nombre))
                {
                    return alv;
                }
                alv = alv.Sig;

            }
            return alv;
        }

        public void Eliminar(String Nombre)
        {
            Tablas alv = this.Inicio;

            while (alv!=null)
            {
                if (alv.GetNombre().Equals(Nombre))
                {

                    if (alv==this.Inicio)
                    {//primerooo

                        this.Inicio = alv.Sig;



                    }
                    else if (alv.Sig==null)
                    {
                        alv.Ant = this.Fin;
                    }
                    else
                    {
                        alv.Sig.Ant = alv.Ant;
                        alv.Ant.Sig = alv.Sig;
                    }


                }

                alv = alv.Sig;
            }
        }

    }
}
