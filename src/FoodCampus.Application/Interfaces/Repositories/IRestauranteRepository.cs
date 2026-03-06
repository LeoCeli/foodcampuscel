using FoodCampus.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodCampus.Application.Interfaces.Repositories;

public interface IRestauranteRepository
{
    Task<int> AddAsync(Restaurante restaurante);
    Task<IEnumerable<Restaurante>> GetAllAsync();
    Task<Restaurante?> GetByIdAsync(int id);
}
