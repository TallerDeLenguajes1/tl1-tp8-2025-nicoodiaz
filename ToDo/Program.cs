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