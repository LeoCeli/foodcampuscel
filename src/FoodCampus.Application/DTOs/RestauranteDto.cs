using System;

namespace FoodCampus.Application.DTOs;

public class RestauranteDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Especialidad { get; set; } = string.Empty;
    public TimeSpan HorarioApertura { get; set; }
    public TimeSpan HorarioCierre { get; set; }
}

public class CrearRestauranteDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Especialidad { get; set; } = string.Empty;
    public TimeSpan HorarioApertura { get; set; }
    public TimeSpan HorarioCierre { get; set; }
}
