using FoodCampus.Application.Interfaces.Repositories;
using FoodCampus.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodCampus.Infrastructure.Repositories;

public class DetallePedidoRepository : IDetallePedidoRepository
{
    private readonly string _connectionString;

    public DetallePedidoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task AddAsync(DetallePedido detalle)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(
            "INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) " +
            "VALUES (@IdPedido, @IdPlatillo, @Cantidad, @Subtotal)", connection);

        command.Parameters.AddWithValue("@IdPedido", detalle.IdPedido);
        command.Parameters.AddWithValue("@IdPlatillo", detalle.IdPlatillo);
        command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
        command.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }

    public async Task<IEnumerable<DetallePedido>> GetByPedidoAsync(int idPedido)
    {
        var detalles = new List<DetallePedido>();
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand("SELECT IdDetalle, IdPedido, IdPlatillo, Cantidad, Subtotal FROM DetallePedido WHERE IdPedido = @IdPedido", connection);
        command.Parameters.AddWithValue("@IdPedido", idPedido);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            detalles.Add(new DetallePedido(
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetInt32(2),
                reader.GetInt32(3),
                reader.GetDecimal(4)
            ));
        }
        return detalles;
    }
}
