# Prompt de Ingeniería – Proyecto FoodCampus

## 1. Rol

Actúa como un **Principal Software Engineer** especializado en:

- Clean Architecture
- .NET
- C# 14
- Domain Driven Design (DDD)
- Diseño de entidades de dominio
- Principios SOLID

Tu tarea es generar **entidades de dominio limpias, bien encapsuladas y alineadas con buenas prácticas de diseño**.

---

## 2. Contexto del Sistema

Estoy desarrollando un sistema llamado **FoodCampus**, un **sistema de delivery universitario**.

El sistema permitirá:

- Registrar restaurantes
- Consultar restaurantes disponibles
- Crear pedidos
- Registrar detalles de pedidos
- Consultar pedidos por usuario

La aplicación será una **aplicación de consola en .NET**.

El proyecto sigue **Clean Architecture**.

---

## 3. Arquitectura

Las entidades deben pertenecer a la capa:


/src/FoodCampus.Domain


Las entidades representan el **modelo de negocio central** del sistema.

Reglas importantes:

- No deben depender de otras capas
- No deben contener lógica de infraestructura
- No deben contener acceso a base de datos
- Solo deben contener lógica de dominio

---

## 4. Modelo de Dominio

Genera las siguientes entidades:

### Restaurante

Propiedades:

- Id
- Nombre
- Especialidad
- HorarioApertura
- HorarioCierre

### Pedido

Propiedades:

- IdPedido
- IdUsuario
- FechaHora
- CostoEnvio

### DetallePedido

Propiedades:

- IdDetalle
- IdPedido
- IdPlatillo
- Cantidad
- Subtotal

---

## 5. Reglas de Negocio

Las entidades deben validar las siguientes reglas dentro del dominio:

### Pedido

- `CostoEnvio >= 0`

### DetallePedido

- `Cantidad > 0`
- `Subtotal >= 0`

---

## 6. Reglas de Implementación

Las entidades deben:

- Usar **propiedades encapsuladas**
- Usar **constructores para garantizar estado válido**
- Evitar setters públicos innecesarios
- Incluir validaciones en el dominio
- Seguir principios **SOLID**

Opcionalmente pueden incluir:

- Métodos de dominio
- Validaciones en constructor

---

## 7. Ubicación de Archivos

Las entidades deben generarse en:


/src/FoodCampus.Domain/Entities


Archivos esperados:

- Restaurante.cs
- Pedido.cs
- DetallePedido.cs

---

## 8. Requisitos de la Respuesta

La respuesta debe:

- Explicar brevemente las decisiones de diseño
- Mostrar cada archivo por separado
- Incluir código C# completo
- Seguir buenas prácticas de Clean Architecture
- Estar listo para compilar en .NET