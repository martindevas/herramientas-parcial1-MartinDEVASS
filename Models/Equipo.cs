namespace parcial1.Models;

public class Equipo
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Anio { get; set; }
    public string Pais { get; set; }
    public bool GanoEstaFecha { get; set; }
    public decimal PrecioEntrada { get; set; }
   
    public int? EquipoConsoleId { get; set; }

    public virtual EquipoConsole Console { get; set; }
}