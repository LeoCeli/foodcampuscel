using FoodCampus.Application.DTOs;
using FoodCampus.Application.Interfaces.Repositories;
using FoodCampus.Domain.Entities;
using System.Threading.Tasks;

namespace FoodCampus.Application.UseCases.Pedidos;

public class CreatePedidoUseCase
{
    private readonly IPedidoRepository _repository;

    public CreatePedidoUseCase(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> ExecuteAsync(CrearPedidoDto dto)
    {
        var pedido = new Pedido(
            0,
            dto.IdUsuario,
            dto.FechaHora,
            dto.CostoEnvio
        );

        return await _repository.AddAsync(pedido);
    }
}
