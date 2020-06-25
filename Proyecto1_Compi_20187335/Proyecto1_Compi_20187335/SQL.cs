using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_Compi_20187335
{
    class SQL
    {
        LinkedList<ObjetoCool> cool = new LinkedList<ObjetoCool>();

        LinkedList<ObjetoCool> cool2 = new LinkedList<ObjetoCool>();

        LinkedList<ObjetoCool> cool3 = new LinkedList<ObjetoCool>();
        LinkedList <Object> ayudaaaa = new LinkedList<Object>();
        LinkedList<Object> ayudaaaa2 = new LinkedList<Object>();
        LinkedList<Object> ayudaaaa3 = new LinkedList<Object>();
        LinkedList<Object> ayudaaaa4 = new LinkedList<Object>();
        LinkedList<Object> RemplA = new LinkedList<Object>();
        LinkedList<Object> CampoR = new LinkedList<Object>();
        LinkedList<int> ayudita = new LinkedList<int>();
        LinkedList<String> ListaTablas= new LinkedList<String>();

        ListaTablas Table = new ListaTablas();
        bool ayuda = false;
        
        bool caso1 = false;
        bool caso11 = false;
        bool caso2 = false; bool caso3 = false; bool caso4 = false;
        bool caso22 = false; bool caso33 = false; bool caso44 = false;

        int cont = 0;

        Tokens alvAct;

        LinkedList<Tokens> ListaTok;

        LinkedList<Remplazo> Remplazos= new LinkedList<Remplazo>();
        LinkedList<Atributo> NewT = new LinkedList<Atributo>();
        public void Parsear(LinkedList<Tokens> tokens)
        {
            this.ListaTok = tokens;
            cont = 0;
            alvAct = ListaTok.ElementAt(cont);

            Start();
        }

        void Start()
        {

            COMIENZO();
            OPCIONES();

        }
        void COMIENZO()
        {
            Console.WriteLine("Comienzo" + "--->" + " " + alvAct.getLexema());
             elimibnar = false;
            act = false;
            if (alvAct.getTipo_Token() == Tokens.TipoToken.CREAR || alvAct.getTipo_Token() == Tokens.TipoToken.INSERTAR
                || alvAct.getTipo_Token() == Tokens.TipoToken.ELIMINAR || alvAct.getTipo_Token() == Tokens.TipoToken.SELECCIONAR
               || alvAct.getTipo_Token() == Tokens.TipoToken.ACTUALIZAR)
            {

                OPCIONES();
                COMIENZO();
            }
            else
            {
            }

        }

        void OPCIONES()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.CREAR)
            {
                emparejar(Tokens.TipoToken.CREAR);
                CREART();

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.INSERTAR)
            {
                emparejar(Tokens.TipoToken.INSERTAR);



                INSERTAR();
            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.SELECCIONAR)
            {
                emparejar(Tokens.TipoToken.SELECCIONAR);

                Seleccionar();
            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.ELIMINAR)
            {
                emparejar(Tokens.TipoToken.ELIMINAR);

                ELIMINAR();
            }

            else if (alvAct.getTipo_Token() == Tokens.TipoToken.ACTUALIZAR)
            {
                emparejar(Tokens.TipoToken.ACTUALIZAR);

                ACTUALIZAR();
            }

        }
        bool act = false;

        String CampoAct = "";
        String Rempla = "";
        void ACTUALIZAR()
        {
            CampoR = new LinkedList<Object>();
            RemplA = new LinkedList<Object>();
           
            TablaE = alvAct.getLexema();
            act=true;
            emparejar(Tokens.TipoToken.ID);
            emparejar(Tokens.TipoToken.ESTABLECER);
            emparejar(Tokens.TipoToken.PARENTESIS_ABIERTO);
            Est();
            emparejar(Tokens.TipoToken.PARENTESIS_CERRADO);
            WHERE();
            emparejar(Tokens.TipoToken.PUNTO_y_COMA);

            ayuda = false;

        }

        void Est()
        {
            CampoR.AddLast(alvAct.getLexema());
            emparejar(Tokens.TipoToken.ID);

            emparejar(Tokens.TipoToken.IGUAL);
            DATO2();
            Est2();
        }
        void Est2()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.COMA)
            {
                emparejar(Tokens.TipoToken.COMA);
                Est();

            }
            else
            {
                //efeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
            }
        }
        bool elimibnar = false;
        String TablaE = "";
        void ELIMINAR()
        {
            elimibnar = true;

            emparejar(Tokens.TipoToken.DE);

            TablaE = alvAct.getLexema();
            emparejar(Tokens.TipoToken.ID);
            WHERE();
            if (WHERE_Eliminar==true)
            {
                 Table.Eliminar(TablaE);

             
                

            }
            emparejar(Tokens.TipoToken.PUNTO_y_COMA);
            ayuda = false;
            elimibnar = false;
        }
        void VolarTABLA()
        {

        }

        String Tabla = "";
        String Remplazo = "";
        String Columna =
            "";
        bool actualizar = false;
        void Seleccionar()
        {
            Remplazos = new LinkedList<Remplazo>();
            Selection();
            ListaTablas = new LinkedList<String>();

            emparejar(Tokens.TipoToken.DE);
            EscogerTabla();

            WHERE();

            emparejar(Tokens.TipoToken.PUNTO_y_COMA);
        }
        void Selection()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.Asterisco)
            {
                actualizar = true;
                emparejar(Tokens.TipoToken.Asterisco);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.ID)
            {
                Tabla = alvAct.getLexema();
                Columna = alvAct.getLexema();
                emparejar(Tokens.TipoToken.ID);
                OP();



            }
            else
            {
                OtherSelecction();
            }
        }
        void OP()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.PUNTO)
            {

                emparejar(Tokens.TipoToken.PUNTO);
                Columna = alvAct.getLexema();
                emparejar(Tokens.TipoToken.ID);
                AliasSeleccionar();
            }
            else
            {
                Tabla = "";

                AliasSeleccionar();

            }
        }

        void OtherSelecction()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.COMA)
            {
                emparejar(Tokens.TipoToken.COMA);
                SelectS();
            }

        }
        void SelectS()
        {


            emparejar(Tokens.TipoToken.ID);
            emparejar(Tokens.TipoToken.PUNTO);
            TipoSelects();


        }
        void TipoSelects()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.ID)
            {
                emparejar(Tokens.TipoToken.ID);
                AliasSeleccionar();
                OtherSelecction();

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.Asterisco)
            {

                emparejar(Tokens.TipoToken.Asterisco);     
                OtherSelecction();
            }
        }
        void AliasSeleccionar()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.COMO)
            {
                emparejar(Tokens.TipoToken.COMO);
                Remplazo = alvAct.getLexema();
                Remplazos.AddLast(new Remplazo(Tabla, Columna, Remplazo));
                emparejar(Tokens.TipoToken.ID);
                Other_seleccionR();

            }
            else
            {
                //EFE
            }


        }
        void Other_seleccionR()
        {

            if (alvAct.getTipo_Token() == Tokens.TipoToken.COMA)
            {
                emparejar(Tokens.TipoToken.COMA);
                Selection();
            }
            else
            {
                //efe
            }
        }
void LlenarSano(String a)
        {
            Tablas T = Table.Bucar(a);

            foreach (Atributo alv in T.A)
            {
                foreach (Object item in alv.Objetos)
                {
                    NewT.AddLast(new Atributo(alv.GetNombre(),alv.GetTIPO(), alv.GetNombre()));

                }
            }
        }
        void LlenarSano2(String a)
        {
            foreach (Atributo alv in NewT)
            {
                Tablas T = Table.Bucar(a);
                foreach (Atributo alv2 in T.A)
                {
                    if (alv.GetPrecedencia().Equals(alv2.GetNombre()))
                    {
                        alv.Objetos = alv2.Objetos;
                    }

                }
            }
        }
            void EscogerTabla()
        {
            if (actualizar==true)
            {
                LlenarSano(alvAct.getLexema());
                LlenarSano2(alvAct.getLexema());

            }
            else if (actualizar==false)
            {
                ComoMiex(alvAct.getLexema());

            }

            ListaTablas.AddLast(alvAct.getLexema());

            emparejar(Tokens.TipoToken.ID);
            OtherTable();
        }
        void OtherTable()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.COMA)
            {
                emparejar(Tokens.TipoToken.COMA);
                EscogerTabla();

            }
            else
            {
                //EPSILON
            }

        }
        bool WHERE_Eliminar = false;
        void WHERE()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.DONDE)
            {
                emparejar(Tokens.TipoToken.DONDE);
                CONDITION();

            }
            else
            {
                WHERE_Eliminar = true;
                //eefe
            }

        }
        String COlumna1;
        String Columna2;
            String TABLA1;  String TABLA2B;
        String Colaux = "";
        void CONDITION()
        {
            TABLA1 = alvAct.getLexema(); emparejar(Tokens.TipoToken.ID); IDCondicion(); TipoCondicion(); OtraCondicion();
           

        }
        void OtraCondicion()
        {
            if (alvAct.getTipo_Token()==Tokens.TipoToken.COMA)
            {
                emparejar(Tokens.TipoToken.COMA);
                CONDITION();
            }
            else
            {


                //efeeeee
            }
        }
        void IDCondicion()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.PUNTO)
            {
                emparejar(Tokens.TipoToken.PUNTO);
                COlumna1 = alvAct.getLexema();
                emparejar(Tokens.TipoToken.ID);
                caso1 = true;

            }
            else
            {
                caso4 = true;               
                //efe
            }

        }
        String Dato = "";
        String TDato = "";
        String Simbolo = "";
        void TipoCondicion()
        {


            if (alvAct.getTipo_Token() == Tokens.TipoToken.IGUAL || alvAct.getTipo_Token() == Tokens.TipoToken.DIFERENTE
                || alvAct.getTipo_Token() == Tokens.TipoToken.MAYOR || alvAct.getTipo_Token() == Tokens.TipoToken.MAYOR_IGUAL
                || alvAct.getTipo_Token() == Tokens.TipoToken.MENOR || alvAct.getTipo_Token() == Tokens.TipoToken.MENOR_IGUAL
                    || alvAct.getTipo_Token() == Tokens.TipoToken.DIFERENTE)

            {
                SYMBOL(); DATO1();
                if (caso1==true && caso11==true)
                {

                    Console.WriteLine(COlumna1 + "---" + Columna2+" "+Simbolo);
                    Caso1(TABLA1, COlumna1, TABLA2B, Columna2, Simbolo);  
                }
                else if (caso1==true && caso2 ==true)
                {
                    Caso2(TABLA1, COlumna1, Dato, TDato, Simbolo);
                }

                else if (caso1==true && caso3==true)
                {
                    Caso3(TABLA1, COlumna1, Colaux, Simbolo);
                }

                else if (caso4==true && caso3==true)
                {
                    Caso4(TABLA1, Colaux, Simbolo);
                }
                else if (caso4==true && caso2==true)
                {
                    Caso5(TABLA1, Dato, TDato, Simbolo);
                }
                else if (caso4 == true && caso11 == true)
                {
                    Caso6(TABLA1 ,TABLA2B, Columna2, Simbolo);

                }
                caso1 = false; caso11 = false; caso2 = false;
                caso3 = false; caso4 = false;
                YO_CONDITION(); 


            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.PUNTO)
            {
                emparejar(Tokens.TipoToken.PUNTO); emparejar(Tokens.TipoToken.ID); SYMBOL(); DATO1(); YO_CONDITION();


            }
        }
        void YO_CONDITION()
        {

            if (alvAct.getTipo_Token() == Tokens.TipoToken.Y)
            {
                emparejar(Tokens.TipoToken.Y); CONDITION();

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.O)
            {
                emparejar(Tokens.TipoToken.O); CONDITION();

            }
            else
            {
                //EPSILOON
            }
        }
        void DATO2()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.DIGITO)
            {
                Remplazo = alvAct.getLexema();
                RemplA.AddLast(alvAct.getLexema());
                emparejar(Tokens.TipoToken.DIGITO);



            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.DECIMAL)
            {
                Remplazo = alvAct.getLexema();

                RemplA.AddLast(alvAct.getLexema());
                emparejar(Tokens.TipoToken.DECIMAL);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.FECHAS)
            {
                Remplazo = alvAct.getLexema();

                RemplA.AddLast(alvAct.getLexema());
                emparejar(Tokens.TipoToken.FECHAS);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.COMILLA)
            {
                RemplA.AddLast(alvAct.getLexema());
                Remplazo = alvAct.getLexema();
                emparejar(Tokens.TipoToken.COMILLA);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.ID)
            {
                Remplazo = alvAct.getLexema();

                RemplA.AddLast(alvAct.getLexema());
                emparejar(Tokens.TipoToken.ID);
            

            }
            else
            {
                //EFEEE
            }


        }
        void DATO1()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.DIGITO)
            {
                Dato = alvAct.getLexema();
                TDato = "entero";
                caso2 = true;
                emparejar(Tokens.TipoToken.DIGITO);



            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.DECIMAL)
            {
                Dato = alvAct.getLexema();
                TDato = "decimal";
                caso2 = true;
                emparejar(Tokens.TipoToken.DECIMAL);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.FECHAS)
            {
                Dato = alvAct.getLexema();
                TDato = "fecha";
                caso2 = true;
                emparejar(Tokens.TipoToken.FECHAS);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.COMILLA)
            {
                Dato = alvAct.getLexema();
                TDato ="cadena";
                caso2 = true;
                emparejar(Tokens.TipoToken.COMILLA);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.ID)
            {
                Remplazo = alvAct.getLexema();
                Colaux = alvAct.getLexema();
                TABLA2B = alvAct.getLexema();
                emparejar(Tokens.TipoToken.ID);
                IDCondicion2();

            }
            else
            {
                //EFEEE
            }


        }
        void ComoMiex(String R)
        {
            Tablas ayuda = Table.Bucar(R);
            foreach (Remplazo alv in Remplazos)
            {
                if (alv.GetTabla().Equals(""))
                {
                    foreach (Atributo aux in ayuda.A)
                    {
                        if (alv.GetColumna().Equals(aux.GetNombre()))
                        {
                            NewT.AddLast(new Atributo(alv.GetRemplazo().ToString(), aux.GetTIPO(), aux.GetNombre()));
                        }
                    }

                }
                else
                {
                    Tablas ayuda2 = Table.Bucar(alv.GetTabla().ToString());

                    foreach (Atributo aux in ayuda2.A)
                    {
                        if (alv.GetColumna().Equals(aux.GetNombre()))
                        {
                            NewT.AddLast(new Atributo(alv.GetRemplazo().ToString(), aux.GetTIPO(),aux.GetNombre()));


                        }
                    }
                }

            }
        }

        void Llenar(LinkedList<int> ayuda  , String Columna, String TABLA)
        {

            bool a1 = false;

            bool a2 = false;

            Tablas ALV = Table.Bucar(TABLA);

          
            

            foreach (Atributo atri in NewT)
                {
                    foreach (Atributo aux in ALV.A)
                    {

                        if (atri.GetPrecedencia().Equals(aux.GetNombre()))
                        {
                            foreach (int i in ayuda)
                            {
                                atri.Objetos.AddLast(aux.Objetos.ElementAt(i));

                            }


                        }
                    }
                }

            

          
        }
        void Llenar2(LinkedList<ObjetoCool> ayuda)
        {

            foreach (Atributo atri in NewT)
            {
                foreach (ObjetoCool alv in ayuda)
                {
                    foreach (String olv in ListaTablas)
                    {
                        Tablas T = Table.Bucar(olv);

                        if (alv.GetTabla().Equals(T.GetNombre()))
                        {
                            foreach (Atributo atrix in T.A)
                            {
                                if (atri.GetPrecedencia().Equals(atrix.GetNombre()))
                                {
                                    atri.Objetos.AddLast(atrix.Objetos.ElementAt(alv.GetpOS()));
                                }
                            }
                        }
                    }
                }
            }
        
        }

        void Caso6(String TABLAA, String TABLA22B, String Columna22, String Simboloo)
        {
            bool a = false;
            bool a2 = false;
            int cont = 0;
            int cont2 = 0;

            cool = new LinkedList<ObjetoCool>();

            cool2 = new LinkedList<ObjetoCool>();
            cool3 = new LinkedList<ObjetoCool>();
            ayudaaaa = new LinkedList<Object>();
            ayudaaaa2 = new LinkedList<Object>();
            ayudaaaa3 = new LinkedList<Object>();
            ayudita = new LinkedList<int>();
            Tablas Tabla2 = Table.Bucar(TABLA22B);

            Atributo alv2 = new Atributo();
            foreach (Atributo alv4 in Tabla2.A)
            {
                Console.WriteLine(alv4.GetNombre() + "--");

                if (Columna22.Equals(alv4.GetNombre()))
                {
                    Console.WriteLine("siuuu2");
                    a2 = true;
                    alv2.Objetos = alv4.Objetos;


                }



            }
            foreach (String olv in ListaTablas)
            {
                Tablas T = Table.Bucar(olv);
                foreach (Atributo atri in T.A)
                {
                    if (atri.GetNombre().Equals(TABLAA))
                    {
                        foreach (Object item in atri.Objetos)
                        {
                            a = true;
                            cool.AddLast(new ObjetoCool(item, T.GetNombre(), cont));

                            Console.WriteLine(item + "-" + T.GetNombre() + "-" + cont);
                            cont++;
                        }

                        cont = 0;
                    }


                }

            }


            if (a == true && a2 == true)
            {


                foreach (ObjetoCool AUX in cool)
                {
                    foreach (Object AUX2 in alv2.Objetos)
                    {




                        if (AUX.GetNombre().Equals(AUX2) && Simbolo.Equals("="))
                        {
                            Console.WriteLine("encontrado");

                            cool3.AddLast(new ObjetoCool(AUX.GetNombre(), AUX.GetTabla(), AUX.GetpOS()));

                            if (AUX.GetTabla().Equals(TablaE))
                            {
                                ayudita.AddLast(AUX.GetpOS());

                            }

                        }

                        else if (AUX.GetNombre() != AUX2 && Simbolo.Equals("!="))
                        {
                            Console.WriteLine("encontrado");

                            cool3.AddLast(new ObjetoCool(AUX.GetNombre(), AUX.GetTabla(), AUX.GetpOS()));

                            if (AUX.GetTabla().Equals(TablaE))
                            {
                                ayudita.AddLast(AUX.GetpOS());

                            }
                        }

                        else if (Convert.ToInt32(AUX.GetNombre()) < Convert.ToInt32(AUX2.ToString()) && Simbolo.Equals("<"))
                        {
                            Console.WriteLine("encontrado");

                            cool3.AddLast(new ObjetoCool(AUX.GetNombre(), AUX.GetTabla(), AUX.GetpOS()));

                            if (AUX.GetTabla().Equals(TablaE))
                            {
                                ayudita.AddLast(AUX.GetpOS());

                            }

                        }
                        else if (Convert.ToInt32(AUX.GetNombre()) <= Convert.ToInt32(AUX2.ToString()) && Simbolo.Equals("<="))
                        {
                            Console.WriteLine("encontrado");

                            cool3.AddLast(new ObjetoCool(AUX.GetNombre(), AUX.GetTabla(), AUX.GetpOS()));

                            if (AUX.GetTabla().Equals(TablaE))
                            {
                                ayudita.AddLast(AUX.GetpOS());

                            }

                        }
                        else if (Convert.ToInt32(AUX.GetNombre()) > Convert.ToInt32(AUX2.ToString()) && Simbolo.Equals(">"))
                        {
                            Console.WriteLine("encontrado");

                            cool3.AddLast(new ObjetoCool(AUX.GetNombre(), AUX.GetTabla(), AUX.GetpOS()));

                            if (AUX.GetTabla().Equals(TablaE))
                            {
                                ayudita.AddLast(AUX.GetpOS());

                            }

                        }
                       
                        else if (Convert.ToInt32(AUX.GetNombre()) >= Convert.ToInt32(AUX2.ToString()) && Simbolo.Equals(">="))
                        {
                            Console.WriteLine("encontrado");

                            cool3.AddLast(new ObjetoCool(AUX.GetNombre(), AUX.GetTabla(), AUX.GetpOS()));

                            if (AUX.GetTabla().Equals(TablaE))
                            {
                                ayudita.AddLast(AUX.GetpOS());

                            }

                        }
                    
                    }
                    cont++;
                }
            }
            else
            {
                MessageBox.Show("efe");
            }


            if (elimibnar == false && act == false)
            {

                Llenar2(cool3);

            }
            else if (elimibnar == true)
            {
                BorrarChido(ayudita);
            }
            else if (act == true)
            {
                ActChido(ayudita);
            }



        }
        void Caso5(String TABLA11, String Dato, String TDato, String  Simbolo)
        {
            bool a = false;
            bool a2 = false;
            int cont = 0;
            int cont2 = 0;

            cool = new LinkedList<ObjetoCool>();

            cool2 = new LinkedList<ObjetoCool>();
            cool3 = new LinkedList<ObjetoCool>();
            ayudaaaa = new LinkedList<Object>();
            ayudaaaa2 = new LinkedList<Object>();
            ayudaaaa3 = new LinkedList<Object>();
            ayudita = new LinkedList<int>();
            foreach (String olv in ListaTablas)
            {
                Tablas T = Table.Bucar(olv);
                foreach (Atributo atri in T.A)
                {
                    if (atri.GetNombre().Equals(TABLA11))
                    {
                        foreach (Object item in atri.Objetos)
                        {
                            a = true;
                            cool.AddLast(new ObjetoCool(item, T.GetNombre(), cont));

                            Console.WriteLine(item + "-" + T.GetNombre() + "-" + cont);
                            cont++;
                        }

                        cont = 0;
                    }


                }

            }

            if (a == true)
            {
                foreach (ObjetoCool XD in cool)
                {
                    if (TDato.Equals("entero"))
                    {


                        Console.WriteLine(XD.GetNombre() + " " + TDato + " " + Simbolo + Dato);
                        if (Simbolo.Equals("=") && Dato.Equals(XD.GetNombre()))
                        {
                            Console.WriteLine("encontrado");



                            if (XD.GetTabla().Equals(TablaE))
                            {
                                ayudita.AddLast(XD.GetpOS());

                            }
                            cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));


                        }
                        else if (Simbolo.Equals("!="))
                        {
                            if (Convert.ToInt32(XD.GetNombre()) != Int32.Parse(Dato))
                            {
                                if (XD.GetTabla().Equals(TablaE))
                                {
                                    ayudita.AddLast(XD.GetpOS());

                                }
                                cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));

                                Console.WriteLine("encontrado"); ayudita.AddLast(cont);
                            }


                        }
                        else if (Simbolo.Equals("<"))
                        {
                            if (Convert.ToInt32(XD.GetNombre()) <= Int32.Parse(Dato))
                            {
                                if (XD.GetTabla().Equals(TablaE))
                                {
                                    ayudita.AddLast(XD.GetpOS());

                                }


                                Console.WriteLine("encontrado");
                                cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));

                            }
                        }
                        else if (Simbolo.Equals("<="))
                        {
                            if (Convert.ToInt32(XD.GetNombre()) <= Int32.Parse(Dato))
                            {

                                if (XD.GetTabla().Equals(TablaE))
                                {
                                    ayudita.AddLast(XD.GetpOS());

                                }

                                Console.WriteLine("encontrado");
                                cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));

                            }
                        }
                        else if (Simbolo.Equals(">"))
                        {
                            if (Int32.Parse(Dato) > Int32.Parse(XD.GetNombre().ToString()))
                            {

                                if (XD.GetTabla().Equals(TablaE))
                                {
                                    ayudita.AddLast(XD.GetpOS());

                                }

                                Console.WriteLine("encontrado");
                                cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));

                            }
                        }
                        else if (Simbolo.Equals(">=") && Convert.ToInt32(XD.GetNombre()) >= Int32.Parse(Dato))
                        {
                            if (XD.GetTabla().Equals(TablaE))
                            {
                                ayudita.AddLast(XD.GetpOS());

                            }
                            Console.WriteLine("encontrado");
                            cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));


                        }
                    }
                    else if (Simbolo.Equals("=") && Dato.Equals(XD.GetNombre()) && TDato.Equals("cadena"))
                    {
                        if (XD.GetTabla().Equals(TablaE))
                        {
                            ayudita.AddLast(XD.GetpOS());

                        }
                        Console.WriteLine("encontrado");
                        cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));


                    }
                    else if (Dato != XD.GetNombre().ToString() && Simbolo.Equals("!=") && TDato.Equals("cadena"))
                    {
                        if (XD.GetTabla().Equals(TablaE))
                        {
                            ayudita.AddLast(XD.GetpOS());

                        }
                        Console.WriteLine("encontrado");
                        cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));


                    }
                    else if (Simbolo.Equals("=") && Dato.Equals(XD.GetNombre()) && TDato.Equals("fecha"))
                    {
                        if (XD.GetTabla().Equals(TablaE))
                        {
                            ayudita.AddLast(XD.GetpOS());

                        }
                        Console.WriteLine("encontrado");
                        cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));


                    }
                    else if (Dato != XD.GetNombre().ToString() && Simbolo.Equals("!=") && TDato.Equals("fecha"))
                    {
                        if (XD.GetTabla().Equals(TablaE))
                        {
                            ayudita.AddLast(XD.GetpOS());

                        }
                        Console.WriteLine("encontrado");
                        cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));


                    }
                    /* else if (DateTime.Parse(Dato) < DateTime.Parse(XD.ToString()) && Simbolo.Equals("<") && TDato.Equals("fecha"))
                     {
                         Console.WriteLine("encontrado");
                      cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));


                     }
                     else if (DateTime.Parse(Dato) <= DateTime.Parse(XD.ToString()) && Simbolo.Equals("<=") && TDato.Equals("fecha"))
                     {
                         Console.WriteLine("encontrado");
                          cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));


                     }
                     else if (DateTime.Parse(Dato) > DateTime.Parse(XD.ToString()) && Simbolo.Equals(">") && TDato.Equals("fecha"))
                     {
                         Console.WriteLine("encontrado");
                          cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));


                     }
                     else if (DateTime.Parse(Dato) >= DateTime.Parse(XD.ToString()) && Simbolo.Equals(">=") && TDato.Equals("fecha"))
                     {
                         Console.WriteLine("encontrado");
                        cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));
      ayudita.AddLast(cont);

                     }*/
                    /* else if (float.Parse(Dato) == float.Parse(XD.ToString()) && Simbolo.Equals("=") && TDato.Equals("decimal"))
                     {
                         Console.WriteLine("encontrado");
                        cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));


                     }*/
                    /*  else if (float.Parse(Dato) != float.Parse(XD.ToString()) && Simbolo.Equals("!=") && TDato.Equals("decimal"))
                      {
                          Console.WriteLine("encontrado");
                       cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));


                      }
                      else if (float.Parse(Dato) < float.Parse(XD.ToString()) && Simbolo.Equals("<") && TDato.Equals("decimal"))
                      {
                          Console.WriteLine("encontrado");
                        cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));


                      }
                      else if (float.Parse(Dato) <= float.Parse(XD.ToString()) && Simbolo.Equals("<=") && TDato.Equals("decimal"))
                      {
                          Console.WriteLine("encontrado");
                      cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));

                      }
                      else if (float.Parse(Dato) >= float.Parse(XD.ToString()) && Simbolo.Equals(">=") && TDato.Equals("decimal"))
                      {
                          Console.WriteLine("encontrado");
          cool3.AddLast(new ObjetoCool(XD.GetNombre(), XD.GetTabla(), XD.GetpOS()));


                      }
                      */
                }

            }
            else
            {
                Console.WriteLine("truena");
            }

            if (elimibnar == false && act == false)
            {

                Llenar2(cool3);

            }
            else if (elimibnar == true)
            {
                BorrarChido(ayudita);
            }
            else if (act == true)
            {
                ActChido(ayudita);
            }
        }
        void Caso4(String TABLA11, String Colaux,String  Simbolo)
        {
            bool a = false;
            bool a2 = false;
            int cont = 0;
            int cont2 = 0;

            cool = new LinkedList<ObjetoCool>();
           
            cool2 = new LinkedList<ObjetoCool>();
            cool3 = new LinkedList<ObjetoCool>();
            ayudaaaa = new LinkedList<Object>();
            ayudaaaa2 = new LinkedList<Object>();
         ayudaaaa3 = new LinkedList<Object>();
            ayudita = new LinkedList<int>();
            foreach (String olv in ListaTablas)
            {
                Tablas T = Table.Bucar(olv);
                foreach (Atributo atri in T.A)
                {
                    if (atri.GetNombre().Equals(TABLA11))
                    {
                        foreach (Object item in atri.Objetos)
                        {
                            a = true;
                    cool.AddLast(new ObjetoCool(item,T.GetNombre(),cont));

                            Console.WriteLine(item + "-" + T.GetNombre() + "-" + cont);
                            cont++;
                        }

                        cont = 0;
                    }

                
                }
                
            }

            foreach (String olv in ListaTablas)
            {
                Tablas T = Table.Bucar(olv);
                foreach (Atributo atri in T.A)
                {
                    if (atri.GetNombre().Equals(Colaux))
                    {
                        foreach (Object item in atri.Objetos)
                        {
                            a2 = true;
                            cool2.AddLast(new ObjetoCool(item, T.GetNombre(), cont2));
                            Console.WriteLine(item + "-" + T.GetNombre() + "-" + cont2);
                            cont2++;

                        }
                        cont2 = 0;

                    }

                }
   
            }



            if (a == true && a2==true)
            {


                foreach (ObjetoCool AUX in cool)
                {
                    foreach (ObjetoCool AUX2 in cool2)
                    {




                        if (AUX.GetNombre().Equals(AUX2.GetNombre()) && Simbolo.Equals("="))
                        {
                            Console.WriteLine("encontrado");


                            if (AUX.GetTabla().Equals(TablaE))
                            {
                                ayudita.AddLast(AUX.GetpOS());

                            }
                            cool3.AddLast(new ObjetoCool(AUX.GetNombre(), AUX.GetTabla(), AUX.GetpOS()));


                        }

                        else if (AUX.GetNombre() != AUX2.GetNombre() && Simbolo.Equals("!="))
                        {
                            Console.WriteLine("encontrado");


                            if (AUX.GetTabla().Equals(TablaE))
                            {
                                ayudita.AddLast(AUX.GetpOS());

                            }
                            cool3.AddLast(new ObjetoCool(AUX.GetNombre(), AUX.GetTabla(), AUX.GetpOS()));

                        }

                        else if (Convert.ToInt32(AUX.GetNombre()) < Convert.ToInt32(AUX2.GetNombre()) && Simbolo.Equals("<"))
                        {
                            Console.WriteLine("encontrado");


                            if (AUX.GetTabla().Equals(TablaE))
                            {
                                ayudita.AddLast(AUX.GetpOS());

                            }
                            cool3.AddLast(new ObjetoCool(AUX.GetNombre(), AUX.GetTabla(), AUX.GetpOS()));


                        }
                        else if (Convert.ToInt32(AUX.GetNombre()) <= Convert.ToInt32(AUX2.GetNombre()) && Simbolo.Equals("<="))
                        {
                            Console.WriteLine("encontrado");


                            if (AUX.GetTabla().Equals(TablaE))
                            {
                                ayudita.AddLast(AUX.GetpOS());

                            }
                            cool3.AddLast(new ObjetoCool(AUX.GetNombre(), AUX.GetTabla(), AUX.GetpOS()));


                        }
                        else if (Convert.ToInt32(AUX.GetNombre()) > Convert.ToInt32(AUX2.GetNombre()) && Simbolo.Equals(">"))
                        {
                            Console.WriteLine("encontrado");


                            if (AUX.GetTabla().Equals(TablaE))
                            {
                                ayudita.AddLast(AUX.GetpOS());

                            }
                            cool3.AddLast(new ObjetoCool(AUX.GetNombre(), AUX.GetTabla(), AUX.GetpOS()));


                        }
                        else if (Convert.ToInt32(AUX.GetNombre()) >= Convert.ToInt32(AUX2.GetNombre()) && Simbolo.Equals(">="))
                        {
                            Console.WriteLine("encontrado");


                            if (AUX.GetTabla().Equals(TablaE))
                            {
                                ayudita.AddLast(AUX.GetpOS());

                            }
                            cool3.AddLast(new ObjetoCool(AUX.GetNombre(), AUX.GetTabla(), AUX.GetpOS()));


                        }

                    }
                    cont++;
                }
            }
            else
            {
                MessageBox.Show("efe");
            }

            if (elimibnar == false && act == false)
            {

                Llenar2(cool3);

            }
            else if (elimibnar == true)
            {
                BorrarChido(ayudita);
            }
            else if (act == true)
            {
                ActChido(ayudita);
            }

        }





        void Caso3(String TABLA11, String  COlumna11, String Colauxx, String Simbolo)
        {
            ayudita = new LinkedList<int>();
            Tablas Tabla1 = Table.Bucar(TABLA11);
           ayudaaaa = new LinkedList<Object>();
            bool a = false;
            bool a2 = true;
            ayudaaaa = new LinkedList<Object>();
            foreach (String  olv in ListaTablas)
            {
                Tablas T = Table.Bucar(olv);
                foreach (Atributo atri in T.A)
                {
                    if (atri.GetNombre().Equals(Colauxx))
                    {
                        foreach (Object item in atri.Objetos)
                        {
                            ayudaaaa.AddLast(item);
                        }


                    }

                }

            }
            Atributo alv = new Atributo();

            int cont = 0;
            foreach (Atributo alv3 in Tabla1.A)
            {
                Console.WriteLine(alv3.GetNombre() + "--");
                if (COlumna11.Equals(alv3.GetNombre()))
                {
                    Console.WriteLine("siuuu");
                    a = true;
                    alv.Objetos = alv3.Objetos;

                }

            }
            if (a == true)
            {


                foreach (Object AUX in alv.Objetos)
                {
                    foreach (Object AUX2 in ayudaaaa)
                    {

                        if (AUX.Equals(AUX2) && Simbolo.Equals("="))
                        {
                            Console.WriteLine("encontrado");

                            ayudita.AddLast(cont);


                        }

                        else if (AUX != AUX2 && Simbolo.Equals("!="))
                        {
                            Console.WriteLine("encontrado");

                            ayudita.AddLast(cont);


                        }

                        else if (Convert.ToInt32(AUX) < Convert.ToInt32(AUX2) && Simbolo.Equals("<"))
                        {
                            Console.WriteLine("encontrado");

                            ayudita.AddLast(cont);


                        }
                        else if (Convert.ToInt32(AUX) <= Convert.ToInt32(AUX2) && Simbolo.Equals("<="))
                        {
                            Console.WriteLine("encontrado");

                            ayudita.AddLast(cont);


                        }
                        else if (Convert.ToInt32(AUX) > Convert.ToInt32(AUX2) && Simbolo.Equals(">"))
                        {
                            Console.WriteLine("encontrado");

                            ayudita.AddLast(cont);


                        }
                        else if (Convert.ToInt32(AUX) >= Convert.ToInt32(AUX2) && Simbolo.Equals(">="))
                        {
                            Console.WriteLine("encontrado");

                            ayudita.AddLast(cont);


                        }

                    }
                    cont++;
                }
            }
            else
            {
                MessageBox.Show("efe");
            }

            if (elimibnar == false && act == false)
            {
                Llenar(ayudita, COlumna11, TABLA11);

            }
            else if (elimibnar == true)
            {
                BorrarChido(ayudita);
            }
            else if (act == true)
            {
                ActChido(ayudita);
            }


        }
        void  Caso1( String Tabla11 , String Columna11 , String Tabla22, String Column22, String Simbolo)
        {
         ayudita= new LinkedList<int>();
          ayudaaaa4 = new LinkedList<Object>();
            Tablas Tabla1 = Table.Bucar(Tabla11);
            Tablas Tabla2 = Table.Bucar(Tabla22);
           int ayudaA = 0;
            bool a = false;
            bool a2 = true;
            int contaux = 0;
            Atributo alv2 = new Atributo();
            Atributo alv= new Atributo();
          
            int cont = 0;
            foreach (Atributo alv3 in Tabla1.A)
            {
                
                Console.WriteLine(alv3.GetNombre() + "--");
                if (Columna11.Equals(alv3.GetNombre()))
                {
                    Console.WriteLine("siuuu");
                    a = true;
                    alv.Objetos = alv3.Objetos;
                    ayudaA = contaux;
                }
                contaux++;
            }
          


            foreach (Atributo alv4 in Tabla2.A)
            {
                Console.WriteLine(alv4.GetNombre() + "--");

                if (Column22.Equals(alv4.GetNombre()))
                {
                    Console.WriteLine("siuuu2");
                    a2 = true;
                    alv2.Objetos = alv4.Objetos;





                }



            }
            if (a==true && a2==true)
            {

        
                                   foreach (Object AUX in alv.Objetos)
                {
                    Console.WriteLine(AUX+"-"+cont);

                    foreach (Object AUX2 in alv2.Objetos)
                                {
                        Console.WriteLine(AUX2);


                        if (AUX.Equals(AUX2) && Simbolo.Equals("=")) 
                                        {
                                Console.WriteLine("encontrado");

                                ayudita.AddLast(cont);
                            ayudaaaa4.AddLast(AUX);

                        }

                       else        if (AUX!=AUX2 && Simbolo.Equals("!="))
                        {
                            Console.WriteLine("encontrado");

                            ayudita.AddLast(cont);
                            ayudaaaa4.AddLast(AUX);
                 
                        }

                        else if (Convert.ToInt32(AUX) < Convert.ToInt32(AUX2) && Simbolo.Equals("<"))
                        {
                            Console.WriteLine("encontrado");
                            ayudaaaa4.AddLast(AUX);
                            ayudita.AddLast(cont);


                        }
                        else if (Convert.ToInt32(AUX) <= Convert.ToInt32(AUX2) && Simbolo.Equals("<="))
                        {
                            Console.WriteLine("encontrado");
                            ayudaaaa4.AddLast(AUX);
                            ayudita.AddLast(cont);
                           
                        }
                        else if (Convert.ToInt32(AUX) > Convert.ToInt32(AUX2) && Simbolo.Equals(">"))
                        {
                            Console.WriteLine("encontrado");
                            ayudaaaa4.AddLast(AUX);
                            ayudita.AddLast(cont);
                           
                        }
                        else if (Convert.ToInt32(AUX) >= Convert.ToInt32(AUX2) && Simbolo.Equals(">="))
                        {
                            ayudaaaa4.AddLast(AUX);
                            Console.WriteLine("encontrado");

                            ayudita.AddLast(cont);
                           


                        }




                    }

                    cont++; }
            }
            else
            {
                MessageBox.Show("efe");
            }
            if (elimibnar==false && act==false)
            {
                Llenar(ayudita, Columna11, Tabla11);

            }
            else if ( elimibnar==true)
            {
                BorrarChido(ayudita);
            }
            else if (act==true)
            {
                ActChido(ayudita);
            }
        }

        void ActChido(LinkedList<int> ayudi)
        {
            LinkedList<Object> HELP = new LinkedList<Object>();
            bool a = false;
            foreach (Object alv in CampoR)
            {
                foreach (Object alv2 in RemplA)
                {

                    Tablas T = Table.Bucar(TablaE);
                    foreach (Atributo item in T.A)
                    {

                        if (item.GetNombre().Equals(alv))
                        {
                            Console.WriteLine("CAMPOOOO" + item.GetNombre()+"-****-*-*-*-*-*");
                         
                            for (int i = 0; i < item.Objetos.Count; i++)
                            {
                                a = false;
                                foreach (int ayudita in ayudi)
                                {
                                    
                                    if (i == ayudita)
                                    {
                                        a = true; 
                                    }
                                  
                                }
                                if (a == true)
                                {
                                    Console.WriteLine("siuuuu la encuentro"+
                                        " "+alv2);
                                    HELP.AddLast(alv2);
                                }
                                else if(a==false)
                                {
                                    HELP.AddLast(item.Objetos.ElementAt(i));
                                }

          
                            }
                            Console.WriteLine("-------------" + HELP.Count());
                            item.Objetos.Clear();

                            foreach (object el in HELP)
                            {
                                Console.WriteLine("--------------------" + el);

                            }
                            foreach (object iTE in HELP)
                            {
                                item.Objetos.AddLast(iTE);
                            }
                            HELP.Clear();
                        }
                 


                    }

                }
            }
        
        
        
        
        
        
        }
            void  BorrarChido(LinkedList <int > ayudi)
        {
            bool a = false;
            LinkedList<Object> HELP = new LinkedList<Object>();
               Console.WriteLine(TablaE+"---+-+-+-+-");
            Tablas T = Table.Bucar(TablaE);
            foreach (Atributo item in T.A)
            {
                for (int i = 0; i < item.Objetos.Count; i++)
                {
                    a = false;

                
                    foreach (int ayudita in ayudi)
                    {
                        if (i==ayudita)
                        {
                            a = true;
                        }
                      
                    }
                    if (a == false)
                    {
                        HELP.AddLast(item.Objetos.ElementAt(i));
                       

                    }

                }

                Console.WriteLine( "-------------" + HELP.Count()); 
                item.Objetos.Clear();

                foreach (object el in HELP)
                {   Console.WriteLine("--------------------" + el);
                
                }
                foreach (object iTE in HELP)
                {
                    item.Objetos.AddLast(iTE);
                }
                HELP.Clear();


            }

          


        }
        void Caso2(String TABLA11,String Columna11, String Dato, String TDato, String Simbolo)
        {
            Atributo alv = new Atributo();
            bool a = false;

            ayudita = new LinkedList<int>();
            Tablas Tabla1 = Table.Bucar(TABLA11);
            int cont = 0;
            foreach (Atributo alv3 in Tabla1.A)
            {
                Console.WriteLine(alv3.GetNombre() + "--"+Tabla1.GetNombre());
                if (Columna11.Equals(alv3.GetNombre()))
                {
                    Console.WriteLine("siuuu");
                    a = true;
                    alv.Objetos = alv3.Objetos;

                }

            }
            if (a==true)
            {

                foreach (Object XD in alv.Objetos)
                {
                    if (TDato.Equals("entero"))
                    {

                    
                    Console.WriteLine(XD+" "+TDato+" "+Simbolo+Dato);
                    if (Simbolo.Equals("=") && Dato.Equals(XD) )
                    {
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);

                    }
                 else    if (Simbolo.Equals("!=")  )
                    {
                            if (Convert.ToInt32(XD) != Int32.Parse(Dato))
                            {
                                Console.WriteLine("encontrado"); ayudita.AddLast(cont);
                            }
                           

                    }
                    else if (Simbolo.Equals("<") )
                        {
                            if (Convert.ToInt32(XD) <= Int32.Parse(Dato))
                            {

                            
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);
                            }
                        }
                    else if (Simbolo.Equals("<=")  )
                        {
                            if (Convert.ToInt32(XD) <= Int32.Parse(Dato))
                            {

                            
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);
                            }
                        }
                    else if (  Simbolo.Equals(">") )
                    {
                        if (Int32.Parse(Dato) > Int32.Parse(XD.ToString()))
                        {

                        
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);
                        }
                    }
                    else if (Simbolo.Equals(">=") && Convert.ToInt32(XD) >= Int32.Parse(Dato) )
                    {
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);

                    }
                    }
                    else if (Simbolo.Equals("=") &&Dato.Equals(XD) && TDato.Equals("cadena"))
                    {
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);

                    }
                    else if (Dato != XD && Simbolo.Equals("!=") && TDato.Equals("cadena"))
                    {
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);

                    }
                    else if (Simbolo.Equals("=") && Dato.Equals (XD) && TDato.Equals("fecha"))
                    {
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);

                    }
                    else if ( Dato!=XD && Simbolo.Equals("!=") && TDato.Equals("fecha"))
                    {
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);

                    }
                   /* else if (DateTime.Parse(Dato) < DateTime.Parse(XD.ToString()) && Simbolo.Equals("<") && TDato.Equals("fecha"))
                    {
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);

                    }
                    else if (DateTime.Parse(Dato) <= DateTime.Parse(XD.ToString()) && Simbolo.Equals("<=") && TDato.Equals("fecha"))
                    {
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);

                    }
                    else if (DateTime.Parse(Dato) > DateTime.Parse(XD.ToString()) && Simbolo.Equals(">") && TDato.Equals("fecha"))
                    {
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);

                    }
                    else if (DateTime.Parse(Dato) >= DateTime.Parse(XD.ToString()) && Simbolo.Equals(">=") && TDato.Equals("fecha"))
                    {
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);

                    }*/
                   /* else if (float.Parse(Dato) == float.Parse(XD.ToString()) && Simbolo.Equals("=") && TDato.Equals("decimal"))
                    {
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);

                    }*/
                  /*  else if (float.Parse(Dato) != float.Parse(XD.ToString()) && Simbolo.Equals("!=") && TDato.Equals("decimal"))
                    {
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);

                    }
                    else if (float.Parse(Dato) < float.Parse(XD.ToString()) && Simbolo.Equals("<") && TDato.Equals("decimal"))
                    {
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);

                    }
                    else if (float.Parse(Dato) <= float.Parse(XD.ToString()) && Simbolo.Equals("<=") && TDato.Equals("decimal"))
                    {
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);

                    }
                    else if (float.Parse(Dato) >= float.Parse(XD.ToString()) && Simbolo.Equals(">=") && TDato.Equals("decimal"))
                    {
                        Console.WriteLine("encontrado");
                        ayudita.AddLast(cont);

                    }
                    */
                    cont++; }

            }
            else
            {
                MessageBox.Show("efe");
            }



            if (elimibnar == false && act == false)
            {
                Llenar(ayudita, Columna11, TABLA11);

            }
            else if (elimibnar == true)
            {
                BorrarChido(ayudita);
            }
            else if (act == true)
            {
                ActChido(ayudita);
            }

        }
        public void IDCondicion2()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.PUNTO)
            {
                ;


                emparejar(Tokens.TipoToken.PUNTO);


                Columna2 = alvAct.getLexema();
                emparejar(Tokens.TipoToken.ID);
                caso11 = true;

            }
            else
            { 
            caso3=true;
                //efe
            }
       
        }
        void SYMBOL()
        {
            Simbolo = alvAct.getLexema();

            Console.WriteLine("simboloooooooooooooooooooooooooooooo" + " " + alvAct.getLexema());
            if (alvAct.getTipo_Token() == Tokens.TipoToken.MAYOR)
            {
                Simbolo = ">";
                emparejar(Tokens.TipoToken.MAYOR);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.MAYOR_IGUAL)
            {
                Simbolo = ">=";
                emparejar(Tokens.TipoToken.MAYOR_IGUAL);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.DIFERENTE)
            {
                Simbolo = "!=";
                emparejar(Tokens.TipoToken.DIFERENTE);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.MENOR)
            {
                Simbolo = "<";
                emparejar(Tokens.TipoToken.MENOR);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.IGUAL)
            {
                Simbolo = "=";
                emparejar(Tokens.TipoToken.IGUAL);

            }
        }
        String NombreTablaInsertar = "";
        void INSERTAR()
        {

            emparejar(Tokens.TipoToken.EN);
            NombreTablaInsertar = alvAct.getLexema();
            emparejar(Tokens.TipoToken.ID);

            emparejar(Tokens.TipoToken.VALORES);
            emparejar(Tokens.TipoToken.PARENTESIS_ABIERTO);

            ValueInsertar();
            emparejar(Tokens.TipoToken.PARENTESIS_CERRADO);
            emparejar(Tokens.TipoToken.PUNTO_y_COMA);
            NombreTablaInsertar = "";
            contI = 0;


        }
        int contI = 0;
        void ValueInsertar()
        {
            TipoValue();
            TipoValue2();

        }
        void TipoValue()
        {
            Table.Bucar(NombreTablaInsertar).A.ElementAt(contI).Objetos.AddLast(alvAct.getLexema());
            if (alvAct.getTipo_Token() == Tokens.TipoToken.DIGITO)
            {
                emparejar(Tokens.TipoToken.DIGITO);
            }

            else if (alvAct.getTipo_Token() == Tokens.TipoToken.COMILLA)
            {

                emparejar(Tokens.TipoToken.COMILLA);
            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.FECHAS)
            {

                emparejar(Tokens.TipoToken.FECHAS);
            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.DECIMAL)
            {

                emparejar(Tokens.TipoToken.DECIMAL);
            }
        }
        void TipoValue2()
        {
            contI++;
            if (alvAct.getTipo_Token() == Tokens.TipoToken.COMA)
            {
                emparejar(Tokens.TipoToken.COMA); ValueInsertar();

            }
            else
            {
                //epsilon
            }
        }
        String NombreTabla = "";
        void CREART()
        {
            Console.WriteLine("Crear");
            emparejar(Tokens.TipoToken.TAABLA);



            ListaTablas.AddLast(alvAct.getLexema());
            NombreTabla = alvAct.getLexema();
            Table.Agregar(NombreTabla);
            emparejar(Tokens.TipoToken.ID);
            emparejar(Tokens.TipoToken.PARENTESIS_ABIERTO);
            Tcontenido();

            emparejar(Tokens.TipoToken.PARENTESIS_CERRADO);
            emparejar(Tokens.TipoToken.PUNTO_y_COMA);
            ayuda = false;
            NombreTabla = "";
            Id = "";
            Tipo = "";

        }
        String Id="";
        String Tipo = "";
        void Tcontenido()
        {
            Id = alvAct.getLexema();
            emparejar(Tokens.TipoToken.ID);

            EXTcontenido();
            EXTcontenido2();



        }

        void EXTcontenido()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.ENTERO)
            {
                Tipo = alvAct.getLexema();
                emparejar(Tokens.TipoToken.ENTERO);
            }

            else if (alvAct.getTipo_Token() == Tokens.TipoToken.CADENA)
            {
                Tipo = alvAct.getLexema();

                emparejar(Tokens.TipoToken.CADENA);
            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.FECHA)
            {
                Tipo = alvAct.getLexema();
                emparejar(Tokens.TipoToken.FECHA);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.FLOTANTE)
            {
                Tipo = alvAct.getLexema();
                emparejar(Tokens.TipoToken.FLOTANTE);

            }
        }
        void EXTcontenido2()
        {
            Table.Bucar(NombreTabla).A.AddLast(new Atributo(Id, Tipo));
            Id = "";
            Tipo="";
            if (alvAct.getTipo_Token() == Tokens.TipoToken.COMA)
            {
                emparejar(Tokens.TipoToken.COMA);
                Tcontenido();
            }
            else
            {
                //epsilon
            }

        }
        public void emparejar(Tokens.TipoToken tip)
        {

            if (tip == Tokens.TipoToken.PUNTO_y_COMA && ayuda == true)
            {
                ayuda = false;

            }
            if (ayuda == false)
            {
                if (alvAct.getTipo_Token() != tip)
                {
                    //ERROR si no viene lo que deberia
                    Console.WriteLine("SE ESPERABA " + " " + GetTipString(tip));
                    /*   ER.ErTks.AddLast(new ErroresTokens(alvAct.getLexema(), 
                           "SE ESPERABA " + " " + GetTipString(tip), alvAct.getcolumna(), alvAct.geTfila()));

                  */
                    Ayuda();

                }
                else
                {
                    if (cont < ListaTok.Count - 1)
                    {

                        Console.WriteLine("--------" + alvAct.getLexema());
                        if (alvAct.getTipo_Token() == Tokens.TipoToken.PUNTO_y_COMA)
                        {

                            if (ListaTok.ElementAt(cont + 1).getTipo_Token() == Tokens.TipoToken.CREAR ||
                                ListaTok.ElementAt(cont + 1).getTipo_Token() == Tokens.TipoToken.INSERTAR
                                || ListaTok.ElementAt(cont + 1).getTipo_Token() == Tokens.TipoToken.SELECCIONAR
                                || ListaTok.ElementAt(cont + 1).getTipo_Token() == Tokens.TipoToken.ACTUALIZAR
                                || ListaTok.ElementAt(cont + 1).getTipo_Token() == Tokens.TipoToken.ELIMINAR)
                            {
                                //ok
                            }
                            else
                            {
                                if (cont + 1 < ListaTok.Count - 1)
                                {
                                    cont++;
                                    alvAct = ListaTok.ElementAt(cont);

                                    Console.WriteLine("se esperaba" + " " + "INSTRUCCION");
                                    Ayuda();
                                    ayuda = false;
                                }





                            }




                        }
                        if (cont < ListaTok.Count - 1)
                        {

                            cont++;
                            alvAct = ListaTok.ElementAt(cont);



                        }
                    }

                }
            }


        }
        void Ayuda()
        {
            ayuda = true;
            while (alvAct.getTipo_Token() != Tokens.TipoToken.PUNTO_y_COMA && cont < ListaTok.Count - 1)
            {
                cont++;
                alvAct = ListaTok.ElementAt(cont);
            }
        }
        public string GetTipString(Tokens.TipoToken tip)

        {
            switch (tip)
            {
                case Tokens.TipoToken.ACTUALIZAR:
                    return "Actualizar";
                case Tokens.TipoToken.Asterisco:
                    return "*";

                case Tokens.TipoToken.CADENA:
                    return "Cadena";

                case Tokens.TipoToken.COMILLA:
                    return "COMILLA";

                case Tokens.TipoToken.LAST:
                    return "LAST";

                case Tokens.TipoToken.COMA:
                    return "COMA";
                case Tokens.TipoToken.COMENTARIO_LINEA:
                    return "Comentario de Linea";
                case Tokens.TipoToken.COMENTARIO_MULTILINEA:
                    return "Comentario MultiLinea";
                case Tokens.TipoToken.COMO:
                    return "COMO";
                case Tokens.TipoToken.CORCHETE_ABIERTO:
                    return "[";
                case Tokens.TipoToken.CORCHETE_CERRADO:
                    return "]";
                case Tokens.TipoToken.CREAR:
                    return "Crear";
                case Tokens.TipoToken.DE:
                    return "DE";
                case Tokens.TipoToken.DECIMAL:
                    return "DECIMAL";
                case Tokens.TipoToken.DIGITO:
                    return "digito";
                case Tokens.TipoToken.DONDE:
                    return "DONDE";
                case Tokens.TipoToken.ELIMINAR:
                    return "ELIMINAR";


                case Tokens.TipoToken.EN:
                    return "EN";

                case Tokens.TipoToken.ENTERO:
                    return "Entero";

                case Tokens.TipoToken.ESTABLECER:
                    return "Establecer";

                case Tokens.TipoToken.FECHA:
                    return "FECHA";

                case Tokens.TipoToken.FECHAS:
                    return "FECHAS";

                case Tokens.TipoToken.FLOTANTE:
                    return "FLOTANTE";

                case Tokens.TipoToken.ID:
                    return "ID";

                case Tokens.TipoToken.IGUAL:
                    return "IGUAL";

                case Tokens.TipoToken.INSERTAR:
                    return "INSERTAR";

                case Tokens.TipoToken.MAYOR:
                    return "MAYOR";

                case Tokens.TipoToken.MAYOR_IGUAL:
                    return "MAYOR IGUAL";

                case Tokens.TipoToken.MENOR:
                    return "MENOR";

                case Tokens.TipoToken.MENOR_IGUAL:
                    return "MENOR IGUAL";

                case Tokens.TipoToken.MODIFICAR:
                    return "MODIFICAR";

                case Tokens.TipoToken.O:
                    return "O";

                case Tokens.TipoToken.PARENTESIS_ABIERTO:
                    return "(";

                case Tokens.TipoToken.PARENTESIS_CERRADO:
                    return ")";

                case Tokens.TipoToken.PUNTO:
                    return ".";
                case Tokens.TipoToken.PUNTO_y_COMA:
                    return ";";
                case Tokens.TipoToken.SELECCIONAR:
                    return "Seleccionar";
                case Tokens.TipoToken.TAABLA:
                    return "TABLA";
                case Tokens.TipoToken.VALORES:
                    return "valores";
                case Tokens.TipoToken.Y:
                    return "YYYYY";
                case Tokens.TipoToken.DIFERENTE:
                    return "Diferente";

                default:
                    return "DESCONOCIDO";
            }
        }

        public void GetError(String error)
        {

            Console.WriteLine("ERROR SINTACTICO" + " " + "se esperaba" + error);

        }
        public void Consulta()
        {
            Console.WriteLine("---------------------------------------");

            foreach (Atributo alv in NewT)
            {
                Console.WriteLine(alv.GetNombre());
                foreach (Object item in alv.Objetos)
                {
                    Console.WriteLine(item);

                }
            }
        }

     public   void GrafoConsulta()
        {
            String codigoHtml = "";
            int i = 0;
            int Size = 0;
            SaveFileDialog GuardarHtml = new SaveFileDialog();
            GuardarHtml.Filter = "HTML|*.html";
            if (GuardarHtml.ShowDialog() == DialogResult.OK)
            {
                string direccion = GuardarHtml.FileName;
                StreamWriter pagina = new StreamWriter(direccion);

                codigoHtml =
             "<html >"
            + "<tittle> Reporte de Tokens "
         + " </tittle>"
         + "        <link rel = stylesheet href= estilos3.css>"
          + "    <head>";



                codigoHtml += "    <center>"

                       + "        <table border=4>"

                      ;
                foreach (Atributo alv in NewT)
                {

                    if (alv.Objetos.Count > 0)
                    {


                        codigoHtml += "<td>";


                        codigoHtml +=
                                 alv.GetNombre();


                        Size = alv.Objetos.Count;


                        codigoHtml += "</td>";
                    }

                }
                
                Console.WriteLine("---tamaño" + Size);
                for (int ix = 0; ix <Size; ix++)
                {
                    codigoHtml += "        <tr> ";

                    foreach (Atributo alv in NewT)
                    {

                        codigoHtml += "<td>";


                        if (ix<alv.Objetos.Count)
                        {
                            
                        
                            codigoHtml += alv.Objetos.ElementAt(ix);
                      
                        }




                        codigoHtml += "</td>";




                    }
          
                    codigoHtml += "                          </tr> ";
                    codigoHtml += "     </Tbody> <t/table>  <br<br>   ";
            
                   
                }
                

                codigoHtml += "</body > </html > ";
                pagina.Write(codigoHtml);
                pagina.Close();
            }
            }
        public void GrafoPrueba()
        {
            Tablas alv = Table.Inicio;
            while (alv != null)
            {
                Console.WriteLine("Nombre Tabla:" + " " + alv.GetNombre());
                foreach (Atributo aux in alv.A)
                {
                    Console.WriteLine("Columna " + " " + aux.GetNombre());


                    foreach (Object item in aux.Objetos)
                    {
                        Console.WriteLine(item);

                    }


                }
                alv = alv.Sig;
            }
        }
            public void Grafo()
        {
            int i = 0;
            String codigoHtml = "";

       Tablas alv = Table.Inicio;
            SaveFileDialog GuardarHtml = new SaveFileDialog();
            GuardarHtml.Filter = "HTML|*.html";
            if (GuardarHtml.ShowDialog() == DialogResult.OK)
            {
                string direccion = GuardarHtml.FileName;
                StreamWriter pagina = new StreamWriter(direccion);

                codigoHtml =
             "<html >"
            + "<tittle> Reporte de Tokens "
         + " </tittle>"
         + "        <link rel = stylesheet href= estilos3.css>"
          + "    <head>";
                codigoHtml+=


                 "        <title>+"+"Reporte Tablas"+ " </title>"
                + "    </head>"
                + "    <body>\n"

           ;
                while (alv != null)
                {


  
                    codigoHtml += "    <center>"

                           + "        <table border=4>"
                      
                          ;
                    foreach (Atributo aux in alv.A)
                    {
                      
                        if (alv.A.Count > 0)
                        {


                            codigoHtml += "<td>";


                            codigoHtml +=
                                     aux.GetNombre();





                            codigoHtml += "</td>";
                        }

                    }
                    if (i==alv.A.Count)
                    {
                        i--;
                    }
                    for (int ix = 0; ix < alv.A.ElementAt(i).Objetos.Count; ix++)
                    {

                    codigoHtml += "                          <tr> ";

                        foreach (Atributo aux in alv.A)
                    {

                            codigoHtml += "<td>";


                            codigoHtml +=
                                     aux.Objetos.ElementAt(ix);


                           
                        

                            codigoHtml += "</td>";

                        }
                        

                        codigoHtml += "                          </tr> ";


                    }
                    codigoHtml += "<center>"
+ "        <h1>" + alv.GetNombre() + "</h1>";

                    i++;
                    alv = alv.Sig; codigoHtml += "     </Tbody> <t/table>  <br<br>   ";
                }
                codigoHtml += "     </Tbody> <t/table>  <br<br>   ";
                codigoHtml += "</body > </html > ";
            pagina.Write(codigoHtml);
            pagina.Close();
            }
        }
    }
}
