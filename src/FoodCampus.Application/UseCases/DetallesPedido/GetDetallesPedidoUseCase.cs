using FoodCampus.Application.DTOs;
using FoodCampus.Application.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCampus.Application.UseCases.DetallesPedido;

public class GetDetallesPedidoUseCase
{
    private readonly IDetallePedidoRepository _repository;

    public GetDetallesPedidoUseCase(IDetallePedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DetallePedidoDto>> ExecuteAsync(int idPedido)
    {
        var detalles = await _repository.GetByPedidoAsync(idPedido);
        return detalles.Select(d => new DetallePedidoDto
        {
            IdDetalle = d.IdDetalle,
            IdPedido = d.IdPedido,
            IdPlatillo = d.IdPlatillo,
            Cantidad = d.Cantidad,
            Subtotal = d.Subtotal
        });
    }
}
