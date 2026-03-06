# Prompt de Ingeniería – Proyecto FoodCampus

## 1. Rol

Actúa como un **Principal Software Engineer** especializado en:

- Clean Architecture
- .NET
- C#
- Diseño de Use Cases
- Principios SOLID

Tu tarea será generar los **casos de uso (Use Cases)** de la capa **Application**, asegurando lógica de aplicación limpia y desacoplada de la infraestructura.

---

## 2. Contexto del Sistema

Estoy desarrollando un sistema llamado **FoodCampus**, un **sistema de delivery universitario**.

El sistema permite:

- Registrar restaurantes
- Consultar restaurantes
- Crear pedidos
- Registrar detalles de pedidos
- Consultar pedidos por usuario

El sistema sigue **Clean Architecture**, separando claramente dominio, aplicación, infraestructura y presentación.

Las entidades principales del sistema son:

- Restaurante
- Pedido
- DetallePedido

---

## 3. Arquitectura

Los casos de uso pertenecen a la capa **Application**.

Estructura esperada:


FoodCampus.Application
│
└── UseCases
├── Restaurantes
│ ├── CreateRestauranteUseCase.cs
│ ├── GetRestaurantesUseCase.cs
│ └── GetRestauranteByIdUseCase.cs
│
├── Pedidos
│ ├── CreatePedidoUseCase.cs
│ ├── GetPedidoByIdUseCase.cs
│ └── GetPedidosByUsuarioUseCase.cs
│
└── DetallesPedido
├── AddDetallePedidoUseCase.cs
└── GetDetallesPedidoUseCase.cs


Los **UseCases** deben depender únicamente de:

- DTOs
- Repository Interfaces

No deben depender de Infrastructure, SQL Server ni ORM específico.

---

## 4. Objetivo

Definir los **casos de uso de la capa Application**, que contienen la lógica de aplicación y utilizan las **Repository Interfaces**.

Los casos de uso deben:

- Usar las **interfaces de repositorio** para comunicarse con la base de datos
- Recibir **DTOs**
- Devolver **DTOs o resultados**
- No conocer **infraestructuras específicas**
- Tener una **responsabilidad clara**

> Nota: Las implementaciones de repositorios se inyectarán mediante DI y ya contendrán la cadena de conexión.

---

## 5. Casos de Uso Requeridos

- **CreateRestauranteUseCase** → Crear restaurante
- **GetRestaurantesUseCase** → Obtener todos los restaurantes
- **GetRestauranteByIdUseCase** → Obtener restaurante por id
- **CreatePedidoUseCase** → Crear pedido
- **GetPedidoByIdUseCase** → Obtener pedido por id
- **GetPedidosByUsuarioUseCase** → Obtener pedidos por usuario
- **AddDetallePedidoUseCase** → Agregar detalle de pedido
- **GetDetallesPedidoUseCase** → Consultar los detalles de un pedido

---

## 6. Métodos Esperados

Ejemplo conceptual:

### CreatePedidoUseCase

**Input:** `CreatePedidoDto`

**Proceso:**

1. Validar datos
2. Crear entidad `Pedido`
3. Usar `IPedidoRepository`
4. Guardar en base de datos

---

## 7. Reglas

Los UseCases deben:

- Estar en **Application**
- Usar **Repository Interfaces**
- No conocer **SQL Server** ni **Entity Framework**
- Seguir **Single Responsibility Principle (SRP)**
- Ser **fáciles de testear**
- Recibir DTOs de entrada y devolver DTOs o resultados
- No contener lógica de base de datos

---

## 8. Ubicación de Archivos

Los archivos deben ubicarse en:


/src/FoodCampus.Application/UseCases


---

## 9. Requisitos de la Respuesta

La respuesta debe:

### Explicación Inicial

- Explicar qué es un **Use Case**
- Su papel dentro de **Clean Architecture**
- Cómo se relaciona con las **Repository Interfaces**

### Estructura del Código

- Generar los **archivos de casos de uso completos en C#**
- Cada archivo debe incluir:
  - `namespace FoodCampus.Application.UseCases`
  - Constructor con **inyección de dependencias**
  - Uso de **interfaces de repositorio**
  - Métodos públicos que ejecuten el caso de uso
  - Código claro y legible

### Formato de Respuesta

- Mostrar **cada archivo por separado** usando bloques de código.
- Ejemplo de presentación:


Archivo: CreateRestauranteUseCase.cs

// código aquí

Archivo: GetRestaurantesUseCase.cs

// código aquí

---

## 10. Buenas Prácticas

- Seguir **Clean Architecture**
- Usar **inyección de dependencias**
- Usar **interfaces de repositorio**
- No depender de **Infrastructure**
- No usar SQL directo ni ORM específico
- Cumplir **Single Responsibility Principle**
- Código claro, organizado y mantenible
- Fácil de testear