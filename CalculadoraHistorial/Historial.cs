namespace EspacioHistorial
{
    public class Operacion
    {
        //Declaracion de variables
        private double resultadoAnterior; //Resultado de la operacion anterior
        private double nuevoValor; //Resultado de la nueva operacion que se va a hacer
        private TipoOperacion operador; //Tipor de operacion realizada
        private double resultado;

        //Propiedades para poder acceder a los valores de las variables
        public double ResultadoAnterior { get => resultadoAnterior; }
        public double NuevoValor { get => nuevoValor; }
        public double Resultado { get => resultado; }
        public TipoOperacion Operador { get => operador; }

        //Constructor u otros metodos necesarios para inicializar y gestionar la operacion
        public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operador)
        {
            this.resultadoAnterior = resultadoAnterior;
            this.nuevoValor = nuevoValor;
            this.operador = operador;
            double resultadoComodin = 0;
            //Segun el operador que se selecciona, se realiza la operacion
            switch (operador)
            {
                case TipoOperacion.Suma:
                    resultadoComodin = resultadoAnterior + nuevoValor;
                    break;
                case TipoOperacion.Resta:
                    resultadoComodin = resultadoAnterior - nuevoValor;
                    break;
                case TipoOperacion.Division:
                    resultadoComodin = resultadoAnterior / nuevoValor;
                    break;
                case TipoOperacion.Multiplicacion:
                    resultadoComodin = resultadoAnterior * nuevoValor;
                    break;
                case TipoOperacion.Limpiar:
                    resultadoComodin = 0;
                    break;
            }
            this.resultado = resultadoComodin;
        }
    }
    //enum, para poder tener las operaciones
        public enum TipoOperacion
    {
        Suma,
        Resta,
        Division,
        Multiplicacion,
        Limpiar
    }
}