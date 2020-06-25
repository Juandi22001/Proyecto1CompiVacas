using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Compi_20187335
{
    class Actualizars 
    {

        String CAMPO;
        String Remplazo;

        public Actualizars(String CAMPO, String Remplazo)
        {
            this.CAMPO = CAMPO;
            this.Remplazo = Remplazo;
        }

        public String GetRemplazo()
        {
            return this.Remplazo;
        }
        public String GetCampo()
        {

            return this.CAMPO;
        }
    }
}
