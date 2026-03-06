# Prompt de Ingeniería – Proyecto FoodCampus (Platillos)

## 1. Rol

Actúa como un **Principal Software Engineer** especializado en:

- Clean Architecture  
- .NET 10 / C# 14  
- Domain Driven Design (DDD)  
- Diseño de entidades de dominio y DTOs  
- Principios SOLID  
- Patrones de repositorio y Use Cases  

Tu tarea es **agregar la funcionalidad de Platillos** sin afectar las funcionalidades ya existentes (Restaurantes, Pedidos, DetallesPedido).

---

## 2. Contexto del Sistema

Estoy desarrollando **FoodCampus**, un sistema de delivery universitario.  

Objetivo:

- Poder **consultar los platillos de cada restaurante**  
- **Registrar nuevos platillos** asociados a un restaurante  

Actualmente ya existen las capas:

- `/Domain`  
- `/Application`  
- `/Infrastructure`  
- `/Console`  

La implementación debe seguir **Clean Architecture**, usando **DTOs, Repository Interfaces y Use Cases**.

---

## 3. Arquitectura

### Domain

- Entidad: `Platillo`  
- Propiedades:
  - IdPlatillo
  - IdRestaurante (relación con Restaurante)
  - Nombre
  - Precio (decimal >= 0)
  - Descripción (opcional)
- La entidad **no debe tener lógica de infraestructura ni acceso a base de datos**.
- Validaciones:
  - Precio >= 0
  - Nombre no vacío  

### Application

- DTOs:
  - `PlatilloDto` (para consultas)
  - `CrearPlatilloDto` (para registrar)  
- Repository Interface: `IPlatilloRepository`
  - Métodos:
    - `Task CrearPlatillo(CrearPlatilloDto dto)`  
    - `Task<IEnumerable<PlatilloDto>> GetPlatillosPorRestaurante(int idRestaurante)`  

- Use Cases:
  - `CreatePlatilloUseCase`
  - `GetPlatillosPorRestauranteUseCase`  

- **Reglas**:
  - Los Use Cases solo dependen de **DTOs y Repositorios**.
  - No deben tener acceso a SQL Server ni a EF Core.
  - Deben ser inyectables vía DI.

### Infrastructure

- Implementar `PlatilloRepository` que cumpla con `IPlatilloRepository`.
- Usar SQL Server (cadena de conexión Somee) para operaciones CRUD.
- Implementar métodos `INSERT` y `SELECT` respetando Foreign Keys (IdRestaurante debe existir).

#### Script DDL para Platillo

```sql
CREATE TABLE Platillo
(
    IdPlatillo INT IDENTITY(1,1) PRIMARY KEY,
    IdRestaurante INT NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL CHECK (Precio >= 0),
    Descripcion NVARCHAR(255) NULL,
    CONSTRAINT FK_Platillo_Restaurante FOREIGN KEY (IdRestaurante)
        REFERENCES Restaurante(Id)
);
Script DML para datos de prueba
INSERT INTO Platillo (IdRestaurante, Nombre, Precio, Descripcion)
VALUES
(1, 'Hamburguesa Clásica', 80.00, 'Carne, queso y pan'),
(1, 'Pizza Margarita', 120.00, 'Tomate, mozzarella y albahaca'),
(2, 'Sushi Roll', 150.00, 'Salmón y aguacate');

Nota: Esto asegura que la tabla existe antes de que los Use Cases intenten hacer consultas o inserciones, evitando el error “Invalid object name 'Platillo'”.

Console

Actualizar MenuService para agregar un submenú de Platillos:

Ver platillos por restaurante

Registrar nuevo platillo

Inyectar los Use Cases de Platillo (CreatePlatilloUseCase y GetPlatillosPorRestauranteUseCase) en Program.cs usando DI.

Integrar el submenú en la opción principal del menú interactivo sin modificar el flujo existente.

4. Archivos Esperados

Domain:

/src/FoodCampus.Domain/Entities/Platillo.cs

Application:

/src/FoodCampus.Application/DTOs/PlatilloDto.cs

/src/FoodCampus.Application/DTOs/CrearPlatilloDto.cs

/src/FoodCampus.Application/Interfaces/Repositories/IPlatilloRepository.cs

/src/FoodCampus.Application/UseCases/Platillos/CreatePlatilloUseCase.cs

/src/FoodCampus.Application/UseCases/Platillos/GetPlatillosPorRestauranteUseCase.cs

Infrastructure:

/src/FoodCampus.Infrastructure/Repositories/PlatilloRepository.cs

/db-scripts/ddl/02-create-platillo-table.sql

/db-scripts/dml/02-insert-platillo-dummy-data.sql

Console:

/src/FoodCampus.Console/MenuService.cs (submenú de Platillos)

/Program.cs (registrar Use Cases de Platillo en DI)

5. Requisitos Técnicos

Seguir Clean Architecture y principios SOLID.

Mantener integridad referencial (IdRestaurante debe existir).

Validar campos en entidades y DTOs.

Los Use Cases deben ser fáciles de testear.

La consola debe manejar errores de forma amigable y no cerrar la aplicación.

6. Reglas de Generación

Mostrar cada archivo por separado usando bloques de código.

Incluir comentarios explicativos en cada archivo.

Código listo para compilar en .NET 10.

Explicar brevemente las decisiones de diseño al inicio de la respuesta.

Incluir DDL y DML de Platillo para asegurar que la tabla exista antes de ejecutar el menú.