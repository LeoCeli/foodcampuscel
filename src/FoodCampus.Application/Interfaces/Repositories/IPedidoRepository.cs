using FoodCampus.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodCampus.Application.Interfaces.Repositories;

public interface IPedidoRepository
{
    Task<int> AddAsync(Pedido pedido);
    Task<Pedido?> GetByIdAsync(int idPedido);
    Task<IEnumerable<Pedido>> GetByUsuarioAsync(int idUsuario);
}
