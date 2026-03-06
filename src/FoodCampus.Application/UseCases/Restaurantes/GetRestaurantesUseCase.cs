using FoodCampus.Application.DTOs;
using FoodCampus.Application.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCampus.Application.UseCases.Restaurantes;

public class GetRestaurantesUseCase
{
    private readonly IRestauranteRepository _repository;

    public GetRestaurantesUseCase(IRestauranteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<RestauranteDto>> ExecuteAsync()
    {
        var restaurantes = await _repository.GetAllAsync();
        return restaurantes.Select(r => new RestauranteDto
        {
            Id = r.Id,
            Nombre = r.Nombre,
            Especialidad = r.Especialidad,
            HorarioApertura = r.HorarioApertura,
            HorarioCierre = r.HorarioCierre
        });
    }
}
