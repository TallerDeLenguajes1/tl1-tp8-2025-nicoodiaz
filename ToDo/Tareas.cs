namespace EspacioTareas
{
    class Tareas
    {
        int tareaID; //Numerado en ciclo iterativo
        string descripcion;
        int duracion; //Entre 10-100

        public int TareaID { get => tareaID; set => tareaID = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Duracion { get => duracion; set => duracion = value; }

        public Tareas(int tareaID, string descripcion, int duracion)
        {
            this.TareaID = tareaID;
            this.Descripcion = descripcion;
            this.Duracion = duracion;
        }        
    }
}