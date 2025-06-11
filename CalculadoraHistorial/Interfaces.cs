namespace EspacioInterfaces
{
    class Interfaces
    {
        public void Bienvenida()
        {
            Console.WriteLine("Bienvenido a la calculadora");
        }
        public void Guiones()
        {
            Console.WriteLine("----------");
        }
        public void Salida()
        {
            Console.WriteLine("Gracias por usar la calculadora");
        }

        //Para poder pedirle los datos al usuario y poder reutilizar codigo
        public double PedirDatos(string operacion)
        {
            double numPedido;
            Console.WriteLine($"Ingrese el numero por el que desea {operacion}");
            var pedirNumero = Console.ReadLine();
            bool resultado = double.TryParse(pedirNumero, out numPedido);
            if (resultado) return numPedido;
            return 0;
        }
    }
}