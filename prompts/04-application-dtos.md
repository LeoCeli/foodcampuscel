# Prompt de Ingeniería – Proyecto FoodCampus

## 1. Rol

Actúa como un **Principal Software Engineer** especializado en:

- Clean Architecture
- .NET
- C#
- Diseño de DTOs
- Separación de capas
- Principios SOLID

Tu tarea es generar **DTOs claros, simples y adecuados para la capa Application**, que se usen para **transferir datos entre capas sin exponer directamente las entidades del dominio**.

---

## 2. Contexto del Sistema

Estoy desarrollando un sistema llamado **FoodCampus**, un **sistema de delivery universitario**.

El sistema permitirá:

- Registrar restaurantes
- Consultar restaurantes disponibles
- Crear pedidos
- Registrar detalles de pedidos
- Consultar pedidos por usuario

La aplicación es una **aplicación de consola en .NET** y sigue **Clean Architecture**.

---

## 3. Arquitectura

Los DTOs pertenecen a la capa:


/src/FoodCampus.Application


Dentro de la carpeta:


/DTOs


Reglas importantes:

- No deben contener lógica de negocio
- No deben depender de infraestructura
- Solo deben **transportar datos** entre capas

---

## 4. Objetivo

Generar **DTOs que representen los datos necesarios para los casos de uso del sistema**.

Los DTOs deben ser usados para:

- Crear registros
- Consultar información
- Transferir datos entre capas

---

## 5. DTOs Necesarios

Genera DTOs para las siguientes entidades:

### Restaurante

DTOs requeridos:

- `RestauranteDto`
- `CrearRestauranteDto`

Campos:

- Id
- Nombre
- Especialidad
- HorarioApertura
- HorarioCierre

### Pedido

DTOs requeridos:

- `PedidoDto`
- `CrearPedidoDto`

Campos:

- IdPedido
- IdUsuario
- FechaHora
- CostoEnvio

### DetallePedido

DTOs requeridos:

- `DetallePedidoDto`
- `CrearDetallePedidoDto`

Campos:

- IdDetalle
- IdPedido
- IdPlatillo
- Cantidad
- Subtotal

---

## 6. Reglas de Implementación

Los DTOs deben:

- Ser **clases o records simples**
- Contener solo **propiedades públicas**
- No incluir lógica de negocio
- Usar **tipos de datos adecuados**
- Seguir **convenciones de C#** (PascalCase para propiedades)

---

## 7. Ubicación de Archivos

Los archivos deben generarse en:


/src/FoodCampus.Application/DTOs


Archivos esperados:

- RestauranteDto.cs
- CrearRestauranteDto.cs
- PedidoDto.cs
- CrearPedidoDto.cs
- DetallePedidoDto.cs
- CrearDetallePedidoDto.cs

---

## 8. Requisitos de la Respuesta

La respuesta debe:

- Explicar brevemente el propósito de los DTOs
- Mostrar cada archivo por separado
- Incluir **código C# completo**
- Seguir buenas prácticas de **Clean Architecture**
- Estar listo para compilar en .NET