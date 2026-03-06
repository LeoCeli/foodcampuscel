using System;

namespace FoodCampus.Domain.Entities;

public class Pedido
{
    public int IdPedido { get; private set; }
    public int IdUsuario { get; private set; }
    public DateTime FechaHora { get; private set; }
    public decimal CostoEnvio { get; private set; }

    public Pedido(int idPedido, int idUsuario, DateTime fechaHora, decimal costoEnvio)
    {
        if (costoEnvio < 0) throw new ArgumentException("El costo de envío no puede ser negativo.", nameof(costoEnvio));

        IdPedido = idPedido;
        IdUsuario = idUsuario;
        FechaHora = fechaHora;
        CostoEnvio = costoEnvio;
    }
}
