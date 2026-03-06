using System;

namespace FoodCampus.Application.DTOs;

public class DetallePedidoDto
{
    public int IdDetalle { get; set; }
    public int IdPedido { get; set; }
    public int IdPlatillo { get; set; }
    public int Cantidad { get; set; }
    public decimal Subtotal { get; set; }
}

public class CrearDetallePedidoDto
{
    public int IdPedido { get; set; }
    public int IdPlatillo { get; set; }
    public int Cantidad { get; set; }
    public decimal Subtotal { get; set; }
}
