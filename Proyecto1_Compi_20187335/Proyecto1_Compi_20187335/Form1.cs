using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_Compi_20187335
{
    public partial class Form1 : Form
    {
        ArrayList PestañasCreadas = new ArrayList();
        string[] textos = new string[200];
        ArrayList rich = new  ArrayList();
        RichTextBox txt = new RichTextBox();
        _201807335Parser lex= new _201807335Parser
            ();
        int Contador1 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void nuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();

        }
    void Abrir()
        {


            TabPage Nueva = new TabPage("Pestaña " + Contador1);
            PestañasCreadas.Add(Nueva);

            RichTextBox txt = new RichTextBox();

            txt.Dock = DockStyle.Fill;
            Nueva.Controls.Add(txt);
            tabControl1.TabPages.Add(Nueva);
            Contador1++;
            tabControl1.SelectedTab = Nueva;

        }
        public void Carga()
        {
            try
            {


                openFileDialog1.Title = "Archivos para analizar ";
                openFileDialog1.ShowDialog();
                if (File.Exists(openFileDialog1.FileName))
                    Leer(openFileDialog1.FileName);
                textBox1.Text = openFileDialog1.FileName;
                tabControl1.SelectedTab.Text = openFileDialog1.Title;

                {

                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                       "El archivo no se pudo abrir  ", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
        }
        public void Leer(string direccion)
        {
            try
            {
                tabControl1.SelectedTab.Controls.Clear();

                tabControl1.SelectedTab.Text = openFileDialog1.SafeFileName;

                StreamReader reader = new StreamReader(direccion, Encoding.Default);


                String S = reader.ReadToEnd();
                tabControl1.SelectedTab.Controls.Add(new RichTextBox
                {

                    Text = S,
                    Dock = DockStyle.Fill,
                    Visible = true,
                    ScrollBars = RichTextBoxScrollBars.ForcedBoth,








                }); textos[tabControl1.SelectedIndex] = S;



                reader.Close();
            }


            catch (Exception)
            {
                MessageBox.Show(
                    "ERROR ", "Carga de Archivos Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);







            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Carga();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Entrada = textos[tabControl1.SelectedIndex];
            TabPage tp = tabControl1.SelectedTab;


            foreach (Control o in tp.Controls)
            {

                RichTextBox r = (RichTextBox)o;

                if (o is RichTextBox)
                {
                   lex.Scan(Entrada, r) ;

                    MessageBox.Show("Texto Analizado Correctamente", "Analizis", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void verTablasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lex.Tablas();
        }

        private void sQLTABLASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lex.Tablas();
        }

        private void reporteErroresTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lex.Reporte();
        }

        private void arbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lex.Arbol();
        }

        private void sQLConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lex.Consulta();
        }

        private void verTablasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            lex.VerTabla();
        }
    }


}
