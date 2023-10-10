namespace parcial1.ViewModels;


public class EquipoListVM
{
    public List<EquipoVM> Equipos { get; set; }  = new List<EquipoVM>(); 

    public string? Filter { get; set; }
}