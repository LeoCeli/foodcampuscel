-- =============================================
-- Author:      FoodCampus Team
-- Create date: 2026-03-06
-- Description: Script DDL para la creación de tablas base de FoodCampus
-- Target DB:   SQL Server (Somee)
-- =============================================

-- 1. Tabla Restaurante
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Restaurante]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Restaurante] (
        [Id]               INT IDENTITY(1,1) NOT NULL,
        [Nombre]           NVARCHAR(100)     NOT NULL,
        [Especialidad]     NVARCHAR(100)     NOT NULL,
        [HorarioApertura]  TIME              NOT NULL,
        [HorarioCierre]    TIME              NOT NULL,
        CONSTRAINT [PK_Restaurante] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END

-- 2. Tabla Pedido
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pedido]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Pedido] (
        [IdPedido]    INT IDENTITY(1,1) NOT NULL,
        [IdUsuario]   INT               NOT NULL, -- FK futura a tabla Usuarios
        [FechaHora]   DATETIME          NOT NULL CONSTRAINT [DF_Pedido_FechaHora] DEFAULT (GETDATE()),
        [CostoEnvio]  DECIMAL(18, 2)    NOT NULL,
        CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED ([IdPedido] ASC),
        CONSTRAINT [CK_Pedido_CostoEnvio] CHECK ([CostoEnvio] >= 0)
    );
END

-- 3. Tabla DetallePedido
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DetallePedido]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[DetallePedido] (
        [IdDetalle]   INT IDENTITY(1,1) NOT NULL,
        [IdPedido]    INT               NOT NULL,
        [IdPlatillo]  INT               NOT NULL, -- FK futura a tabla Platillos
        [Cantidad]    INT               NOT NULL,
        [Subtotal]    DECIMAL(18, 2)    NOT NULL,
        CONSTRAINT [PK_DetallePedido] PRIMARY KEY CLUSTERED ([IdDetalle] ASC),
        CONSTRAINT [FK_DetallePedido_Pedido] FOREIGN KEY ([IdPedido]) 
            REFERENCES [dbo].[Pedido] ([IdPedido]) ON DELETE CASCADE,
        CONSTRAINT [CK_DetallePedido_Cantidad] CHECK ([Cantidad] > 0),
        CONSTRAINT [CK_DetallePedido_Subtotal] CHECK ([Subtotal] >= 0)
    );
END
