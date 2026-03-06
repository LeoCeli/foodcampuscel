# Prompt de Ingeniería – Proyecto FoodCampus

## 1. Rol

Actúa como un **Senior Software Engineer** especializado en:

- .NET 8/9 y C#
- Clean Architecture
- Diseño de aplicaciones de consola desacopladas
- Inyección de dependencias con `Microsoft.Extensions.DependencyInjection`
- Patrones Use Case y comunicación entre capas
- Principios SOLID y Clean Code

Tu objetivo es generar la capa **FoodCampus.Console**, que servirá como punto de entrada del sistema y orquestará la interacción con los Use Cases sin incluir lógica de negocio.

---

## 2. Contexto del Sistema

**FoodCampus** es un sistema de delivery universitario. La solución ya incluye:

- `FoodCampus.Domain`: Entidades y reglas de negocio
- `FoodCampus.Application`: DTOs, Interfaces y Use Cases
- `FoodCampus.Infrastructure`: Implementaciones de persistencia
- `FoodCampus.Console`: Interfaz de usuario y configuración de DI (pendiente de desarrollar)

La capa Console debe **orquestar la entrada/salida** y delegar toda la lógica a los Use Cases de Application.

---

## 3. Especificaciones Técnicas de la Capa Console

- **Responsabilidades:**  
  - Mostrar menús interactivos
  - Leer inputs del usuario (`Console.ReadLine`)
  - Validar formatos básicos
  - Presentar resultados en consola

- **Restricciones:**  
  - PROHIBIDO incluir lógica de negocio
  - PROHIBIDO acceso directo a Base de Datos o Entity Framework
  - Solo debe interactuar con los Use Cases de **Application**

---

## 4. Requerimientos de Funcionalidad

El menú interactivo debe permitir al usuario:

1. **Ver restaurantes:** Listado general  
2. **Crear restaurante:** Ingresar Nombre, Especialidad, Horario Apertura/Cierre  
3. **Crear pedido:** Registro inicial de orden  
4. **Agregar detalle a pedido:** Vincular items a un pedido existente  
5. **Ver pedidos por usuario:** Filtrado por ID de usuario  
6. **Ver detalles de pedido:** Información de una orden específica  
0. **Salir**

> Nota: Cada repositorio implementa su interfaz correspondiente y gestiona la persistencia mediante SQL Server (Dapper o EF Core).

---

## 5. Inyección de Dependencias

En `Program.cs` se debe configurar `ServiceCollection` para registrar:

- **Repositorios:** `IRestauranteRepository` -> `RestauranteRepository`, etc.  
- **Use Cases:** Todas las clases de Application necesarias  
- **Servicios de UI:** `MenuService`

---

## 6. Entregables de Código

Generar los archivos **completos** con sus namespaces y comentarios, ubicados en `/src/FoodCampus.Console`:

### A. Program.cs

- Configuración del Host / ServiceCollection  
- Registro de dependencias (Repositorios, Use Cases, MenuService)  
- Llamada inicial a `MenuService` para iniciar la aplicación

### B. MenuService.cs

- Implementación del bucle principal del menú  
- Métodos privados para manejar cada opción  
- Inyección de Use Cases vía constructor:  
  - `CreateRestauranteUseCase`  
  - `GetRestaurantesUseCase`  
  - `CreatePedidoUseCase`  
  - `AddDetallePedidoUseCase`  
  - `GetPedidosPorUsuarioUseCase`  
  - `GetDetallesPedidoUseCase`  

---

## 7. Formato de Respuesta

1. **Explicación Conceptual:**  
   - Posición de la Console UI dentro de Clean Architecture  
   - Cómo interactúa con Application sin depender de Infrastructure

2. **Bloques de Código:**  
   - Archivos separados con namespaces, comentarios y buenas prácticas

3. **Buenas Prácticas Aplicadas:**  
   - Uso de inyección de dependencias  
   - Patrón de orquestador (MenuService)  
   - Manejo básico de excepciones para que la consola no se cierre inesperadamente  
   - Validación de entradas de usuario  

---

## 8. Consideraciones Adicionales

- Usar tipos de datos apropiados para inputs (string, int, decimal, DateTime)  
- Validar entradas mínimas (no permitir nulos o formatos incorrectos)  
- Aplicar SRP: MenuService solo maneja UI, toda lógica va a Use Cases  
- Código debe ser claro, legible y listo para compilar en .NET
