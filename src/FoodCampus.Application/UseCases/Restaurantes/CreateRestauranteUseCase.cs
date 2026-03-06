using FoodCampus.Application.DTOs;
using FoodCampus.Application.Interfaces.Repositories;
using FoodCampus.Domain.Entities;
using System.Threading.Tasks;

namespace FoodCampus.Application.UseCases.Restaurantes;

public class CreateRestauranteUseCase
{
    private readonly IRestauranteRepository _repository;

    public CreateRestauranteUseCase(IRestauranteRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> ExecuteAsync(CrearRestauranteDto dto)
    {
        var restaurante = new Restaurante(
            0,
            dto.Nombre,
            dto.Especialidad,
            dto.HorarioApertura,
            dto.HorarioCierre
        );

        return await _repository.AddAsync(restaurante);
    }
}
