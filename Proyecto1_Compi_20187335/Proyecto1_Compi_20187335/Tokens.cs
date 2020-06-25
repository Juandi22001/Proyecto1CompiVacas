using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Compi_20187335
{
    class Tokens
    {


        public enum TipoToken
        {
            IGUAL,COMA,PUNTO_y_COMA,PARENTESIS_ABIERTO,PARENTESIS_CERRADO,CORCHETE_ABIERTO,CORCHETE_CERRADO,
            PUNTO,TAABLA,INSERTAR,ELIMINAR,MODIFICAR,SELECCIONAR,ACTUALIZAR,CREAR,ENTERO,FECHA,FLOTANTE,CADENA,EN,DE,DONDE,
            COMO,Y,O,ESTABLECER,VALORES,ID,DIGITO,DECIMAL,MENOR_IGUAL,MENOR,MAYOR_IGUAL,MAYOR,COMENTARIO_MULTILINEA,FECHAS,
            COMENTARIO_LINEA,DIFERENTE,Asterisco,COMILLA,LAST



        }
        private String Valor;
        private String Lexema;
        private int IdToken;
        private int linea;
        private int columna;
        private int indice;
        private int indice2;

      
        private int estado;
        private int idToken;
        private int fila;
        private string tipo1;
        private string descripcion;

        public TipoToken tipotoken;

        public Tokens( string Lexema, int Idtoken, string tipo , int fila, int columna, TipoToken TIPO)
        {
            this.tipotoken = TIPO;
            this.Lexema = Lexema;
            this.idToken = Idtoken;
           this.tipo1= tipo;
            this.columna = columna;
            this.fila = fila;


        }



        public TipoToken getTipo_Token()
        {
            return this.tipotoken;

        }
        public string GetTipString()

        {
            switch (tipotoken)
            {
                case TipoToken.ACTUALIZAR:
               return "Actualizar";
                case TipoToken.Asterisco:
                    return "*";

                case TipoToken.CADENA:
                    return "Cadena";

                case TipoToken.COMILLA:
                    return "COMILLA";

                case TipoToken.LAST:
                    return "LAST";

                case TipoToken.COMA:
                    return "COMA";
                case TipoToken.COMENTARIO_LINEA:
                    return "Comentario de Linea";
                case TipoToken.COMENTARIO_MULTILINEA:
                    return "Comentario MultiLinea";
                case TipoToken.COMO:
                    return "COMO";
                case TipoToken.CORCHETE_ABIERTO:
                    return "[";
                case TipoToken.CORCHETE_CERRADO:
                    return "]";
                case TipoToken.CREAR:
                    return "Crear";
                case TipoToken.DE:
                    return "DE";
                case TipoToken.DECIMAL:
                    return "DECIMAL";
                case TipoToken.DIGITO:
                    return "digito";
                case TipoToken.DONDE:
                    return "DONDE";
                case TipoToken.ELIMINAR:
                    return "ELIMINAR";


                case TipoToken.EN:
                    return "EN";

                case TipoToken.ENTERO:
                    return "Entero";

                case TipoToken.ESTABLECER:
                    return "Establecer";

                case TipoToken.FECHA:
                    return "FECHA";

                case TipoToken.FECHAS:
                    return "FECHAS";

                case TipoToken.FLOTANTE:
                    return "FLOTANTE";

                case TipoToken.ID:
                    return "ID";

                case TipoToken.IGUAL:
                    return "IGUAL";

                case TipoToken.INSERTAR:
                    return "INSERTAR";

                case TipoToken.MAYOR:
                    return "MAYOR";

                case TipoToken.MAYOR_IGUAL:
                    return "MAYOR IGUAL";

                case TipoToken.MENOR:
                    return "MENOR";

                case TipoToken.MENOR_IGUAL:
                    return "MENOR IGUAL";

                case TipoToken.MODIFICAR:
                    return "MODIFICAR";

                case TipoToken.O:
                    return "O";

                case TipoToken.PARENTESIS_ABIERTO:
                    return "(";

                case TipoToken.PARENTESIS_CERRADO:
                    return ")";

                case TipoToken.PUNTO:
                    return ".";
                case TipoToken.PUNTO_y_COMA:
                    return ";";
                case TipoToken.SELECCIONAR:
                    return "Seleccionar";
                case TipoToken.TAABLA:
                    return "TABLA";
                case TipoToken.VALORES:
                    return "valores";
                case TipoToken.Y:
                    return "YYYYY";
                case TipoToken.DIFERENTE:
                    return "Diferente";
           
                default:
                    return "DESCONOCIDO";
            }
        }
            public String getLexema()
        {
            return this.Lexema;
        }
        public int getIdToken()
        {
            return this.idToken;
        }
        public int getindice()
        {
            return this.indice;
        }
        public int getindice2()
        {
            return this.indice2;
        }
        public String getValor()
        {
            return this.Valor;
        }
        public String getTipo1()
        {
            return this.tipo1;
        }

        public int geTfila()
        {
            return this.fila;
        }
        public int getcolumna()
        {
            return this.columna;
        }

    }
}
