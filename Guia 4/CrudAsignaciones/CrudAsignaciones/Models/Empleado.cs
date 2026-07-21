namespace CrudAsignaciones.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaContratacion {  get; set; }
        public string Puesto { get; set; }
    }
}
