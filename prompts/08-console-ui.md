# Prompt de Ingeniería – Proyecto FoodCampus

## 1. Rol

Actúa como un **Senior Software Engineer** especializado en:

- C# y .NET 8/9
- Clean Architecture
- Diseño de interfaces de línea de comandos (CLI)
- Inyección de dependencias (`Microsoft.Extensions.DependencyInjection`)
- Manejo de excepciones y validación de entradas

Tu tarea es generar el código de la capa de presentación (Console UI) del sistema **FoodCampus**, respetando la arquitectura y las buenas prácticas de Clean Architecture.

---

## 2. Contexto del Sistema

**FoodCampus** es un sistema de delivery universitario.  
Actualmente existen las capas:

- `Domain`: Entidades y reglas de negocio  
- `Application`: DTOs, Interfaces y Use Cases  
- `Infrastructure`: Implementaciones de repositorios  

Tu objetivo es construir la capa **FoodCampus.Console** como punto de entrada, encargada de interactuar con los Use Cases sin contener lógica de negocio ni acceder directamente a la base de datos.

---

## 3. Arquitectura

**Capa de Presentación (Console)**

Responsabilidades:

- Configurar la Inyección de Dependencias (DI)  
- Mostrar un menú interactivo  
- Capturar y validar entrada del usuario  
- Llamar únicamente a los Use Cases de Application  
- Mostrar resultados o errores de forma amigable  

Restricciones:

- **NO** contener lógica de negocio  
- **NO** acceder a SQL Server o Entity Framework directamente  
- **NO** depender de Infrastructure más allá de la configuración de servicios en `Program.cs`

---

## 4. Objetivo

Crear una interfaz de consola robusta, interactiva y amigable que permita al usuario ejecutar las operaciones principales del sistema.

---

## 5. Funcionalidades del Menú

El menú debe ser un bucle (`while`) con las siguientes opciones:


===== FOODCAMPUS - DELIVERY UNIVERSITARIO =====

Registrar restaurante

Ver restaurantes

Crear pedido

Consultar pedidos

Salir
===============================================
Seleccione una opción:


---

## 6. Requisitos Técnicos y Buenas Prácticas

### Inyección de Dependencias (DI)

- Usar `Microsoft.Extensions.DependencyInjection`  
- Configurar `ServiceCollection` en `Program.cs`  
- Registrar repositorios concretos con la cadena de conexión SQL Server de Somee  
- Registrar Use Cases y la clase del menú (`MenuService` o `AppUI`)  
- Resolver el menú y arrancar la aplicación

### Manejo de Errores y Validaciones

- Validar siempre la entrada del usuario (`int.TryParse`, `decimal.TryParse`, `DateTime.TryParse`)  
- Mostrar mensajes de error claros y amigables en color rojo  
- Volver a solicitar datos inválidos sin cerrar la aplicación  
- Envolver llamadas a Use Cases en bloques `try-catch`  

### Experiencia de Usuario (UX en Consola)

- Limpiar la consola con `Console.Clear()` cuando sea apropiado  
- Pausar después de mostrar resultados:
  ```csharp
  Console.WriteLine("Presione cualquier tecla para continuar...");
  Console.ReadKey();

Usar colores (Console.ForegroundColor) para diferenciar encabezados, errores y mensajes de éxito

7. Archivos Esperados

Generar los siguientes archivos en /src/FoodCampus.Console:

Program.cs – Configuración de DI y arranque de la aplicación

MenuService.cs – Bucle del menú, lectura de datos y orquestación de Use Cases

8. Formato de la Respuesta
Explicación Inicial

Antes del código, explica:

Cómo se configuró la Inyección de Dependencias en una aplicación de consola

Cómo se previenen cierres inesperados al leer datos del usuario

Estructura del Código

Muestra cada archivo por separado usando bloques de código C#.

Ejemplo:

Archivo: Program.cs

// código aquí

Archivo: MenuService.cs

// código aquí
9. Buenas Prácticas Aplicadas

Separación de responsabilidades: UI vs Use Cases

Uso de inyección de dependencias para desacoplar componentes

Manejo seguro de excepciones y validación de inputs

Limpieza y claridad en la presentación de la información

Código listo para compilar en .NET y fácil de mantener