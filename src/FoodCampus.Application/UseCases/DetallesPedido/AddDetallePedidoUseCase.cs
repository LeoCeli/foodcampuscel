using FoodCampus.Application.DTOs;
using FoodCampus.Application.Interfaces.Repositories;
using FoodCampus.Domain.Entities;
using System.Threading.Tasks;

namespace FoodCampus.Application.UseCases.DetallesPedido;

public class AddDetallePedidoUseCase
{
    private readonly IDetallePedidoRepository _repository;

    public AddDetallePedidoUseCase(IDetallePedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(CrearDetallePedidoDto dto)
    {
        var detalle = new DetallePedido(
            0,
            dto.IdPedido,
            dto.IdPlatillo,
            dto.Cantidad,
            dto.Subtotal
        );

        await _repository.AddAsync(detalle);
    }
}
