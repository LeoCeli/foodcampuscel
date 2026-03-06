using System;

namespace FoodCampus.Application.DTOs;

public class PedidoDto
{
    public int IdPedido { get; set; }
    public int IdUsuario { get; set; }
    public DateTime FechaHora { get; set; }
    public decimal CostoEnvio { get; set; }
}

public class CrearPedidoDto
{
    public int IdUsuario { get; set; }
    public DateTime FechaHora { get; set; }
    public decimal CostoEnvio { get; set; }
}
