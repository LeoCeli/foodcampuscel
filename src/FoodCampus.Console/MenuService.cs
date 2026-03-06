using FoodCampus.Application.DTOs;
using FoodCampus.Application.UseCases.Restaurantes;
using FoodCampus.Application.UseCases.Pedidos;
using FoodCampus.Application.UseCases.DetallesPedido;
using FoodCampus.Application.UseCases.Platillos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodCampus.Console;

public class MenuService
{
    private readonly CreateRestauranteUseCase _createRestauranteUseCase;
    private readonly GetRestaurantesUseCase _getRestaurantesUseCase;
    private readonly CreatePedidoUseCase _createPedidoUseCase;
    private readonly GetPedidosByUsuarioUseCase _getPedidosByUsuarioUseCase;
    private readonly AddDetallePedidoUseCase _addDetallePedidoUseCase;
    private readonly GetDetallesPedidoUseCase _getDetallesPedidoUseCase;
    private readonly CreatePlatilloUseCase _createPlatilloUseCase;
    private readonly GetPlatillosPorRestauranteUseCase _getPlatillosPorRestauranteUseCase;

    public MenuService(
        CreateRestauranteUseCase createRestauranteUseCase,
        GetRestaurantesUseCase getRestaurantesUseCase,
        CreatePedidoUseCase createPedidoUseCase,
        GetPedidosByUsuarioUseCase getPedidosByUsuarioUseCase,
        AddDetallePedidoUseCase addDetallePedidoUseCase,
        GetDetallesPedidoUseCase getDetallesPedidoUseCase,
        CreatePlatilloUseCase createPlatilloUseCase,
        GetPlatillosPorRestauranteUseCase getPlatillosPorRestauranteUseCase)
    {
        _createRestauranteUseCase = createRestauranteUseCase;
        _getRestaurantesUseCase = getRestaurantesUseCase;
        _createPedidoUseCase = createPedidoUseCase;
        _getPedidosByUsuarioUseCase = getPedidosByUsuarioUseCase;
        _addDetallePedidoUseCase = addDetallePedidoUseCase;
        _getDetallesPedidoUseCase = getDetallesPedidoUseCase;
        _createPlatilloUseCase = createPlatilloUseCase;
        _getPlatillosPorRestauranteUseCase = getPlatillosPorRestauranteUseCase;
    }

    public async Task ShowMenuAsync()
    {
        bool exit = false;
        while (!exit)
        {
            System.Console.Clear();
            System.Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine("===== FOODCAMPUS - DELIVERY UNIVERSITARIO =====");
            System.Console.ResetColor();
            System.Console.WriteLine("1. Ver restaurantes");
            System.Console.WriteLine("2. Crear restaurante");
            System.Console.WriteLine("3. Crear pedido");
            System.Console.WriteLine("4. Agregar detalle a pedido");
            System.Console.WriteLine("5. Ver pedidos por usuario");
            System.Console.WriteLine("6. Ver detalles de pedido");
            System.Console.WriteLine("7. Gestión de Platillos");
            System.Console.WriteLine("0. Salir");
            System.Console.WriteLine("===============================================");
            System.Console.Write("Seleccione una opción: ");

            string? option = System.Console.ReadLine();

            try
            {
                switch (option)
                {
                    case "1": await ShowRestaurantesAsync(); break;
                    case "2": await CreateRestauranteAsync(); break;
                    case "3": await CreatePedidoAsync(); break;
                    case "4": await AddDetallePedidoAsync(); break;
                    case "5": await ShowPedidosByUsuarioAsync(); break;
                    case "6": await ShowDetallesPedidoAsync(); break;
                    case "7": await ManagePlatillosMenuAsync(); break;
                    case "0": exit = true; break;
                    default:
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Opción no válida.");
                        System.Console.ResetColor();
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Error: {ex.Message}");
                System.Console.ResetColor();
            }

            if (!exit)
            {
                System.Console.WriteLine("\nPresione cualquier tecla para continuar...");
                System.Console.ReadKey();
            }
        }
    }

    private async Task ManagePlatillosMenuAsync()
    {
        System.Console.WriteLine("\n--- GESTIÓN DE PLATILLOS ---");
        System.Console.WriteLine("1. Ver platillos por restaurante");
        System.Console.WriteLine("2. Registrar nuevo platillo");
        System.Console.Write("Seleccione una opción: ");
        var opt = System.Console.ReadLine();

        if (opt == "1")
        {
            System.Console.Write("ID del Restaurante: ");
            if (int.TryParse(System.Console.ReadLine(), out int id))
            {
                var platillos = await _getPlatillosPorRestauranteUseCase.ExecuteAsync(id);
                System.Console.WriteLine($"\n--- PLATILLOS DEL RESTAURANTE {id} ---");
                foreach (var p in platillos) 
                    System.Console.WriteLine($"[{p.IdPlatillo}] {p.Nombre} - ${p.Precio}: {p.Descripcion}");
            }
        }
        else if (opt == "2")
        {
            System.Console.Write("ID del Restaurante: ");
            if (!int.TryParse(System.Console.ReadLine(), out int resId)) return;
            System.Console.Write("Nombre Platillo: ");
            string nom = System.Console.ReadLine() ?? "";
            System.Console.Write("Precio: ");
            if (!decimal.TryParse(System.Console.ReadLine(), out decimal pre)) return;
            System.Console.Write("Descripción: ");
            string desc = System.Console.ReadLine() ?? "";

            int id = await _createPlatilloUseCase.ExecuteAsync(new CrearPlatilloDto
            {
                IdRestaurante = resId,
                Nombre = nom,
                Precio = pre,
                Descripcion = desc
            });
            PrintSuccess($"Platillo registrado correctamente con ID: {id}");
        }
    }

    private void PrintSuccess(string message)
    {
        System.Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine($"\nExito: {message}");
        System.Console.ResetColor();
    }

    private async Task ShowRestaurantesAsync()
    {
        System.Console.WriteLine("\n--- LISTADO DE RESTAURANTES ---");
        var restaurantes = await _getRestaurantesUseCase.ExecuteAsync();
        foreach (var r in restaurantes)
        {
            System.Console.WriteLine($"[{r.Id}] {r.Nombre} - Especialidad: {r.Especialidad} ({r.HorarioApertura:hh\\:mm} - {r.HorarioCierre:hh\\:mm})");
        }
    }

    private async Task CreateRestauranteAsync()
    {
        System.Console.WriteLine("\n--- CREAR RESTAURANTE ---");
        System.Console.Write("Nombre: ");
        string nombre = System.Console.ReadLine() ?? "";
        System.Console.Write("Especialidad: ");
        string especialidad = System.Console.ReadLine() ?? "";

        System.Console.Write("Horario Apertura (HH:mm): ");
        string aperturaInput = System.Console.ReadLine() ?? "";
        if (!TimeSpan.TryParse(aperturaInput, out var horarioApertura))
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Formato de hora inválido. Use HH:mm");
            System.Console.ResetColor();
            return;
        }

        System.Console.Write("Horario Cierre (HH:mm): ");
        string cierreInput = System.Console.ReadLine() ?? "";
        if (!TimeSpan.TryParse(cierreInput, out var horarioCierre))
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Formato de hora inválido. Use HH:mm");
            System.Console.ResetColor();
            return;
        }

        var dto = new CrearRestauranteDto
        {
            Nombre = nombre,
            Especialidad = especialidad,
            HorarioApertura = horarioApertura,
            HorarioCierre = horarioCierre
        };

        int id = await _createRestauranteUseCase.ExecuteAsync(dto);
        System.Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine($"Restaurante creado con éxito. ID: {id}");
        System.Console.ResetColor();
    }

    private async Task CreatePedidoAsync()
    {
        System.Console.WriteLine("\n--- CREAR PEDIDO ---");
        System.Console.Write("ID de Usuario: ");
        if (!int.TryParse(System.Console.ReadLine(), out int idUsuario)) return;
        
        System.Console.Write("Costo de Envío: ");
        if (!decimal.TryParse(System.Console.ReadLine(), out decimal costoEnvio)) return;

        var dto = new CrearPedidoDto
        {
            IdUsuario = idUsuario,
            FechaHora = DateTime.Now,
            CostoEnvio = costoEnvio
        };

        int id = await _createPedidoUseCase.ExecuteAsync(dto);
        System.Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine($"Pedido creado con éxito. ID: {id}");
        System.Console.ResetColor();
    }

    private async Task AddDetallePedidoAsync()
    {
        System.Console.WriteLine("\n--- AGREGAR DETALLE A PEDIDO ---");
        System.Console.Write("ID de Pedido: ");
        if (!int.TryParse(System.Console.ReadLine(), out int idPedido)) return;
        System.Console.Write("ID de Platillo: ");
        if (!int.TryParse(System.Console.ReadLine(), out int idPlatillo)) return;
        System.Console.Write("Cantidad: ");
        if (!int.TryParse(System.Console.ReadLine(), out int cantidad)) return;
        System.Console.Write("Subtotal: ");
        if (!decimal.TryParse(System.Console.ReadLine(), out decimal subtotal)) return;

        var dto = new CrearDetallePedidoDto
        {
            IdPedido = idPedido,
            IdPlatillo = idPlatillo,
            Cantidad = cantidad,
            Subtotal = subtotal
        };

        await _addDetallePedidoUseCase.ExecuteAsync(dto);
        System.Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("Detalle agregado con éxito.");
        System.Console.ResetColor();
    }

    private async Task ShowPedidosByUsuarioAsync()
    {
        System.Console.WriteLine("\n--- PEDIDOS POR USUARIO ---");
        System.Console.Write("Ingrese ID de Usuario: ");
        if (!int.TryParse(System.Console.ReadLine(), out int idUsuario)) return;

        var pedidos = await _getPedidosByUsuarioUseCase.ExecuteAsync(idUsuario);
        foreach (var p in pedidos)
        {
            System.Console.WriteLine($"Pedido #{p.IdPedido} - Fecha: {p.FechaHora} - Envío: ${p.CostoEnvio}");
        }
    }

    private async Task ShowDetallesPedidoAsync()
    {
        System.Console.WriteLine("\n--- DETALLES DE PEDIDO ---");
        System.Console.Write("Ingrese ID de Pedido: ");
        if (!int.TryParse(System.Console.ReadLine(), out int idPedido)) return;

        var detalles = await _getDetallesPedidoUseCase.ExecuteAsync(idPedido);
        foreach (var d in detalles)
        {
            System.Console.WriteLine($"Detalle #{d.IdDetalle} - Platillo ID: {d.IdPlatillo} - Cantidad: {d.Cantidad} - Subtotal: ${d.Subtotal}");
        }
    }
}
