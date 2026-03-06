using FoodCampus.Application.DTOs;
using FoodCampus.Application.Interfaces.Repositories;
using System.Threading.Tasks;

namespace FoodCampus.Application.UseCases.Restaurantes;

public class GetRestauranteByIdUseCase
{
    private readonly IRestauranteRepository _repository;

    public GetRestauranteByIdUseCase(IRestauranteRepository repository)
    {
        _repository = repository;
    }

    public async Task<RestauranteDto?> ExecuteAsync(int id)
    {
        var restaurante = await _repository.GetByIdAsync(id);
        if (restaurante == null) return null;

        return new RestauranteDto
        {
            Id = restaurante.Id,
            Nombre = restaurante.Nombre,
            Especialidad = restaurante.Especialidad,
            HorarioApertura = restaurante.HorarioApertura,
            HorarioCierre = restaurante.HorarioCierre
        };
    }
}
