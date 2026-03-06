using FoodCampus.Application.DTOs;
using FoodCampus.Application.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCampus.Application.UseCases.Pedidos;

public class GetPedidosByUsuarioUseCase
{
    private readonly IPedidoRepository _repository;

    public GetPedidosByUsuarioUseCase(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PedidoDto>> ExecuteAsync(int idUsuario)
    {
        var pedidos = await _repository.GetByUsuarioAsync(idUsuario);
        return pedidos.Select(p => new PedidoDto
        {
            IdPedido = p.IdPedido,
            IdUsuario = p.IdUsuario,
            FechaHora = p.FechaHora,
            CostoEnvio = p.CostoEnvio
        });
    }
}
