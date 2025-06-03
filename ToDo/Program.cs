using EspacioTareas;
using System.Collections.Generic;
//Creo la lista de tareas 
List<Tareas> tareasPendientes = new List<Tareas>();

//Clase para poder generar numeros aleatorios
Random numeroRandom = new Random();

//Para ingresar cuantas listas se quieren crear
Console.WriteLine("¿Cuantas listas quiere crear?");
int numListas = int.Parse(Console.ReadLine());

//Creo un array con posibles descripciones
string[] descripcionesDeTareas = new string[]
{
    "Arreglar BUG",
    "Optimizar codigo",
    "Actualizar algun dato",
    "Documentar codigo",
    "Corregir variables",
    "Cambiar constantes"
};

//Para crear aleatoriamente listas
for (int i = 0; i < numListas; i++)
{
    //Creo y agrego las tareas a la lista con el .Add
    tareasPendientes.Add(new Tareas(i + 1, descripcionesDeTareas[numeroRandom.Next(descripcionesDeTareas.Length)], numeroRandom.Next(10, 101))); //Tengo que crear una nueva instancia por cada tarea creada, por eso el "new Tareas"
    //Saco del array de descripciones, con un numero aleatorio, para poder tener mas opciones de descripciones
}

//Para mostrar las tareas que tenemos dentro de la lista usamos foreach "recomendado para no usar indices"

foreach (Tareas tareas in tareasPendientes)
{
    Console.WriteLine("------");
    Console.WriteLine($"El ID de la tarea es: {tareas.TareaID}");
    Console.WriteLine($"La Descripcion de la tarea es: {tareas.Descripcion}");
    Console.WriteLine($"El Duracion de la tarea es: {tareas.Duracion} horas");
    Console.WriteLine("------");
}

//Nueva lista para mover las tareas realizadas
List<Tareas> tareasRealizadas = new List<Tareas>();

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

Console.WriteLine("----Despues de la eliminacion---- ¿?Si es que hay");

foreach (Tareas tareas in tareasPendientes)
{
    Console.WriteLine("------");
    Console.WriteLine($"El ID de la tarea es: {tareas.TareaID}");
    Console.WriteLine($"La Descripcion de la tarea es: {tareas.Descripcion}");
    Console.WriteLine($"El Duracion de la tarea es: {tareas.Duracion} horas");
    Console.WriteLine("------");
}

Console.WriteLine("----Despues de agregar la lista de realizadas---- ¿?Si es que hay");

foreach (Tareas tareas in tareasRealizadas)
{
    Console.WriteLine("------");
    Console.WriteLine($"El ID de la tarea es: {tareas.TareaID}");
    Console.WriteLine($"La Descripcion de la tarea es: {tareas.Descripcion}");
    Console.WriteLine($"El Duracion de la tarea es: {tareas.Duracion} horas");
    Console.WriteLine("------");
}
Console.WriteLine("----Para buscar por descripcion----");
BuscarTareaPorDescripcion("Documentar codigo");

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




// Solo codigo para recordar por ahora

/* for (int i = 0; i < tareasPendientes.Count; i++)
{
    if (tareasPendientes[i].Duracion == 20)
    {
        tareasPendientes.RemoveAt(i);
    }
} */