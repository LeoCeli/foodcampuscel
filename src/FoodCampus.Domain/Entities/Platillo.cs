using System;

namespace FoodCampus.Domain.Entities;

public class Platillo
{
    public int IdPlatillo { get; private set; }
    public int IdRestaurante { get; private set; }
    public string Nombre { get; private set; }
    public decimal Precio { get; private set; }
    public string? Descripcion { get; private set; }

    public Platillo(int idPlatillo, int idRestaurante, string nombre, decimal precio, string? descripcion)
    {
        if (string.IsNullOrWhiteSpace(nombre)) 
            throw new ArgumentException("El nombre del platillo no puede estar vacío.", nameof(nombre));
        if (precio < 0) 
            throw new ArgumentException("El precio no puede ser negativo.", nameof(precio));

        IdPlatillo = idPlatillo;
        IdRestaurante = idRestaurante;
        Nombre = nombre;
        Precio = precio;
        Descripcion = descripcion;
    }
}
