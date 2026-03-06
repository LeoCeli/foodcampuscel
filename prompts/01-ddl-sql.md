# Prompt de Ingeniería – Proyecto FoodCampus

## 1. Rol

Actúa como un **Principal Software Engineer** especializado en:

- Clean Architecture
- .NET (C# 14)
- SQL Server
- Diseño orientado al dominio (DDD)
- Buenas prácticas de arquitectura y separación de capas

Tu tarea es generar **código limpio, bien estructurado y listo para producción**, siguiendo los principios de DDD y Clean Architecture.

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

La base de datos será **SQL Server** y estará hospedada en **Somee**.

---

## 3. Arquitectura Obligatoria

El sistema debe seguir **Clean Architecture** y dividirse en las siguientes capas:

### Domain
Contiene:

- Entidades puras
- Reglas de negocio
- Sin dependencias externas

### Application
Contiene:

- Casos de uso
- DTOs
- Interfaces de repositorios

Restricción: solo puede depender de **Domain**.

### Infrastructure
Contiene:

- Implementaciones de repositorios
- Persistencia de datos
- Configuración de acceso a datos

Puede depender de **Application**.

### Console
Contiene:

- Menú interactivo
- Configuración de Inyección de Dependencias
- Interacción con el usuario

Restricción: solo puede interactuar con **Application**.

---

## 4. Restricciones Técnicas

- Usar **SQL Server**
- Seguir buenas prácticas de modelado relacional
- Definir **Primary Keys** y **Foreign Keys**
- Definir **constraints de validación**
- Usar tipos de datos adecuados (`nvarchar`, `datetime`, `decimal`)

### Restricciones de infraestructura

La base de datos está en **Somee**, por lo que:

- Evitar insertar demasiados registros
- Límite aproximado: **30 MB de datos**

**Cadena de conexión obligatoria:**

" workstation id=develope-utm-ommm-celis.mssql.somee.com;packet size=4096;user id=dibu_SQLLogin_1;pwd=tk4x9n97ej;data source=develope-utm-ommm-celis.mssql.somee.com;persist security info=False;initial catalog=develope-utm-ommm-celis;TrustServerCertificate=True "


---

## 5. Modelo de Datos

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
- CostoEnvio (`>= 0`)

### DetallePedido

Campos:

- IdDetalle
- IdPedido
- IdPlatillo
- Cantidad (`> 0`)
- Subtotal (`>= 0`)

Los scripts SQL deben ser compatibles con **SQL Server** y la cadena de conexión definida en Infrastructure.

---

## 6. Tarea Específica

Generar un **script SQL DDL** que cree las tablas:

- Restaurante
- Pedido
- DetallePedido

El script debe incluir:

- **Primary Keys**
- **Foreign Keys**
- **Constraints de validación** (`CHECK`)
- Tipos de datos adecuados (`nvarchar`, `datetime`, `decimal`)

Reglas de negocio mediante **CHECK constraints**:

- `CostoEnvio >= 0`
- `Cantidad > 0`
- `Subtotal >= 0`

---

## 7. Ubicación del archivo

Guardar el script en:

/FoodCampus/db-scripts/ddl


Nombre sugerido:

01-create-tables.sql


---

## 8. Requisitos de la Respuesta

La respuesta debe:

- Explicar brevemente las decisiones tomadas
- Incluir el **script SQL completo**
- Estar organizada por archivos
- Seguir **buenas prácticas de SQL Server**
- Ser clara y lista para implementación