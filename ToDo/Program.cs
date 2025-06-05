using EspacioTareas;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
//Creo la lista de tareas pendientes
List<Tareas> tareasPendientes = new List<Tareas>();
//Nueva lista para mover las tareas realizadas
List<Tareas> tareasRealizadas = new List<Tareas>();

//Clase para poder generar numeros aleatorios
Random numeroRandom = new Random();
int idTarea = 0;
string descripcionDeTareas;

Console.WriteLine("------Bienvenido a ToDo------");
int opcion = 0;
//--------MENU INTERACTIVO--------
do
{
    Console.WriteLine("Selecciona una opcion del menu: ");
    Console.WriteLine("1. Crear una tarea");
    Console.WriteLine("2. Mover una tarea pendiente a realizada mediante ID");
    Console.WriteLine("3. Buscar una tarea por descripcion");
    Console.WriteLine("4. Mostrar las tareas");
    Console.WriteLine("5. Salir del menu.");
    Console.WriteLine("-----------------");
    var pedirOpcion = Console.ReadLine();
    bool resultadOpcion = int.TryParse(pedirOpcion, out opcion);
    //Primero controlar que ingrese un numero correcto
    if (resultadOpcion && opcion > 0 && opcion < 7)
    {
        switch (opcion)
        {
            case 1:
                //Para ingresar cuantas tareas se quieren crear
                Console.WriteLine("¿Cuantas tareas quiere crear?");
                int numListas = int.Parse(Console.ReadLine());
                //Para crear aleatoriamente listas
                for (int i = 0; i < numListas; i++)
                {
                    Console.WriteLine("Ingrese el ID de la tarea: ");
                    idTarea = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese la descripcion de la tarea: ");
                    descripcionDeTareas = Console.ReadLine();

                    //Creo y agrego las tareas a la lista con el .Add
                    tareasPendientes.Add(new Tareas(idTarea, descripcionDeTareas, numeroRandom.Next(10, 101))); //Tengo que crear una nueva instancia por cada tarea creada, por eso el "new Tareas"
                }
                break;
            case 2:
                int idTareaAMover = 0;
                Console.WriteLine("Ingrese el ID de la tarea que quiere marcar como completada");
                idTareaAMover = int.Parse(Console.ReadLine());

                //Creo la tarea a mover en null
                Tareas tareaAMover = null;
                //Recorro la lista buscando algun ID que coincida
                foreach (Tareas tareasPosiblesAMover in tareasPendientes)
                {
                    if (tareasPosiblesAMover.TareaID == idTareaAMover)
                    {
                        //Si conincide, le asigno la tarea esa, a la tarea inicializada en null
                        tareaAMover = tareasPosiblesAMover;
                    }
                }
                //Si la lista a mover, no es null, entonces la muevo a realizadas y despues la elimino
                if (tareaAMover != null)
                {
                    tareasRealizadas.Add(tareaAMover);
                    tareasPendientes.Remove(tareaAMover);
                    Console.WriteLine("La tarea se movio con exito");
                }
                else
                {
                    //Si no se encontro ningun ID, entonces muestra esto por pantalla
                    Console.WriteLine("No hay una tarea con ese ID.");
                }
                break;
            case 3:
                Console.WriteLine("----Para buscar por descripcion----");
                Console.WriteLine("Ingrese la descripcion de la tarea a buscar: ");
                string descripcionABuscar = Console.ReadLine();
                BuscarTareaPorDescripcion(descripcionABuscar);
                break;
            case 4:
                int opcionParaMostrarTareas;
                Console.WriteLine("¿Que listado de tareas quiere mostrar?");
                Console.WriteLine("1. Listado de tareas pendientes");
                Console.WriteLine("2. Listado de tareas realizadas");
                Console.WriteLine("3. Ambos listados");
                var pedirOpcionParaMostrarTareas = Console.ReadLine();
                bool resultadoParaMostrar = int.TryParse(pedirOpcionParaMostrarTareas, out opcionParaMostrarTareas);
                if (resultadoParaMostrar)
                {
                    switch (opcionParaMostrarTareas)
                    {
                        case 1:
                            Console.WriteLine("----Su listado de tareas pendientes----");
                            //Para mostrar las tareas que tenemos dentro de la lista usamos foreach "recomendado para no usar indices"
                            if (tareasPendientes.Count > 0)
                            {
                                foreach (Tareas tareas in tareasPendientes)
                                {
                                    Console.WriteLine("------");
                                    Console.WriteLine($"El ID de la tarea es: {tareas.TareaID}");
                                    Console.WriteLine($"La Descripcion de la tarea es: {tareas.Descripcion}");
                                    Console.WriteLine($"El Duracion de la tarea es: {tareas.Duracion} horas");
                                    Console.WriteLine("Estado: Pendiente❌");
                                    Console.WriteLine("------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Su listado de tareas pendientes esta vacia!.");
                                Console.WriteLine("-----------------");
                            }
                            break;
                        case 2:
                            Console.WriteLine("----Su listado de tareas realizadas----");

                            if (tareasRealizadas.Count > 0)
                            {
                                foreach (Tareas tareas in tareasRealizadas)
                                {
                                    Console.WriteLine("------");
                                    Console.WriteLine($"El ID de la tarea es: {tareas.TareaID}");
                                    Console.WriteLine($"La Descripcion de la tarea es: {tareas.Descripcion}");
                                    Console.WriteLine($"El Duracion de la tarea es: {tareas.Duracion} horas");
                                    Console.WriteLine("Estado: Realizada✅");
                                    Console.WriteLine("------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Su listado de tareas realizadas esta vacia!.");
                                Console.WriteLine("-----------------");
                            }
                            break;
                        case 3:
                            if (tareasRealizadas.Count > 0 || tareasPendientes.Count > 0)
                            {
                                foreach (Tareas tareas in tareasPendientes)
                                {
                                    Console.WriteLine("------");
                                    Console.WriteLine($"El ID de la tarea es: {tareas.TareaID}");
                                    Console.WriteLine($"La Descripcion de la tarea es: {tareas.Descripcion}");
                                    Console.WriteLine($"El Duracion de la tarea es: {tareas.Duracion} horas");
                                    Console.WriteLine("Estado: Pendiente❌");
                                    Console.WriteLine("------");
                                }
                                foreach (Tareas tareas in tareasRealizadas)
                                {
                                    Console.WriteLine("------");
                                    Console.WriteLine($"El ID de la tarea es: {tareas.TareaID}");
                                    Console.WriteLine($"La Descripcion de la tarea es: {tareas.Descripcion}");
                                    Console.WriteLine($"El Duracion de la tarea es: {tareas.Duracion} horas");
                                    Console.WriteLine("Estado: Realizada✅");
                                    Console.WriteLine("------");
                                }
                            }
                            break;
                    }
                }
                break;
        }
    }
    else
    {
        Console.WriteLine("No ingreso una opcion valida");
        Console.WriteLine("Ingrese una opcion nuevamente");
        opcion = 0;
    }
} while (opcion == 5);


    //Funcion para buscar la tarea mediante descripcion
void BuscarTareaPorDescripcion(string descripcionIngresada/* , List<Tareas> tareasPendientes */)
{
   Tareas tareaEncontrada = null;
    foreach (Tareas item in tareasPendientes)
    {
        if (descripcionIngresada == item.Descripcion)
        {
            tareaEncontrada = item;
            Console.WriteLine($"ID = {tareaEncontrada.TareaID} | Descripcion = {tareaEncontrada.Descripcion} | Duracion = {tareaEncontrada.Duracion}");
        }
    }
}



// Solo codigo para recordar por ahora, es para poder eliminar mas de una tarea a la vez, por ejemplo, si me piden que borre todas las tareas con duracion de mas de 30 min/horas

/* for (int i = 0; i < tareasPendientes.Count; i++)
{
    if (tareasPendientes[i].Duracion == 30)
    {
        tareasPendientes.RemoveAt(i);
    }
} */