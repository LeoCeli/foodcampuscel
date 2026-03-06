using FoodCampus.Application.Interfaces.Repositories;
using FoodCampus.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodCampus.Infrastructure.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly string _connectionString;

    public PedidoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<int> AddAsync(Pedido pedido)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(
            "INSERT INTO Pedido (IdUsuario, FechaHora, CostoEnvio) " +
            "VALUES (@IdUsuario, @FechaHora, @CostoEnvio); " +
            "SELECT SCOPE_IDENTITY();", connection);

        command.Parameters.AddWithValue("@IdUsuario", pedido.IdUsuario);
        command.Parameters.AddWithValue("@FechaHora", pedido.FechaHora);
        command.Parameters.AddWithValue("@CostoEnvio", pedido.CostoEnvio);

        await connection.OpenAsync();
        var result = await command.ExecuteScalarAsync();
        return Convert.ToInt32(result);
    }

    public async Task<Pedido?> GetByIdAsync(int idPedido)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand("SELECT IdPedido, IdUsuario, FechaHora, CostoEnvio FROM Pedido WHERE IdPedido = @IdPedido", connection);
        command.Parameters.AddWithValue("@IdPedido", idPedido);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new Pedido(
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetDateTime(2),
                reader.GetDecimal(3)
            );
        }
        return null;
    }

    public async Task<IEnumerable<Pedido>> GetByUsuarioAsync(int idUsuario)
    {
        var pedidos = new List<Pedido>();
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand("SELECT IdPedido, IdUsuario, FechaHora, CostoEnvio FROM Pedido WHERE IdUsuario = @IdUsuario", connection);
        command.Parameters.AddWithValue("@IdUsuario", idUsuario);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            pedidos.Add(new Pedido(
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetDateTime(2),
                reader.GetDecimal(3)
            ));
        }
        return pedidos;
    }
}
