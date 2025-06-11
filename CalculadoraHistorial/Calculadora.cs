using EspacioHistorial;
//Clase calculadora, para poder realizar las operaciones
namespace EspacioCalculadora
{
    public class Calculadora
    {
        private double dato;
        private List<Operacion> historial;
        public double Resultado { get => dato; }

        //Constructor
        public Calculadora(double dato)
        {
            this.dato = dato;
            this.historial = new List<Operacion>();
        }
        public void Sumar(double termino)
        {
            Operacion nuevaOperacion = new Operacion(dato, termino, TipoOperacion.Suma);
            historial.Add(nuevaOperacion);
            dato = nuevaOperacion.Resultado;
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
        public List<Operacion> ObtenerHistorial()
        {
            return historial;
        }
    }
}