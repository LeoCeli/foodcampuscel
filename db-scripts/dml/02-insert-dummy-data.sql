-- =============================================
-- Author:      FoodCampus Team
-- Create date: 2026-03-06
-- Description: Script DML para inserción de datos de prueba (Dummy Data)
-- Target DB:   SQL Server (Somee)
-- =============================================

-- 1. Inserción de Restaurantes (Mínimo 5)
INSERT INTO [dbo].[Restaurante] ([Nombre], [Especialidad], [HorarioApertura], [HorarioCierre])
VALUES 
('Pizzería La Facultad', 'Italiana/Pizza', '10:00:00', '22:00:00'),
('Tacos El Decano', 'Mexicana/Tacos', '08:00:00', '20:00:00'),
('Sushi Study Break', 'Japonesa/Sushi', '12:00:00', '21:00:00'),
('Burger Lab', 'Americana/Hamburguesas', '11:00:00', '23:00:00'),
('Veggie Garden Campus', 'Saludable/Ensaladas', '09:00:00', '18:00:00');

-- 2. Inserción de Pedidos y sus Detalles
-- Usamos variables para capturar los IDs generados y mantener integridad referencial

DECLARE @IdPedido1 INT, @IdPedido2 INT, @IdPedido3 INT, @IdPedido4 INT, @IdPedido5 INT;

-- Pedido 1: Usuario 1001
INSERT INTO [dbo].[Pedido] ([IdUsuario], [FechaHora], [CostoEnvio])
VALUES (1001, GETDATE(), 2.50);
SET @IdPedido1 = SCOPE_IDENTITY();

INSERT INTO [dbo].[DetallePedido] ([IdPedido], [IdPlatillo], [Cantidad], [Subtotal])
VALUES (@IdPedido1, 10, 2, 15.00), -- 2 Pizzas
       (@IdPedido1, 11, 1, 3.50);  -- 1 Refresco

-- Pedido 2: Usuario 1002
INSERT INTO [dbo].[Pedido] ([IdUsuario], [FechaHora], [CostoEnvio])
VALUES (1002, DATEADD(HOUR, -2, GETDATE()), 0.00); -- Envío gratis
SET @IdPedido2 = SCOPE_IDENTITY();

INSERT INTO [dbo].[DetallePedido] ([IdPedido], [IdPlatillo], [Cantidad], [Subtotal])
VALUES (@IdPedido2, 20, 5, 12.50), -- 5 Tacos
       (@IdPedido2, 21, 1, 2.00),  -- 1 Agua
       (@IdPedido2, 22, 2, 4.00);  -- 2 Postres

-- Pedido 3: Usuario 1003
INSERT INTO [dbo].[Pedido] ([IdUsuario], [FechaHora], [CostoEnvio])
VALUES (1003, DATEADD(DAY, -1, GETDATE()), 3.00);
SET @IdPedido3 = SCOPE_IDENTITY();

INSERT INTO [dbo].[DetallePedido] ([IdPedido], [IdPlatillo], [Cantidad], [Subtotal])
VALUES (@IdPedido3, 30, 1, 18.00), -- 1 Charola Sushi
       (@IdPedido3, 31, 2, 5.00);  -- 2 Gyozas

-- Pedido 4: Usuario 1004
INSERT INTO [dbo].[Pedido] ([IdUsuario], [FechaHora], [CostoEnvio])
VALUES (1004, DATEADD(HOUR, -5, GETDATE()), 1.50);
SET @IdPedido4 = SCOPE_IDENTITY();

INSERT INTO [dbo].[DetallePedido] ([IdPedido], [IdPlatillo], [Cantidad], [Subtotal])
VALUES (@IdPedido4, 40, 1, 9.50),  -- 1 Burger especial
       (@IdPedido4, 41, 1, 3.00);  -- 1 Papas fritas

-- Pedido 5: Usuario 1005
INSERT INTO [dbo].[Pedido] ([IdUsuario], [FechaHora], [CostoEnvio])
VALUES (1005, GETDATE(), 2.00);
SET @IdPedido5 = SCOPE_IDENTITY();

INSERT INTO [dbo].[DetallePedido] ([IdPedido], [IdPlatillo], [Cantidad], [Subtotal])
VALUES (@IdPedido5, 50, 1, 12.00), -- 1 Ensalada Master
       (@IdPedido5, 51, 1, 4.50),  -- 1 Jugo Natural
       (@IdPedido5, 52, 1, 2.50);  -- 1 Snack saludable
