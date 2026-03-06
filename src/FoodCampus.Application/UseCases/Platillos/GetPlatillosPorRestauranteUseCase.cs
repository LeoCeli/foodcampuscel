using FoodCampus.Application.DTOs;
using FoodCampus.Application.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCampus.Application.UseCases.Platillos;

public class GetPlatillosPorRestauranteUseCase
{
    private readonly IPlatilloRepository _repository;

    public GetPlatillosPorRestauranteUseCase(IPlatilloRepository repository) => _repository = repository;

    public async Task<IEnumerable<PlatilloDto>> ExecuteAsync(int idRestaurante)
    {
        var platillos = await _repository.GetByRestauranteAsync(idRestaurante);
        return platillos.Select(p => new PlatilloDto {
            IdPlatillo = p.IdPlatillo,
            IdRestaurante = p.IdRestaurante,
            Nombre = p.Nombre,
            Precio = p.Precio,
            Descripcion = p.Descripcion
        });
    }
}
