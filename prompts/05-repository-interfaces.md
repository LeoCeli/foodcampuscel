# Prompt de Ingeniería – Proyecto FoodCampus

## 1. Rol

Actúa como un **Senior Software Architect experto en Patrones de Diseño y .NET**.

Tu objetivo es diseñar los **contratos de repositorio (interfaces)** para las entidades del sistema **FoodCampus**, asegurando una separación total entre la lógica de negocio y la persistencia de datos, siguiendo **Clean Architecture**.

Las interfaces deben definir **contratos claros de acceso a datos** sin incluir ninguna implementación.

---

## 2. Contexto del Sistema

FoodCampus es una **aplicación de consola en .NET** que sigue **Clean Architecture** para gestionar un sistema de **delivery universitario**.

El sistema permite:

- Registrar restaurantes
- Consultar restaurantes disponibles
- Crear pedidos
- Registrar detalles de pedidos
- Consultar pedidos por usuario

La persistencia de datos se realiza en **SQL Server**.

Las entidades principales del sistema son:

- Restaurante
- Pedido
- DetallePedido

---

## 3. Arquitectura

Las interfaces de repositorio deben pertenecer a la capa **Application**.

Estructura esperada:


src
├── FoodCampus.Domain
├── FoodCampus.Application
│ └── Interfaces
│ └── Repositories


Las interfaces **no deben depender de Infrastructure**.

---

## 4. Objetivo

Crear las **interfaces de repositorio** que usará la capa **Application** para comunicarse con la base de datos sin depender directamente de la capa de persistencia.

Estas interfaces funcionan como **contratos de acceso a datos** que posteriormente serán implementados en la capa **Infrastructure**.

> Nota: Las interfaces serán implementadas en **Infrastructure** usando SQL Server, y la capa **Application** solo las consumirá a través de **DI**.

---

## 5. Interfaces Necesarias

### IRestauranteRepository

Funciones esperadas:

- Guardar restaurante
- Obtener todos los restaurantes
- Obtener restaurante por id

### IPedidoRepository

Funciones esperadas:

- Crear pedido
- Obtener pedido por id
- Obtener pedidos por usuario

### IDetallePedidoRepository

Funciones esperadas:

- Agregar detalle de pedido
- Obtener detalles de un pedido

---

## 6. Reglas

Las interfaces deben:

- Ser **interfaces de C#**
- Estar ubicadas en la capa **Application**
- Usar **DTOs o entidades de dominio**
- **No tener implementación**
- Seguir principios **SOLID**

---

## 7. Archivos Esperados

Se deben generar los siguientes archivos:

- `IRestauranteRepository.cs`
- `IPedidoRepository.cs`
- `IDetallePedidoRepository.cs`

---

## 8. Ubicación de Archivos

Los archivos deben ubicarse en:


/src/FoodCampus.Application/Interfaces/Repositories


---

## 9. Requisitos de la Respuesta

La respuesta debe:

- Explicar brevemente el propósito de los repositorios
- Mostrar cada archivo por separado
- Incluir **código C# completo**
- Seguir buenas prácticas de **Clean Architecture**
- Estar listo para compilar en .NET