using FoodCampus.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodCampus.Application.Interfaces.Repositories;

public interface IPlatilloRepository
{
    Task<int> AddAsync(Platillo platillo);
    Task<IEnumerable<Platillo>> GetByRestauranteAsync(int idRestaurante);
}
