using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_Compi_20187335
{   
    class _201807335Parser
    { public _201807335Parser()
        {


        }

        SQL S = new SQL();
        _201807335Parsers PARS = new _201807335Parsers();
        SINTACTIC SS = new SINTACTIC
            ();
        public static LinkedList<Tokens>Tks = new LinkedList<Tokens>();
        public static LinkedList<Tokens> Tks2 = new LinkedList<Tokens>();
        public  LinkedList<ErroresTokens> ErTks = new LinkedList<ErroresTokens>();
        private int Estado;
        private int columna = 0;
        private int fila = 0;
        public int idtoken = 0;
        private string Lexema="";
        public int indice = 0;
        public int indices = 0;
        public void Scan( string E , RichTextBox r)
        {
            Tks = new LinkedList<Tokens>();
            ErTks = new LinkedList<ErroresTokens>();


            Char c;

            for (int i = 0; i <= E.Length - 1; i++)
            {

                c = E.ElementAt(i);

                switch (Estado)
                {
                    case 0:

                        if (Char.IsLetter(c))
                        {

                            Lexema += c;
                            columna++;
                            Estado = 1;
                            r.SelectionStart = i + 1;

                        }
                        else if (Char.IsDigit(c))
                        {
                            Lexema += c;
                            columna++;
                            Estado = 2;
                            r.SelectionStart = i + 1;

                        }
                        else if (c == ('\u0022'))
                        {
                   
                            r.SelectionStart = i + 1;
                            columna++;
                            Estado = 4;


                        }
                        else if (c == '<')
                        {
                            Lexema += c;
                            r.SelectionStart = i + 1;
                            columna++;
                            Estado = 5;
                        }
                        else if (c == '>')
                        {
                            Lexema += c;
                            r.SelectionStart = i + 1;
                            columna++;
                            Estado = 6;
                        }
                        else if (c == '/')
                        {

                            columna++;
                            Estado = 7;

                        }
                        else if (c=='\'' )
                        {
                            Lexema += c;


                            columna++;
                            Estado = 10;

                        }
                        else if (c == '-')
                        {
                            Lexema += c;
                            columna++;
                            Estado = 22;

                        }
                        else if (c == '=')
                        {
                            Estado = 0;

                            Lexema += c;
                            columna++;
                            r.Select(i - Lexema.Length, Lexema.Length);

                            r.SelectionColor = Color.Red;
                            r.SelectionStart = i + 1;
                            idtoken = 29;
                            indice++;
                            Agregar2(Lexema, 1, "Igual", fila, columna, Tokens.TipoToken.IGUAL);
                            Agregar(Lexema, 1, "Igual", fila, columna, Tokens.TipoToken.IGUAL);
                            Lexema = "";


                        }
                        else if (c == '!')
                        {
                            Lexema += c; r.SelectionStart = i + 1;
                            Estado = 20;

                        }
                        else if (c == ',')
                        {

                            Lexema += c;
                            columna++;
                            idtoken = 30;
                            indice++;
                            Agregar2(Lexema, 2, "coma", fila, columna, Tokens.TipoToken.COMA);
                            Agregar(Lexema, 2, "coma", fila, columna, Tokens.TipoToken.COMA);

                            Lexema = "";
                            Estado = 0;

                        }
                        else if (c == '*')
                        {

                            Lexema += c;
                            columna++;
                            idtoken = 30;
                            indice++;
                            Agregar(Lexema, 37, "*", fila, columna, Tokens.TipoToken.Asterisco);
                            Agregar2(Lexema, 37, "*", fila, columna, Tokens.TipoToken.Asterisco); 
                            Lexema = "";
                            Estado = 0;

                        }
           
                        else if (c.Equals('\r'))

                        {
                            Estado = 0;

                        }
                        else if (c.Equals('\t'))

                        {
                            Estado = 0;

                        }

                        else if (c == ';')
                        {
                            Lexema += c;
                            columna++;
                            idtoken = 30;
                            indice++;
                            Agregar(Lexema, 3, "Puntoycoma", fila, columna, Tokens.TipoToken.PUNTO_y_COMA);
                            Agregar2(Lexema, 3, "Puntoycoma", fila, columna, Tokens.TipoToken.PUNTO_y_COMA);
                            Lexema = "";
                            Estado = 0;

                        }
                        else if (c == '(')
                        {
                            Console.WriteLine("PARENTESIS");
                            Lexema += c;
                            columna++;
                            idtoken = 31;
                            Console.WriteLine(Lexema);
                            Agregar2(Lexema, 4, "Parentesis Abierto", fila, columna, Tokens.TipoToken.PARENTESIS_ABIERTO);
                            Agregar(Lexema, 4, "Parentesis Abierto", fila, columna, Tokens.TipoToken.PARENTESIS_ABIERTO);
                            Lexema = "";
                            Estado = 0;

                        }
                        else if (c == ')')
                        {
                            Lexema += c;
                            columna++;
                            idtoken = 32;
                            indice++;
                            Agregar(Lexema, 5, "Parentesis Cerrado", fila, columna, Tokens.TipoToken.PARENTESIS_CERRADO);
                            Agregar2(Lexema, 5, "Parentesis Cerrado", fila, columna, Tokens.TipoToken.PARENTESIS_CERRADO); Lexema = "";

                            Estado = 0;

                        }

                        else if (c == '[')
                        {
                            Lexema += c;
                            columna++;
                            idtoken = 33;
                            indice++;
                            Agregar2(Lexema, 6, "corchete abierto", fila, columna, Tokens.TipoToken.CORCHETE_ABIERTO);
                            Agregar(Lexema, 6, "corchete abierto", fila, columna, Tokens.TipoToken.CORCHETE_ABIERTO);

                            Lexema = "";
                            Estado = 0;

                        }
                        else if (c == ']')
                        {
                            Lexema += c;
                            columna++;
                            idtoken = 34;
                            indice++;
                            Agregar2(Lexema, 7, "corchete cerrado", fila, columna, Tokens.TipoToken.CORCHETE_CERRADO);
                            Agregar(Lexema, 7, "corchete cerrado", fila, columna, Tokens.TipoToken.CORCHETE_CERRADO); Lexema = "";

                            Estado = 0;

                        }
                        else if (c == '.')
                        {
                            Lexema += c;
                            columna++;
                            idtoken = 35;
                            indice++;
                            Agregar2(Lexema, 8, "Punto", fila, columna, Tokens.TipoToken.PUNTO); 
                            Agregar(Lexema, 8, "Punto", fila, columna, Tokens.TipoToken.PUNTO); Lexema = "";

                            Estado = 0;

                        }

                        else if (c == ' ')
                        {
                            Console.WriteLine("espacio");
                            if ((int)c == 32)
                            {
                                Estado = 0;

                                //   MessageBox.Show("salto");
                                columna++;


                            }
                            //espacios

                            else
                            {

                                Lexema += c;
                                Agregar2E(Lexema, "efe", fila, columna);

                                //espacios




                            }
                        }
                        else if (c == '\n')
                        {
                            columna = 0;
                            fila++;

                            r.SelectionStart = 0;
                            Estado = 0;

                        }

                        else

                        {
                            Lexema += c;
                            Agregar2E(Lexema, "no reconocido", fila, columna);

                            Lexema = ""; Estado = 0;

                        }

                        break;
                    case 1:

                        if (Char.IsLetter(c))
                        {
                            Lexema += c;
                            columna++;
                            indices = i;
                            Estado = 1;

                        }
                        else if (c == '_')
                        {
                            Lexema += c;
                            columna++;
                            r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;
                            Estado = 1;
                        }
                        else if ("TABLA".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 1; r.Select(indices - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Purple;


                            Agregar2(Lexema, 9, "Palabra Reservada Tabla", fila, columna, Tokens.TipoToken.TAABLA);
                            Agregar(Lexema, 9, "Palabra Reservada Tabla", fila, columna, Tokens.TipoToken.TAABLA);

                            Lexema = "";
                            Estado = 0;
                            i--;

                        }
                        else if ("INSERTAR".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 2; r.Select(indices - Lexema.Length+1
                                , Lexema.Length);
                            r.SelectionColor = Color.Purple;

                            Agregar(Lexema, 10, "Palabra Reservada Insertar", fila, columna, Tokens.TipoToken.INSERTAR);
                            Agregar2(Lexema, 10, "Palabra Reservada Insertar", fila, columna, Tokens.TipoToken.INSERTAR); 
                            r.SelectionStart = i + 1;

                            Lexema = "";
                            Estado = 0;
                            i--;

                        }
                        else if ("ELIMINAR".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {


                            idtoken = 3; r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Purple;

                            Agregar(Lexema, 11, "Palabra Reservada Eliminar", fila, columna, Tokens.TipoToken.ELIMINAR);

                            Agregar2(Lexema, 11, "Palabra Reservada Eliminar", fila, columna, Tokens.TipoToken.ELIMINAR);
                            Lexema = "";
                            Estado = 0;
                            i--;

                        }
                        else if ("MODIFICAR".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 4; r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Purple;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 12, "Palabra Reservada MODIFICAR", fila, columna, Tokens.TipoToken.MODIFICAR);

                            Agregar2(Lexema, 12, "Palabra Reservada MODIFICAR", fila, columna, Tokens.TipoToken.MODIFICAR);
                            Lexema = "";
                            Estado = 0;
                            i--;

                        }

                        else if ("SELECCIONAR".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 5; r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Purple;
                            r.SelectionStart = i + 1;
                            Console.WriteLine("seleccionar");
                            Agregar2(Lexema, 13, "Palabra Reservada Seleccionar", fila, columna, Tokens.TipoToken.SELECCIONAR);
                            Agregar(Lexema, 13, "Palabra Reservada Seleccionar", fila, columna, Tokens.TipoToken.SELECCIONAR);

                            Lexema = "";
                            Estado = 0;
                            i--;

                        }
                        else if ("ACTUALIZAR".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 6; r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Purple;
                            r.SelectionStart = i + 1;

                            Agregar2(Lexema, 14, "Palabra Reservada Actualizar", fila, columna, Tokens.TipoToken.ACTUALIZAR);
                            Agregar(Lexema, 14, "Palabra Reservada Actualizar", fila, columna, Tokens.TipoToken.ACTUALIZAR);

                            Lexema = "";
                            Estado = 0;
                            i--;

                        }
                        else if ("CREAR".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {


                            idtoken = 6;
                            r.Select(indices - Lexema.Length+1, Lexema.Length);
                            r.SelectionColor = Color.Black;

                            Agregar2(Lexema, 15, "Palabra Reservada Crear", fila, columna, Tokens.TipoToken.CREAR);
                            Agregar(Lexema, 15, "Palabra Reservada Crear", fila, columna, Tokens.TipoToken.CREAR);

                            r.SelectionStart = i + 1;
                            Lexema = "";
                            Estado = 0;
                            i--;

                        }
                        else if ("entero".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 8; r.Select(indices - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Black;


                            Agregar(Lexema, 16, "Palabra Reservada entero", fila, columna, Tokens.TipoToken.ENTERO);
                            Agregar2(Lexema, 16, "Palabra Reservada entero", fila, columna, Tokens.TipoToken.ENTERO);

                            Lexema = "";
                            Estado = 0;
                            i--;

                        }

                        else if ("fecha".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 9; r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;

                            Agregar(Lexema, 17, "Palabra Reservada fecha", fila, columna, Tokens.TipoToken.FECHA);
                            Agregar2(Lexema, 17, "Palabra Reservada fecha", fila, columna, Tokens.TipoToken.FECHA);
                            Lexema = "";
                            Estado = 0;
                            i--;

                        }
                        else if ("flotante".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 9; r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 18, "Palabra Reservada flotante", fila, columna, Tokens.TipoToken.FLOTANTE);

                            Agregar2(Lexema, 18, "Palabra Reservada flotante", fila, columna, Tokens.TipoToken.FLOTANTE);
                            Lexema = "";
                            Estado = 0;
                            i--;

                        }
                        else if ("cadena".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 10; r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 19, "Palabra Reservada cadena", fila, columna, Tokens.TipoToken.CADENA);

                            Agregar2(Lexema, 19, "Palabra Reservada cadena", fila, columna, Tokens.TipoToken.CADENA);
                            r.SelectionStart = i + 1;
                            Lexema = "";
                            Estado = 0;
                            i--;

                        }
                        else if ("EN".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 11; r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 20, "Palabra Reservada EN", fila, columna, Tokens.TipoToken.EN);

                            Agregar2(Lexema, 20, "Palabra Reservada EN", fila, columna, Tokens.TipoToken.EN);
                            Lexema = "";
                            Estado = 0;
                            i--;
                        }
                        else if ("Y".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 11; r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 20, "Palabra Reservada Y", fila, columna, Tokens.TipoToken.Y);

                            Agregar2(Lexema, 20, "Palabra Reservada Y", fila, columna, Tokens.TipoToken.Y);
                            Lexema = "";
                            Estado = 0;
                            i--;
                        }
                        else if ("DONDE".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 12; r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 22, "Palabra Reservada Donde", fila, columna, Tokens.TipoToken.DONDE);

                            Agregar2(Lexema, 22, "Palabra Reservada Donde", fila, columna, Tokens.TipoToken.DONDE);
                            Lexema = "";
                            Estado = 0;
                            i--;

                        }
                        else if ("DE".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 12; r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 22, "Palabra Reservada De", fila, columna, Tokens.TipoToken.DE);

                            Agregar2(Lexema, 22, "Palabra Reservada De", fila, columna, Tokens.TipoToken.DE);
                            Lexema = "";
                            Estado = 0;
                            i--;

                        }
                        else if ("como".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 13; r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 23, "Palabra Reservada COMO", fila, columna, Tokens.TipoToken.COMO);

                            Agregar2(Lexema, 23, "Palabra Reservada COMO", fila, columna, Tokens.TipoToken.COMO);
                            Lexema = "";
                            Estado = 0;
                            i--;

                        }

                      
                        else if ("o".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 15; r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 25, "Palabra Reservada O", fila, columna, Tokens.TipoToken.O);

                            Agregar2(Lexema, 25, "Palabra Reservada O", fila, columna, Tokens.TipoToken.O);
                            Lexema = "";
                            Estado = 0;
                            i--;

                        }
                        else if ("O".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 15; r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 25, "Palabra Reservada O", fila, columna, Tokens.TipoToken.O);

                            Agregar2(Lexema, 25, "Palabra Reservada O", fila, columna, Tokens.TipoToken.O);
                            Lexema = "";
                            Estado = 0;
                            i--;

                        }
                        else if ("ESTABLECER".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {


                            idtoken = 16; r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 26, "Palabra Reservada Establecer", fila, columna, Tokens.TipoToken.ESTABLECER);

                            Agregar2(Lexema, 26, "Palabra Reservada Establecer", fila, columna, Tokens.TipoToken.ESTABLECER);
                            Lexema = "";
                            Estado = 0;
                            i--;

                        }
                        else if ("VALORES".Equals(Lexema, StringComparison.InvariantCultureIgnoreCase))
                        {

                            idtoken = 17; r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, idtoken, "Palabra Reservada Valores", fila, columna, Tokens.TipoToken.VALORES);

                            Agregar2(Lexema, idtoken, "Palabra Reservada Valores", fila, columna, Tokens.TipoToken.VALORES);
                            Lexema = "";
                            Estado = 0;
                            i--;
                        }


                        else

                        {
                            idtoken = 18; r.Select(indices - Lexema.Length+1, Lexema.Length);
                            r.SelectionColor = Color.Brown;


                            Agregar2(Lexema, 28, "Id", fila, columna, Tokens.TipoToken.ID);

                            Agregar(Lexema, 28, "Id", fila, columna, Tokens.TipoToken.ID);


                            Lexema = "";
                            Estado = 0;
                            i--;

                        }

                        break;
                    case 2:
                        if (Char.IsDigit(c))
                        {
                            Lexema += c;
                            r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;
                            Estado = 2;
                        }

                        else if (c == '.')
                        {
                            Lexema += c;
                            idtoken = 20; r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Blue;
                            r.SelectionStart = i + 1;

                            Estado = 3;
                        }
                        else
                        {
                            idtoken = 20; r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Blue;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 29, "Digitos", fila, columna, Tokens.TipoToken.DIGITO);

                            Agregar2(Lexema, 29, "Digitos", fila, columna, Tokens.TipoToken.DIGITO);
                            Lexema = "";
                            Estado = 0;
                            i--;

                        }



                        break;

                    case 3:
                        if (Char.IsDigit(c))
                        {
                            Lexema += c;
                            r.Select(i - Lexema.Length + 1, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;
                            Estado = 3;



                        }


                        else
                        {

                            Lexema += c;
                            idtoken = 20; r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Blue;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 30, "Decimal", fila, columna, Tokens.TipoToken.DECIMAL);

                            Agregar2(Lexema, 30, "Decimal", fila, columna, Tokens.TipoToken.DECIMAL);
                            Lexema = "";
                            Estado = 0;
                            i--;

                        }


                        break;

                    case 4:
                        if (c == ('\u0022'))
                        {
                            idtoken = 22;
                          
                            r.Select(i - Lexema.Length - 1, Lexema.Length);
                            Agregar(Lexema, 30, "comillas", fila, columna, Tokens.TipoToken.COMILLA);

                            Agregar2(Lexema, 30, "comillas", fila, columna, Tokens.TipoToken.COMILLA);
                            r.SelectionColor = Color.Green;
                            r.SelectionStart = i + 1;
                            Lexema = "";
                            Estado = 0;


                        }
                        else
                        {
                            Lexema += c;
                            columna++;
                            r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Green;
                            r.SelectionStart = i + 1;
                            Estado = 4;
                        }


                        break;

                    case 5:

                        if (c == '=')
                        {
                            idtoken = 22;
                            Lexema += c; r.Select(i - Lexema.Length + 1, Lexema.Length);

                            r.SelectionColor = Color.Red;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 31, "Menor Igual", fila, columna, Tokens.TipoToken.MENOR_IGUAL);

                            Agregar2(Lexema, 31, "Menor Igual", fila, columna, Tokens.TipoToken.MENOR_IGUAL);
                            Lexema = ""; Estado = 0;

                        } else
                        {
                            idtoken = 23;
                            r.Select(i - Lexema.Length + 1, Lexema.Length);

                            r.SelectionColor = Color.Red;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 32, "Menor ", fila, columna, Tokens.TipoToken.MENOR); Lexema = "";

                            Agregar2(Lexema, 32, "Menor ", fila, columna, Tokens.TipoToken.MENOR); Lexema = "";
                            Estado = 0;

                        }



                        break;
                    case 6:

                        if (c == '=')
                        {
                            idtoken = 24;
                            Lexema += c; r.Select(i - Lexema.Length + 1, Lexema.Length);

                            r.SelectionColor = Color.Red;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 33, "Mayor o Igual", fila, columna, Tokens.TipoToken.MAYOR_IGUAL);

                            Agregar2(Lexema, 33, "Mayor o Igual", fila, columna, Tokens.TipoToken.MAYOR_IGUAL);


                        }
                        else
                        {
                            idtoken = 25;
                            r.Select(i - Lexema.Length + 1, Lexema.Length);

                            r.SelectionColor = Color.Red;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 34, "Mayor ", fila, columna, Tokens.TipoToken.MAYOR); Lexema = "";

                            Agregar2(Lexema, 34, "Mayor ", fila, columna, Tokens.TipoToken.MAYOR); Lexema = "";
                            Estado = 0;

                        }



                        break;

                    case 7:

                  if (c == '*')
                        {
                            Estado = 9;
                            Lexema += c;
                            r.Select(i - Lexema.Length + 1, Lexema.Length);

                            r.SelectionColor = Color.Gray;
                            r.SelectionStart = i + 1;
                        }

                        break;
                    case 8:

                        if (c == '\n')
                        {
                            idtoken = 26;
                            r.Select(i - Lexema.Length, Lexema.Length);

                            r.SelectionColor = Color.Gray;
                            r.SelectionStart = i + 1;
                            Agregar2(Lexema, idtoken, "Comentario de Linea ", fila, columna, Tokens.TipoToken.COMENTARIO_MULTILINEA);
                            Lexema = "";
                            Estado = 0;
                            i--;
                        }
                        else
                        {
                            Estado = 8;
                            Lexema += c;
                            columna++;
                            r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Green;
                            r.SelectionStart = i + 1;
                        }
                        break;

                    case 9:

                        if (c == '*')
                        {
                            Lexema += c;
                            idtoken = 27;
                            r.Select(i - Lexema.Length - 1, Lexema.Length);

                            r.SelectionColor = Color.Gray;
                            r.SelectionStart = i + 1;
                          
                            Agregar2(Lexema, 35, "Comentario Multilinea", fila, columna, Tokens.TipoToken.COMENTARIO_MULTILINEA);
                            Lexema = "";
                            Estado = 0;
                        }

                        else
                        {
                            Estado = 9;
                            Lexema += c;
                            columna++;
                            r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Green;
                            r.SelectionStart = i + 1;

                        }
                        break;

                    case 10:

                        if (Char.IsDigit(c))
                        {
                            Estado = 11;
                            Lexema += c; columna++;
                            r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Orange;
                            r.SelectionStart = i + 1;


                        }
                        else
                        {
                            Agregar2E(Lexema, "Se esperaba digito", fila, columna);
                        }
                        break;

                    case 11:
                        if (Char.IsDigit(c))
                        {
                            Estado = 12;
                            Lexema += c;
                            r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Orange;
                            r.SelectionStart = i + 1;
                            columna++;

                        }
                        else
                        {
                            Agregar2E(Lexema, "Se esperaba digito", fila, columna);
                        }

                        break;

                    case 12:

                        if (c == '/')

                        {
                            Estado = 13;
                            Lexema += c;
                            columna++;
                            r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Orange;
                            r.SelectionStart = i + 1;
                        }
                        else
                        {
                            Agregar2E(Lexema, "Se esperaba /", fila, columna);
                        }
                        break;

                    case 13:

                        if (Char.IsDigit(c))
                        {
                            Estado = 14;
                            Lexema += c;
                            columna++;
                            r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Orange;
                            r.SelectionStart = i + 1;

                        }
                        else
                        {
                            Agregar2E(Lexema, "Se esperaba digito", fila, columna);
                        }
                        break;

                    case 14:
                        if (Char.IsDigit(c))
                        {
                            Estado = 15;
                            Lexema += c;
                            columna++;
                            r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Orange;
                            r.SelectionStart = i + 1;

                        }
                        else
                        {
                            Agregar2E(Lexema, "Se esperaba digito", fila, columna);
                        }
                        break;

                    case 15:
                        if (c == '/')
                        {
                            Estado = 16;
                            Lexema += c;
                            columna++;
                            r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Black;
                            r.SelectionStart = i + 1;

                        }
                        else
                        {
                            Agregar2E(Lexema, "Se esperaba /", fila, columna);
                        }
                        break;
                    case 16:
                        if (Char.IsDigit(c))
                        {
                            Estado = 17;
                            Lexema += c;
                            columna++;
                            r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Orange;
                            r.SelectionStart = i + 1;

                        }
                        else
                        {
                            Agregar2E(Lexema, "Se esperaba digito", fila, columna);
                        }
                        break;
                    case 17:
                        if (Char.IsDigit(c))
                        {
                            Estado = 18;
                            Lexema += c;
                            columna++;
                            r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Orange;
                            r.SelectionStart = i + 1;

                        }
                        else
                        {
                            Agregar2E(Lexema, "Se esperaba digito", fila, columna);
                        }
                        break;
                    case 18:
                        if (Char.IsDigit(c))
                        {
                            Estado = 19;
                            Lexema += c;
                            columna++;
                            r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Orange;
                            r.SelectionStart = i + 1;

                        }
                        else
                        {
                            Agregar2E(Lexema, "Se esperaba digito", fila, columna);
                        }
                        break;
                    case 19:
                        if (Char.IsDigit(c))
                        {
                            Estado = 21;
                            Lexema += c;
                            columna++;
                            r.Select(i - Lexema.Length, Lexema.Length);
                            r.SelectionColor = Color.Orange;
                            r.SelectionStart = i + 1;


                        }
                        else
                        {
                            Agregar2E(Lexema, "Se esperaba digito", fila, columna);
                        }
                        break;

                    case 20:
                        if (c == '=')
                        {
                            Lexema += c;
                            columna++;
                            idtoken = 29;
                            indice++; r.Select(i - Lexema.Length, Lexema.Length);

                            r.SelectionColor = Color.Orange;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 38, "Diferente", fila, columna, Tokens.TipoToken.DIFERENTE);

                            Agregar2(Lexema, 38, "Diferente", fila, columna, Tokens.TipoToken.DIFERENTE);
                          Lexema = "";
                            Estado = 0;
                 

                        }
                        break;
                    case 21:

                        if (c == '\'')
                        {
                            Lexema += c;
                            columna++;
                            idtoken = 28;
                            indice++; r.Select(i - Lexema.Length-1, Lexema.Length);

                            r.SelectionColor = Color.Orange;
                            r.SelectionStart = i + 1;
                            Agregar(Lexema, 36, "Fecha", fila, columna, Tokens.TipoToken.FECHAS);

                            Agregar2(Lexema, 36, "Fecha", fila, columna, Tokens.TipoToken.FECHAS); 
                            Lexema = "";
                            Estado = 0;
                        }

                        break;
                    case 22:

                         if (c == '-')
                        {
                            Lexema += c;
                            columna++;
                            Estado = 23;

                        }
                        break;

                    case 23:

                        if (c=='\n')
                        {
                            Agregar(Lexema, 37, "COMENTARIO DE LINEA", fila, columna, Tokens.TipoToken.COMENTARIO_LINEA);
                            Lexema = "";
                            Estado = 0;
                        }
                        else
                        {

                            columna++;
                            Lexema += c;
                            Estado = 23;
                        }


                        break;
                  

                }

            }
    
            PARS.Parsear(Tks);
            
        
            
        }
        public void Reporte()
        {

            Html(Tks2);
            Html2(ErTks);
            PARS.Grafo();
        }
        public void Arbol()
        {
            SS.Parsear(Tks);
            SS.Grafo();
        }
        public void Tablas()
        {
            
                S.Parsear(Tks);

                S.Grafo();
            S.GrafoPrueba();
            
        }

        public void Consulta()
        {
            S.Parsear(Tks);

            S.Consulta();
            S.GrafoConsulta();
        }
        public void VerTabla()
        {
            S.Grafo();
        }
        void Agregar2(string Lexema, int Idtoken, string tipo, int fila, int columna, Tokens.TipoToken alb)
        {
            Tks.AddLast(new Tokens(Lexema, Idtoken, tipo, fila, columna,alb));
         
        }
        void Agregar(string Lexema, int Idtoken, string tipo, int fila, int columna, Tokens.TipoToken alb)
        {
            Tks2.AddLast(new Tokens(Lexema, Idtoken, tipo, fila, columna, alb));

        }
      public   void Agregar2E(string lexema, string descripcion, int columna, int fila)
        {
            ErTks.AddLast(new ErroresTokens(lexema, descripcion, columna, fila)); 

        }
        public void Html(LinkedList<Tokens> TTokens)
        {
            SaveFileDialog GuardarHtml = new SaveFileDialog();
            GuardarHtml.Filter = "HTML|*.html";
            if (GuardarHtml.ShowDialog() == DialogResult.OK)
            {
                string direccion = GuardarHtml.FileName;
                StreamWriter pagina = new StreamWriter(direccion);
                String codigoHtml =
                 "<html >"
                + "<tittle> Reporte de Tokens "
             + " </tittle>"
             + "        <link rel = stylesheet href= estilos3.css>"
              + "    <head>"

                + "        <title>Reporte </title>"
                + "    </head>"
                + "    <body>\n"

           ;
                if (TTokens.Count > 0)
                {

                    codigoHtml += "<center>"
               + "        <h1> Reporte TOkens</h1>"
               + "        <table border=4>"

               + "                <tr>"
               + "                    <td>No#</td>"
               + "                    <td>Lexema</td>"
               + "                    <td>Id token</td>"
               + "                    <td>Token</td>"
               + "                    <td>Fila</td>"
               + "                    <td>Columna</td>"



               + "                          </tr> "

               ;
                    int cont = 0;
                    foreach (Tokens correctos in TTokens)
                    {
                        cont++;
                        codigoHtml += " <tr>"
               + "    <td>" + cont + "</td>"
                + "    <td>" + correctos.getLexema() + "</td>"
               + "    <td>" + correctos.getIdToken() + "</td>"
               + "    <td>" + correctos.getTipo1() + "</td>"
               + "    <td>" + correctos.geTfila() + "</td>"
               + "    <td>" + correctos.getcolumna() + "</td>"



                + "  </tr>";


                    }
                    codigoHtml += "     </Tbody> <t/table>  <br<br>   ";



                }


                codigoHtml += "</body > </html > ";
                pagina.Write(codigoHtml);
                pagina.Close();
            }
        }

        private void Html2(LinkedList<ErroresTokens> TErrores)
        {
            SaveFileDialog GuardarHtml = new SaveFileDialog();
            GuardarHtml.Filter = "HTML|*.html";
            if (GuardarHtml.ShowDialog() == DialogResult.OK)
            {
                String direccion = GuardarHtml.FileName;
                StreamWriter pagina = new StreamWriter(direccion);
                String codigoHtml =
                 "<html >"
                + "    <head>"
                + "        <title>Reporte </title>"
                + "    </head>"
                + "    <body>\n"

           ;




                if (TErrores.Count > 0)
                {


                    codigoHtml += "    <center>" +
                "        <h4> Reporte  Errores TOkens</h4>"
               + "        <table border=4>"

               + "                <tr>"
               + "                    <td>#</td>"
               + "                    <td>Fila</td>"
               + "                    <td>Columna</td>"
               + "                    <td>Token</td>"
               + "        <td>Descripcion</td>"
               + "                                     " +
               "        </tr> "
               ;

                    foreach (ErroresTokens incorrectos in TErrores)
                    {
                        codigoHtml += " <tr>\n"
               + "    <td>" + incorrectos.getindice() + "</td>"
                + "    <td>" + incorrectos.getFila() + "</td>"
               + "    <td>" + incorrectos.getColumna() + "</td>"
               + "    <td>" + incorrectos.getLexema() + "</td>"

               + "    <td>" + incorrectos.getDescripcion() + "</td>"


                + "  </tr>";


                    }
                    codigoHtml += " </Tbody> <t/table>  </table><br<br>";
                }
                codigoHtml += "</body > </html > ";
                pagina.Write(codigoHtml);
                pagina.Close();
            }
        }


    }
}
