using FoodCampus.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodCampus.Application.Interfaces.Repositories;

public interface IDetallePedidoRepository
{
    Task AddAsync(DetallePedido detalle);
    Task<IEnumerable<DetallePedido>> GetByPedidoAsync(int idPedido);
}
