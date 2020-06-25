using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Compi_20187335
{
    class Arbol
    {

       public String Nombre;
        private int Longitud;

        public  LinkedList<Arbol> A;
        public Arbol()
        {
            A = new LinkedList<Arbol>();
        }

        public Arbol(String Nombre )
        {
            this.Nombre=Nombre;
            A = new LinkedList<Arbol>();
        }

        public int getLongitud() {
            return A.Count;
        }

        public string getDot()
        {
            int cont = 0;
            string Dot = this.GetHashCode().ToString() +"[label=\""+this.Nombre+"\"];\n";

            if (getLongitud()>0)
            {
                while (cont < getLongitud())
                {
                    Dot += this.GetHashCode().ToString() + "->" + A.ElementAt(cont).GetHashCode()+"\n";
                    Dot += A.ElementAt(cont).getDot() + "\n";
                        cont++;
                }
            }
                return Dot;
        }



    }
}
