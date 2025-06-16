using EspacioHistorial;
//Clase calculadora, para poder realizar las operaciones
namespace EspacioCalculadora
{
    public class Calculadora
    {
        private double dato; //Este es el numero fijo, digamos el resultadoAnterior
        private List<Operacion> historial;//Lista para poder guardar las operaciones realizadas y tner el historial
        public double Resultado { get => dato; } //Propiedad para poder acceder al valor
        public List<Operacion> Historial { get => historial; } 

        //Constructor, se le pasa el numero inicial, al que se le desea operar
        public Calculadora(double dato)
        {
            this.dato = dato;
            this.historial = new List<Operacion>();
        }
        public void Sumar(double termino)
        {
            Operacion nuevaOperacion = new Operacion(dato, termino, TipoOperacion.Suma); //Se crea un nuevo objeto operacion, pasandole el resultado anteror / el nuevo valor = termino / Y el tipo de operador
            historial.Add(nuevaOperacion); // Se agrega el objeto a la lista del historial 
            dato = nuevaOperacion.Resultado; //Se le asigna a dato(El resultado anterior o el actual segun se vea) el resultado de la operacion
        }
        public void Restar(double termino)
        {
            Operacion nuevaOperacion = new Operacion(dato, termino, TipoOperacion.Resta);
            historial.Add(nuevaOperacion);
            dato = nuevaOperacion.Resultado;
        }
        public void Multiplicar(double termino)
        {
            Operacion nuevaOperacion = new Operacion(dato, termino, TipoOperacion.Multiplicacion);
            historial.Add(nuevaOperacion);
            dato = nuevaOperacion.Resultado;
        }
        public void Dividir(double termino)
        {
            if (termino != 0)
            {
                Operacion nuevaOperacion = new Operacion(dato, termino, TipoOperacion.Division);
                historial.Add(nuevaOperacion);
                dato = nuevaOperacion.Resultado;
            }
        }
        public void Limpiar()
        {
            Operacion nuevaOperacion = new Operacion(dato, 0, TipoOperacion.Limpiar);
            historial.Add(nuevaOperacion);
            dato = nuevaOperacion.Resultado;
        }
        public List<Operacion> ObtenerHistorial() //Funcion que sirve solamente para obtener el historial y poder pasarlo como parametro 
        {
            return historial;
        }
    }
}