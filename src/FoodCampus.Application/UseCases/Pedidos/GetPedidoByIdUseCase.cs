using FoodCampus.Application.DTOs;
using FoodCampus.Application.Interfaces.Repositories;
using System.Threading.Tasks;

namespace FoodCampus.Application.UseCases.Pedidos;

public class GetPedidoByIdUseCase
{
    private readonly IPedidoRepository _repository;

    public GetPedidoByIdUseCase(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task<PedidoDto?> ExecuteAsync(int id)
    {
        var pedido = await _repository.GetByIdAsync(id);
        if (pedido == null) return null;

        return new PedidoDto
        {
            IdPedido = pedido.IdPedido,
            IdUsuario = pedido.IdUsuario,
            FechaHora = pedido.FechaHora,
            CostoEnvio = pedido.CostoEnvio
        };
    }
}
