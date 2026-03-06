using FoodCampus.Application.Interfaces.Repositories;
using FoodCampus.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FoodCampus.Infrastructure.Repositories;

public class RestauranteRepository : IRestauranteRepository
{
    private readonly string _connectionString;

    public RestauranteRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<int> AddAsync(Restaurante restaurante)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(
            "INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) " +
            "VALUES (@Nombre, @Especialidad, @HorarioApertura, @HorarioCierre); " +
            "SELECT SCOPE_IDENTITY();", connection);

        command.Parameters.AddWithValue("@Nombre", restaurante.Nombre);
        command.Parameters.AddWithValue("@Especialidad", restaurante.Especialidad);
        command.Parameters.AddWithValue("@HorarioApertura", restaurante.HorarioApertura);
        command.Parameters.AddWithValue("@HorarioCierre", restaurante.HorarioCierre);

        await connection.OpenAsync();
        var result = await command.ExecuteScalarAsync();
        return Convert.ToInt32(result);
    }

    public async Task<IEnumerable<Restaurante>> GetAllAsync()
    {
        var restaurantes = new List<Restaurante>();
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand("SELECT Id, Nombre, Especialidad, HorarioApertura, HorarioCierre FROM Restaurante", connection);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            restaurantes.Add(new Restaurante(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetTimeSpan(3),
                reader.GetTimeSpan(4)
            ));
        }
        return restaurantes;
    }

    public async Task<Restaurante?> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand("SELECT Id, Nombre, Especialidad, HorarioApertura, HorarioCierre FROM Restaurante WHERE Id = @Id", connection);
        command.Parameters.AddWithValue("@Id", id);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new Restaurante(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetTimeSpan(3),
                reader.GetTimeSpan(4)
            );
        }
        return null;
    }
}
