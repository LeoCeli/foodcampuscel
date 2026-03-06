using System;

namespace FoodCampus.Domain.Entities;

public class DetallePedido
{
    public int IdDetalle { get; private set; }
    public int IdPedido { get; private set; }
    public int IdPlatillo { get; private set; }
    public int Cantidad { get; private set; }
    public decimal Subtotal { get; private set; }

    public DetallePedido(int idDetalle, int idPedido, int idPlatillo, int cantidad, decimal subtotal)
    {
        if (cantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor a cero.", nameof(cantidad));
        if (subtotal < 0) throw new ArgumentException("El subtotal no puede ser negativo.", nameof(subtotal));

        IdDetalle = idDetalle;
        IdPedido = idPedido;
        IdPlatillo = idPlatillo;
        Cantidad = cantidad;
        Subtotal = subtotal;
    }
}
