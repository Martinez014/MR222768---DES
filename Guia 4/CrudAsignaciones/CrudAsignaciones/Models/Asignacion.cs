namespace CrudAsignaciones.Models
{
    public class Asignacion
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int ProyectoId { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public string Rol { get; set; }
        public Empleado? Empleado { get; set; }
        public Proyecto? Proyecto { get; set; }
    }
}
