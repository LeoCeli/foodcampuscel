using FoodCampus.Application.DTOs;
using FoodCampus.Application.Interfaces.Repositories;
using FoodCampus.Domain.Entities;
using System.Threading.Tasks;

namespace FoodCampus.Application.UseCases.Platillos;

public class CreatePlatilloUseCase
{
    private readonly IPlatilloRepository _repository;

    public CreatePlatilloUseCase(IPlatilloRepository repository) => _repository = repository;

    public async Task<int> ExecuteAsync(CrearPlatilloDto dto)
    {
        var platillo = new Platillo(0, dto.IdRestaurante, dto.Nombre, dto.Precio, dto.Descripcion);
        return await _repository.AddAsync(platillo);
    }
}
