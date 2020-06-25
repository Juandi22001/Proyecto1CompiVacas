using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Compi_20187335
{
    class graficador
    {
        String ruta;
        StringBuilder grafica;
        public graficador()
        {
            ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }
        private void generarDot(String rdot, String rpng)
        {
            File.WriteAllText(rdot, grafica.ToString());
            String comandoDot = " dot -Tpng \"" + rdot + "\" -o \"" + rpng + "\"";
            var comando = String.Format(comandoDot);
            var procesoStart = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var procedimiento = new System.Diagnostics.Process();
            procedimiento.StartInfo = procesoStart;
            procedimiento.Start();
            procedimiento.WaitForExit();

        }

        public void graficar(String texto)
        {

            grafica = new StringBuilder();
            String rdot = ruta + "\\AFN.dot";
            String rpng = ruta + "\\AFN.png ";
            grafica.Append(texto);  
            this.generarDot(rdot, rpng);

        }
    }
}
