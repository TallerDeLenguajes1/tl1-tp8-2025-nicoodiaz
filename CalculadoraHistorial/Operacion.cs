namespace EspacioOperaciones
{
    enum TipoOperacion
    {
        Suma,
        Resta,
        Division,
        Multiplicacion,
        Limpiar
    }
    public class Operacion
    {
        private double resultadoAnterior; //Resultado de la operacion anterior
        private double nuevoValor; //Resultado de la nueva operacion que se va a hacer
        private TipoOperacion operacion;
        public double Resultado()
        {
            //Logica para calcular o devolver el resultado
        }

        //Propiedad publica  para acceder al nuevo valor utilizando en la operacion
        public double NuevoValor
        {
            get{}
        }
            //Constructor u otros metodos necesarios para inicializar y gestionar la operacion
            //...
        
    }
}