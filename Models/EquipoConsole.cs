namespace parcial1.Models;

public class EquipoConsole
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Anio { get; set; }
    public string Pais { get; set; }

    public virtual ICollection<Equipo> Equipos { get; set; }
}