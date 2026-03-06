using FoodCampus.Application.Interfaces.Repositories;
using FoodCampus.Application.UseCases.Restaurantes;
using FoodCampus.Application.UseCases.Pedidos;
using FoodCampus.Application.UseCases.DetallesPedido;
using FoodCampus.Application.UseCases.Platillos;
using FoodCampus.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace FoodCampus.Console;

class Program
{
    static async Task Main(string[] args)
    {
        string connectionString = "workstation id=develope-utm-ommm-celis.mssql.somee.com;packet size=4096;user id=dibu_SQLLogin_1;pwd=tk4x9n97ej;data source=develope-utm-ommm-celis.mssql.somee.com;persist security info=False;initial catalog=develope-utm-ommm-celis;TrustServerCertificate=True";

        var serviceProvider = new ServiceCollection()
            // Repositorios
            .AddSingleton<IRestauranteRepository>(new RestauranteRepository(connectionString))
            .AddSingleton<IPedidoRepository>(new PedidoRepository(connectionString))
            .AddSingleton<IDetallePedidoRepository>(new DetallePedidoRepository(connectionString))
            .AddSingleton<IPlatilloRepository>(new PlatilloRepository(connectionString))
            
            // Use Cases
            .AddTransient<CreateRestauranteUseCase>()
            .AddTransient<GetRestaurantesUseCase>()
            .AddTransient<GetRestauranteByIdUseCase>()
            .AddTransient<CreatePedidoUseCase>()
            .AddTransient<GetPedidoByIdUseCase>()
            .AddTransient<GetPedidosByUsuarioUseCase>()
            .AddTransient<AddDetallePedidoUseCase>()
            .AddTransient<GetDetallesPedidoUseCase>()
            .AddTransient<CreatePlatilloUseCase>()
            .AddTransient<GetPlatillosPorRestauranteUseCase>()
            
            // UI Services
            .AddTransient<MenuService>()
            
            .BuildServiceProvider();

        var menuService = serviceProvider.GetRequiredService<MenuService>();
        await menuService.ShowMenuAsync();
    }
}
