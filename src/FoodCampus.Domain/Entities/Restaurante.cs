using System;

namespace FoodCampus.Domain.Entities;

public class Restaurante
{
    public int Id { get; private set; }
    public string Nombre { get; private set; }
    public string Especialidad { get; private set; }
    public TimeSpan HorarioApertura { get; private set; }
    public TimeSpan HorarioCierre { get; private set; }

    public Restaurante(int id, string nombre, string especialidad, TimeSpan horarioApertura, TimeSpan horarioCierre)
    {
        if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
        if (string.IsNullOrWhiteSpace(especialidad)) throw new ArgumentException("La especialidad no puede estar vacía.", nameof(especialidad));

        Id = id;
        Nombre = nombre;
        Especialidad = especialidad;
        HorarioApertura = horarioApertura;
        HorarioCierre = horarioCierre;
    }
}
