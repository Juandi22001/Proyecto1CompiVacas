using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Proyecto1_Compi_20187335
{
    class SINTACTIC
    {
        graficador gr = new graficador();
        /*
                void INSERTAR()
                {
                    Arbol Insertar = new Arbol("Insertar");

                    emparejar(Tokens.TipoToken.EN);
                    Insertar.A.AddLast(new Arbol("En"));

                    Insertar.A.AddLast(new Arbol(alvAct.getLexema()));


                    Insertar.A.AddLast(new Arbol("Valores"));

                    Insertar.A.AddLast(new Arbol("Parentesis Abiertoo"));

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
                */

        bool ayuda = false;

        int cont = 0;

        Tokens alvAct;

        LinkedList<Tokens> ListaTok;
        Arbol Crear = new Arbol("Crear");
        Arbol Inicio = new Arbol("Inicio");
        Arbol Insertar = new Arbol("Insertar");
        Arbol Seleccionars = new Arbol("Seleccionar");
        Arbol Elimnar = new Arbol("Eliminar");
        Arbol Establecer = new Arbol("ESTABLECER");
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

            if (alvAct.getTipo_Token() == Tokens.TipoToken.INSERTAR)
            {
                emparejar(Tokens.TipoToken.INSERTAR);

                Insertar = new Arbol("Insertar");

                INSERTAR();
                Inicio.A.AddLast(Insertar);
            }
          else  if (alvAct.getTipo_Token() == Tokens.TipoToken.CREAR)
            {
                emparejar(Tokens.TipoToken.CREAR);
                Crear = new Arbol("Crear");

                CREART();

                Inicio.A.AddLast(Crear);
               
            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.SELECCIONAR)
            {
                emparejar(Tokens.TipoToken.SELECCIONAR);

                Seleccionars = new Arbol("Seleccionar");
                Seleccionar();
                Inicio.A.AddLast(Seleccionars);
            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.ELIMINAR)
            {
                Elimnar = new Arbol("Eliminar");
                emparejar(Tokens.TipoToken.ELIMINAR);
                ELIMINAR();
                Inicio.A.AddLast(Elimnar);
            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.ACTUALIZAR)
            {
                Establecer = new Arbol("ACTUALIZAR");
                emparejar(Tokens.TipoToken.ACTUALIZAR);


                ACTUALIZAR();
                Inicio.A.AddLast(Establecer);
            }

        }
        Arbol EST = new Arbol("EST");

        Arbol EST2 = new Arbol("EST2");
        void ACTUALIZAR()
        {
            Establecer.A.AddLast(new Arbol(alvAct.getLexema()));

            emparejar(Tokens.TipoToken.ID);
            emparejar(Tokens.TipoToken.ESTABLECER);
            Establecer.A.AddLast(new Arbol("Establecer"));

            emparejar(Tokens.TipoToken.PARENTESIS_ABIERTO);
            Establecer.A.AddLast(new Arbol("("));
            EST2 = new Arbol("EST2");
            EST = new Arbol("EST");
            DATOS = new Arbol("DATO");
            IDCondition2 = new Arbol("ID CONDITION TIPO");

            Est();

            DATOS.A.AddLast(IDCondition2);
            EST.A.AddLast(DATOS);
            EST.A.AddLast(EST2);
            Establecer.A.AddLast(EST);
            emparejar(Tokens.TipoToken.PARENTESIS_CERRADO);
            Establecer.A.AddLast(new Arbol(")"));

            Where = new Arbol("WHERE");
            Condition = new Arbol("Condition");

            TipCondition = new Arbol("TIpoCondicion");
            IDCondition = new Arbol("IDCondition");
            Symbol = new Arbol("Simbolo");
            DATOS = new Arbol("DATO");
            YO = new Arbol("YoO");
            IDCondition2 = new Arbol("ID CONDITION TIPO");
            WHERE();


            DATOS.A.AddLast(IDCondition2);
            TipCondition.A.AddLast(Symbol);

            TipCondition.A.AddLast(DATOS);
            TipCondition.A.AddLast(YO);
            Condition.A.AddLast(IDCondition);

            Condition.A.AddLast(TipCondition);





            Where.A.AddLast(Condition);
           Establecer.A.AddLast(Where);
            emparejar(Tokens.TipoToken.PUNTO_y_COMA);
            


            
            Establecer.A.AddLast(new Arbol(";"));
            ayuda = false;

        }
        void Est()
        {
            EST.A.AddLast(new Arbol(alvAct.getLexema()));
            emparejar(Tokens.TipoToken.ID);

            EST.A.AddLast(new Arbol("="));
            emparejar(Tokens.TipoToken.IGUAL);
            DATO1();
            Est2();
        }
        void Est2()
        {
            EST2.A.AddLast(new Arbol(", coma E"));
            if (alvAct.getTipo_Token() == Tokens.TipoToken.COMA)
            {
                emparejar(Tokens.TipoToken.COMA);

            }
            else
            {
                //efeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
            }
        }


        void ELIMINAR()
        {

            Elimnar.A.AddLast(new Arbol("DE"));
            emparejar(Tokens.TipoToken.DE);

            Elimnar.A.AddLast(new Arbol(alvAct.getLexema()));
            emparejar(Tokens.TipoToken.ID);
            Where = new Arbol("WHERE");
            Condition = new Arbol("Condition");

            TipCondition = new Arbol("TIpoCondicion");
            IDCondition = new Arbol("IDCondition");
            Symbol = new Arbol("Simbolo");
            DATOS = new Arbol("DATO");
            YO = new Arbol("YoO");
            IDCondition2 = new Arbol("ID CONDITION TIPO");
            WHERE();
           

            DATOS.A.AddLast(IDCondition2);
            TipCondition.A.AddLast(Symbol);

            TipCondition.A.AddLast(DATOS);
            TipCondition.A.AddLast(YO);
            Condition.A.AddLast(IDCondition);

            Condition.A.AddLast(TipCondition);





            Where.A.AddLast(Condition);
Elimnar.A.AddLast(Where);

            Elimnar.A.AddLast(new Arbol(";"));
            emparejar(Tokens.TipoToken.PUNTO_y_COMA); 
            ayuda = false;

        }
        Arbol Seleccion = new Arbol("Seleccion");
   
        Arbol AliasSeleccionars = new Arbol("AliasSeleccionar");
        Arbol EscogerTablas = new Arbol("Escoger Tabla");
        Arbol Where = new Arbol("WHERE");
        Arbol Other = new Arbol("Other_SeleccionR"); Arbol IDCondition = new Arbol("IDCondition");

        Arbol Otra = new Arbol("OtraCondicion");
        Arbol TipCondition = new Arbol("TIpoCondicion");
        public Arbol Symbol = new Arbol("Simbolo");
        public Arbol DATOS = new Arbol("DATO");
        public Arbol YO = new Arbol("YoO");
        public Arbol Seleccionar()
        {
            Seleccion = new Arbol("Seleccion");
            AliasSeleccionars = new Arbol("AliasSeleccionar");

            Other = new Arbol("Other_SeleccionR");
            Selection();

            AliasSeleccionars.A.AddLast(Other);
            Seleccion.A.AddLast(AliasSeleccionars);

           
            Seleccionars.A.AddLast(Seleccion);


            emparejar(Tokens.TipoToken.DE);


            Seleccionars.A.AddLast(new Arbol("DE"));
            EscogerTablas = new Arbol("Escoger Tabla");
            EscogerTabla();
            OtherTables = new Arbol("Other Table");

            EscogerTablas.A.AddLast(OtherTables);
            Seleccionars.A.AddLast(EscogerTablas);
            Where = new Arbol("WHERE");
            Condition = new Arbol("Condition");

            TipCondition = new Arbol("TIpoCondicion");
            IDCondition = new Arbol("IDCondition");
            Symbol = new Arbol("Simbolo");
            DATOS = new Arbol("DATO");
              YO = new Arbol("YoO");
            IDCondition2 = new Arbol("ID CONDITION TIPO");
            WHERE();
  

            DATOS.A.AddLast(IDCondition2);
            TipCondition.A.AddLast(Symbol);

            TipCondition.A.AddLast(DATOS);
            TipCondition.A.AddLast(YO);
            Condition.A.AddLast(IDCondition);

            Condition.A.AddLast(TipCondition);

            Condition.A.AddLast(Otra);

          
   
            Where.A.AddLast(Condition);
           
            Seleccionars.A.AddLast(Where);
            emparejar(Tokens.TipoToken.PUNTO_y_COMA);
            return Seleccionars;
        }
        Arbol OtherSelcctions = new Arbol("OtherSelecction");
        public Arbol Selection()
        {
        
            if (alvAct.getTipo_Token() == Tokens.TipoToken.Asterisco)
            {
                Seleccion.A.AddLast(new Arbol("Asterisco *"));
                emparejar(Tokens.TipoToken.Asterisco);
            
            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.ID)
            {
                Seleccion.A.AddLast(new Arbol("ID" + alvAct.getLexema()));
                emparejar(Tokens.TipoToken.ID);
                OP();


            }
            else
            {
                OtherSelcctions = new Arbol("OtherSelecction");
                OtherSelecction();

                Seleccion.A.AddLast(OtherSelcctions);
            }
            return Seleccion;
        }

        public Arbol OP()
        {
            if (alvAct.getTipo_Token()==Tokens.TipoToken.PUNTO)
            {
                Seleccion.A.AddLast(new Arbol(".PUNTO"));
                emparejar(Tokens.TipoToken.PUNTO);


                Seleccion.A.AddLast(new Arbol("ID" + alvAct.getLexema()));
                emparejar(Tokens.TipoToken.ID);

                AliasSeleccionar();


            }
            else
            {
                AliasSeleccionar();
            }
            return Seleccion;
        }

public Arbol OtherSelecction()
        {
            OtherSelcctions.A.AddLast(new Arbol(" coma ,"));
            if (alvAct.getTipo_Token() == Tokens.TipoToken.COMA)
            {
                emparejar(Tokens.TipoToken.COMA);
        
                SelectS();
            }
            return OtherSelcctions;
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
      
        public Arbol AliasSeleccionar()
        {
            
            if (alvAct.getTipo_Token() == Tokens.TipoToken.COMO)
            {

                emparejar(Tokens.TipoToken.COMO);
                AliasSeleccionars.A.AddLast(new Arbol("como"));

                AliasSeleccionars.A.AddLast(new Arbol("id" + alvAct.getLexema()));
                emparejar(Tokens.TipoToken.ID);
        
                Other_seleccionR();


            }
            else
            {
                //EFE
            }
            return AliasSeleccionars;

        }
    public Arbol Other_seleccionR()
        {
            Other.A.AddLast(new Arbol(",coma"));

            if (alvAct.getTipo_Token() == Tokens.TipoToken.COMA)
               { 
                emparejar(Tokens.TipoToken.COMA);
              
                Selection();
            }
            else
            {
                //efe
            }
            return Other;
        }
        Arbol OtherTables = new Arbol("Other Table");
      public Arbol EscogerTabla()
        { 
            EscogerTablas.A.AddLast(new Arbol(alvAct.getLexema()));
            emparejar(Tokens.TipoToken.ID);
          
            OtherTable();
            return EscogerTablas;
        }
        void OtherTable()
        {
            OtherTables.A.AddLast(new Arbol(", coma"));
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
        Arbol Condition = new Arbol("Condition");
        public Arbol WHERE()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.DONDE)
            {
               
                emparejar(Tokens.TipoToken.DONDE);
             
                CONDITION();
           
            }
            else
            {

            }return Where;

        }
        
        public Arbol CONDITION()
        {
            Condition.A.AddLast(new Arbol(alvAct.getLexema()));
            emparejar(Tokens.TipoToken.ID);

            IDCondicion();
           
            TipoCondicion();
            OtraCondicion();

            return Condition;
        }
        public Arbol OtraCondicion()
        {

            if (alvAct.getTipo_Token()==Tokens.TipoToken.COMA)
            {
                Otra.A.AddLast(new Arbol(alvAct.getLexema()));

            }
            else
            {
                //efe
            }
            return Otra;
        }
        public Arbol IDCondicion()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.PUNTO)
            {  
                IDCondition.A.AddLast(new Arbol("."));

                emparejar(Tokens.TipoToken.PUNTO);
                IDCondition.A.AddLast(new Arbol(alvAct.getLexema()));
             

                emparejar(Tokens.TipoToken.ID);


            }
            else
            {
                //efe
            }
            return IDCondition;
        }
        void IdCondicion2()
        {


        }
      
        public Arbol TipoCondicion()
        {


            if (alvAct.getTipo_Token() == Tokens.TipoToken.IGUAL || alvAct.getTipo_Token() == Tokens.TipoToken.DIFERENTE
                || alvAct.getTipo_Token() == Tokens.TipoToken.MAYOR || alvAct.getTipo_Token() == Tokens.TipoToken.MAYOR_IGUAL
                || alvAct.getTipo_Token() == Tokens.TipoToken.MENOR || alvAct.getTipo_Token() == Tokens.TipoToken.MENOR_IGUAL
                    || alvAct.getTipo_Token() == Tokens.TipoToken.DIFERENTE)

            {
           
                SYMBOL();
              
    
                DATO1();
    
                YO_CONDITION();
              

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.PUNTO)
            {
                emparejar(Tokens.TipoToken.PUNTO); emparejar(Tokens.TipoToken.ID); SYMBOL(); DATO1(); YO_CONDITION();


            }
            return TipCondition;
        }
     public Arbol  YO_CONDITION()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.Y)
            {
                YO.A.AddLast(new Arbol(alvAct.getLexema()));
                emparejar(Tokens.TipoToken.Y); CONDITION();

            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.O)
            {
                YO.A.AddLast(new Arbol(alvAct.getLexema()));
                emparejar(Tokens.TipoToken.O); CONDITION();

            }
            else
            {
                //EPSILOON
            }
            return YO;
        }
      Arbol  IDCondition2 = new Arbol("ID CONDITION TIPO");
        public Arbol DATO1()
        {
            DATOS.A.AddLast(new Arbol(alvAct.getLexema()));
            
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
                emparejar(Tokens.TipoToken.ID); IDCondicion2();
              

            }
            else
            {
                //EFEEE
            }
            return DATOS;


        }
        public Arbol IDCondicion2()
        {
            if (alvAct.getTipo_Token() == Tokens.TipoToken.PUNTO)
            {
                ;

                IDCondition2.A.AddLast(new Arbol("."));
                emparejar(Tokens.TipoToken.PUNTO);
     
                IDCondition2.A.AddLast(new Arbol(alvAct.getLexema()));

                emparejar(Tokens.TipoToken.ID);


            }
            else
            {
                //efe
            }
            return IDCondition;
        }
        public Arbol SYMBOL()
        {
            Symbol.A.AddLast(new Arbol(alvAct.getLexema()));

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
            return Symbol;
        }
 
   
        Arbol TContenido = new Arbol("Tcontenido");
        Arbol ExtContenido = new Arbol("ExtContenido");
        Arbol ExtContenido2 = new Arbol("ExtContenido2");

        public Arbol CREART()
        {
   
            emparejar(Tokens.TipoToken.TAABLA);
          Crear.A.AddLast(new Arbol("Tabla"));
            emparejar(Tokens.TipoToken.ID);
            Crear.A.AddLast(new Arbol("ID"));
            emparejar(Tokens.TipoToken.PARENTESIS_ABIERTO);

            Crear.A.AddLast(new Arbol("Parentesis Abierto ("));
            TContenido = new Arbol("Tcontenido");
            ExtContenido = new Arbol("ExtContenido");
            ExtContenido2 = new Arbol("ExtContenido2");
            Tcontenido();


            TContenido.A.AddLast(ExtContenido);
            TContenido.A.AddLast(ExtContenido2);
            Crear.A.AddLast(TContenido);
            Crear.A.AddLast(new Arbol(")"));
            Crear.A.AddLast(new Arbol(";"));

            emparejar(Tokens.TipoToken.PARENTESIS_CERRADO);
            emparejar(Tokens.TipoToken.PUNTO_y_COMA);
            ayuda = false;
            return Crear;
        }

        public Arbol Tcontenido()
        {
      TContenido.A.AddLast(new Arbol(alvAct.getLexema()));
            emparejar(Tokens.TipoToken.ID); 

            EXTcontenido();
            EXTcontenido2();
            return TContenido;
        }

       public Arbol EXTcontenido()
         {
            ExtContenido.A.AddLast (new Arbol(alvAct.getTipo_Token().ToString()));
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
            return ExtContenido;
        }
       public Arbol EXTcontenido2()
        {
            ExtContenido2.A.AddLast(new Arbol(","));
          
            if (alvAct.getTipo_Token() == Tokens.TipoToken.COMA)
            {
        
                emparejar(Tokens.TipoToken.COMA);
                Tcontenido();
            }
            else
            {
                //epsilon
            }
            return ExtContenido2;
        }
        Arbol valor = new Arbol("valorAinsertar");
        Arbol valor2 = new Arbol("valor");
        Arbol valor4 = new Arbol("valores");

        public Arbol INSERTAR()
        {


            emparejar(Tokens.TipoToken.EN);
            Insertar.A.AddLast(new Arbol("En I"));
            Insertar.A.AddLast(new Arbol(alvAct.getLexema()));
            emparejar(Tokens.TipoToken.ID);
           
            emparejar(Tokens.TipoToken.VALORES);
            Insertar.A.AddLast(new Arbol("Valores I"));

            emparejar(Tokens.TipoToken.PARENTESIS_ABIERTO);
            Insertar.A.AddLast(new Arbol("Parentesis Abiertoo ( " ));

            valor = new Arbol("valorAinsertar");
            valor2 = new Arbol("valor");
            valor4 = new Arbol("valores");

            ValueInsertar();
            valor.A.AddLast(valor2);
            valor.A.AddLast(valor4);

            Insertar.A.AddLast(valor);
            emparejar(Tokens.TipoToken.PARENTESIS_CERRADO);
            Insertar.A.AddLast(new Arbol("Parentesis Cerrado ) I"));
            emparejar(Tokens.TipoToken.PUNTO_y_COMA);
            Insertar.A.AddLast(new Arbol("Puntoy coma;I"));
            return Insertar;
        }
            
     public Arbol ValueInsertar()
        {
       


           

            TipoValue();
    

            TipoValue2();

            return valor;
        }
        public Arbol TipoValue()
        {
         
            Console.WriteLine("+" + alvAct.getLexema());
            valor2.A.AddLast(new Arbol(alvAct.getLexema()));
            if (alvAct.getTipo_Token() == Tokens.TipoToken.DIGITO)
            {
                Console.WriteLine("siuu es token");
          
                emparejar(Tokens.TipoToken.DIGITO);

            }

            else if (alvAct.getTipo_Token() == Tokens.TipoToken.COMILLA)
            {
  

                emparejar(Tokens.TipoToken.COMILLA);
            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.FECHAS)
            {
                Arbol digito = new Arbol(alvAct.getLexema());
            }
            else if (alvAct.getTipo_Token() == Tokens.TipoToken.DECIMAL)
            {
  
                emparejar(Tokens.TipoToken.DECIMAL);
            }
            return valor2;
        }
    
        public Arbol  TipoValue2()
        {
            
               valor4.A.AddLast(new Arbol(alvAct.getLexema()));
             
            if (alvAct.getTipo_Token() == Tokens.TipoToken.COMA)
            {
                emparejar(Tokens.TipoToken.COMA);
                ValueInsertar();
               
            }
            else
            {
                //epsilon
            }
            return valor4;
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


        int i = 0;
       public void Grafo()
        {

           Console.WriteLine( Inicio.getDot());
            gr.graficar("digraph G{"+"\n"+Inicio.getDot()+"\n"+"}");
          
        }

    }

}

