# Prompt de Ingeniería – Proyecto FoodCampus

## 1. Rol

Actúa como un **Principal Software Engineer** especializado en:

- Clean Architecture
- SQL Server
- Diseño de bases de datos relacionales
- Buenas prácticas de modelado de datos
- Generación de datos de prueba (Dummy Data)

Tu tarea es generar **scripts SQL claros, seguros y bien estructurados**, listos para ejecutarse en SQL Server.

---

## 2. Contexto del Sistema

Estoy desarrollando un sistema llamado **FoodCampus**, un **sistema de delivery universitario**.

El sistema permitirá:

- Registrar restaurantes
- Consultar restaurantes disponibles
- Crear pedidos
- Registrar detalles de pedidos
- Consultar pedidos por usuario

La base de datos está implementada en **SQL Server** y alojada en **Somee**.

Las tablas ya fueron creadas mediante un **script DDL**.

Este prompt se utilizará para generar **datos de prueba (dummy data)** que permitan probar el sistema.

---

## 3. Tablas Existentes

Las siguientes tablas ya existen en la base de datos:

### Restaurante

Campos:

- Id
- Nombre
- Especialidad
- HorarioApertura
- HorarioCierre

### Pedido

Campos:

- IdPedido
- IdUsuario
- FechaHora
- CostoEnvio

### DetallePedido

Campos:

- IdDetalle
- IdPedido
- IdPlatillo
- Cantidad
- Subtotal

---

## 4. Tarea Específica

Generar un **script SQL DML** que inserte **datos de prueba (dummy data)** en las tablas existentes.

El script debe incluir:

- INSERTs para **Restaurante**
- INSERTs para **Pedido**
- INSERTs para **DetallePedido**

Los datos generados deben **respetar todas las constraints y reglas definidas en el script DDL**.

---

## 5. Reglas para los Datos Dummy

Los datos deben cumplir lo siguiente:

### Restaurantes

- Insertar al menos 5 restaurantes diferentes
- Nombres realistas
- Especialidades variadas (ejemplo: tacos, pizza, hamburguesas, sushi, comida mexicana)

### Pedidos

- Insertar al menos 5 pedidos
- Usuarios distintos
- Fechas y horas realistas

### DetallePedido

- Insertar entre **2 y 3 detalles por cada pedido**
- Relacionados correctamente con los pedidos existentes

---

## 6. Restricciones Técnicas

Los datos deben cumplir las siguientes reglas de negocio:

- `CostoEnvio >= 0`
- `Cantidad > 0`
- `Subtotal >= 0`

Además:

- Respetar **Primary Keys**
- Respetar **Foreign Keys**
- Mantener **integridad referencial**
- Los `IdPedido` utilizados en `DetallePedido` deben existir previamente en `Pedido`

---

## 7. Ubicación del Archivo

Guardar el script en:

/FoodCampus/db-scripts/dml


Nombre sugerido:

02-insert-dummy-data.sql


---

## 8. Requisitos de la Respuesta

La respuesta debe:

- Explicar brevemente las decisiones tomadas
- Incluir el **script SQL completo**
- Organizar el código por archivo
- Ser claro, limpio y listo para ejecutar en SQL Server