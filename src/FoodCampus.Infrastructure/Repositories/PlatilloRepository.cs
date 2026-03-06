using FoodCampus.Application.Interfaces.Repositories;
using FoodCampus.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodCampus.Infrastructure.Repositories;

public class PlatilloRepository : IPlatilloRepository
{
    private readonly string _connectionString;
    public PlatilloRepository(string connectionString) => _connectionString = connectionString;

    public async Task<int> AddAsync(Platillo platillo)
    {
        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(
            "INSERT INTO Platillo (IdRestaurante, Nombre, Precio, Descripcion) " +
            "VALUES (@IdRestaurante, @Nombre, @Precio, @Descripcion); SELECT SCOPE_IDENTITY();", conn);

        cmd.Parameters.AddWithValue("@IdRestaurante", platillo.IdRestaurante);
        cmd.Parameters.AddWithValue("@Nombre", platillo.Nombre);
        cmd.Parameters.AddWithValue("@Precio", platillo.Precio);
        cmd.Parameters.AddWithValue("@Descripcion", (object?)platillo.Descripcion ?? DBNull.Value);

        await conn.OpenAsync();
        return Convert.ToInt32(await cmd.ExecuteScalarAsync());
    }

    public async Task<IEnumerable<Platillo>> GetByRestauranteAsync(int idRestaurante)
    {
        var list = new List<Platillo>();
        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("SELECT IdPlatillo, IdRestaurante, Nombre, Precio, Descripcion FROM Platillo WHERE IdRestaurante = @IdRestaurante", conn);
        cmd.Parameters.AddWithValue("@IdRestaurante", idRestaurante);

        await conn.OpenAsync();
        using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            list.Add(new Platillo(
                reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), 
                reader.GetDecimal(3), reader.IsDBNull(4) ? null : reader.GetString(4)));
        }
        return list;
    }
}
