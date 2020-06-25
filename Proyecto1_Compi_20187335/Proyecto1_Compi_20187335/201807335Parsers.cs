using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Compi_20187335
{
    class _201807335Parsers
    {


        bool ayuda = false;

        int cont = 0;

        Tokens alvAct;

        LinkedList<Tokens> ListaTok;



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
        bool acts = false;
        void ACTUALIZAR()
        {
            acts = true;
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
            emparejar(Tokens.TipoToken.ID);

            emparejar(Tokens.TipoToken.IGUAL);
            DATO1();
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

        void ELIMINAR()
        {


            emparejar(Tokens.TipoToken.DE);
            emparejar(Tokens.TipoToken.ID);
            WHERE();

            emparejar(Tokens.TipoToken.PUNTO_y_COMA);
            ayuda = false;

        }


        void Seleccionar()
        {
            Selection();


            emparejar(Tokens.TipoToken.DE);
            EscogerTabla();

            WHERE();

            emparejar(Tokens.TipoToken.PUNTO_y_COMA);
        }
        void Selection()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.Asterisco)
            {
                emparejar(Tokens.TipoToken.Asterisco);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.ID)
            {
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
            if (alvAct.getTipo_Token()==Tokens.TipoToken.PUNTO)
            {

                emparejar(Tokens.TipoToken.PUNTO);
                emparejar(Tokens.TipoToken.ID);
                AliasSeleccionar();
            }
            else
            {
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

        void EscogerTabla()
        {
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

        void WHERE()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.DONDE)
            {
                emparejar(Tokens.TipoToken.DONDE);
                CONDITION();

            }
            else
            {
                //eefe
            }

        }
        void CONDITION()
        {
            emparejar(Tokens.TipoToken.ID); IDCondicion(); TipoCondicion();  OtraCondicion();


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
                //
            }
        }
        void IDCondicion()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.PUNTO)
            {
                emparejar(Tokens.TipoToken.PUNTO);
                emparejar(Tokens.TipoToken.ID);


            }
            else
            {
                //efe
            }

        }
        void IdCondicion2()
        {


        }
        void TipoCondicion()
        {


            if (alvAct.getTipo_Token() == Tokens.TipoToken.IGUAL || alvAct.getTipo_Token() == Tokens.TipoToken.DIFERENTE
                || alvAct.getTipo_Token() == Tokens.TipoToken.MAYOR || alvAct.getTipo_Token() == Tokens.TipoToken.MAYOR_IGUAL
                || alvAct.getTipo_Token() == Tokens.TipoToken.MENOR || alvAct.getTipo_Token() == Tokens.TipoToken.MENOR_IGUAL
                    || alvAct.getTipo_Token() == Tokens.TipoToken.DIFERENTE)

            {
                SYMBOL(); DATO1(); YO_CONDITION();

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

        void DATO1()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.DIGITO)
            {
                emparejar(Tokens.TipoToken.DIGITO);



            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.DECIMAL)
            {
                emparejar(Tokens.TipoToken.DECIMAL);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.FECHAS)
            {
                emparejar(Tokens.TipoToken.FECHAS);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.COMILLA)
            {
                emparejar(Tokens.TipoToken.COMILLA);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.ID)
            {
                emparejar(Tokens.TipoToken.ID);
                IDCondicion();

            }
            else
            {
                //EFEEE
            }


        }
        void SYMBOL()
        {

            if (alvAct.getTipo_Token() == Tokens.TipoToken.MAYOR)
            {
                emparejar(Tokens.TipoToken.MAYOR);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.MAYOR_IGUAL)
            {
                emparejar(Tokens.TipoToken.MAYOR_IGUAL);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.DIFERENTE)
            {
                emparejar(Tokens.TipoToken.DIFERENTE);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.MENOR)
            {
                emparejar(Tokens.TipoToken.MENOR_IGUAL);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.IGUAL)
            {
                emparejar(Tokens.TipoToken.IGUAL);

            }
        }
        void INSERTAR()
        {

            emparejar(Tokens.TipoToken.EN);

            emparejar(Tokens.TipoToken.ID);

            emparejar(Tokens.TipoToken.VALORES);
            emparejar(Tokens.TipoToken.PARENTESIS_ABIERTO);

            ValueInsertar();
            emparejar(Tokens.TipoToken.PARENTESIS_CERRADO);
            emparejar(Tokens.TipoToken.PUNTO_y_COMA);


        }

        void ValueInsertar()
        {
            TipoValue();
            TipoValue2();

        }
        void TipoValue()
        {
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
            if (alvAct.getTipo_Token() == Tokens.TipoToken.COMA)
            {
                emparejar(Tokens.TipoToken.COMA); ValueInsertar();

            }
            else
            {
                //epsilon
            }
        }
        void CREART()
        {
            Console.WriteLine("Crear");
            emparejar(Tokens.TipoToken.TAABLA);

            emparejar(Tokens.TipoToken.ID);
            emparejar(Tokens.TipoToken.PARENTESIS_ABIERTO);
            Tcontenido();

            emparejar(Tokens.TipoToken.PARENTESIS_CERRADO);
            emparejar(Tokens.TipoToken.PUNTO_y_COMA);
            ayuda = false;

        }
        void Tcontenido()
        {
            emparejar(Tokens.TipoToken.ID); EXTcontenido(); EXTcontenido2();

        }

        void EXTcontenido()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.ENTERO)
            {
                emparejar(Tokens.TipoToken.ENTERO);
            }

            else if (alvAct.getTipo_Token() == Tokens.TipoToken.CADENA)
            {

                emparejar(Tokens.TipoToken.CADENA);
            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.FECHA)
            {
                emparejar(Tokens.TipoToken.FECHA);

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.FLOTANTE)
            {
                emparejar(Tokens.TipoToken.FLOTANTE);

            }
        }
        void EXTcontenido2()
        {
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

    }
}
