Crear estructura de solución FoodCampus usando .NET CLI
Rol

Actúa como un Principal Software Engineer especializado en Clean Architecture, .NET y arquitectura de software en C#.

Tu tarea es generar una estructura profesional de solución utilizando .NET CLI, respetando los principios de Clean Architecture, de manera que sea lista para ejecutar en una terminal.

Contexto

Estamos desarrollando un sistema llamado FoodCampus, un sistema de delivery universitario que permitirá:

Registrar restaurantes

Consultar restaurantes disponibles

Crear pedidos

Registrar detalles de pedidos

Consultar pedidos por usuario

La aplicación será una aplicación de consola en .NET (C#).

Actualmente no existe ningún proyecto ni solución, por lo que todo debe crearse desde cero utilizando comandos de .NET CLI.

Objetivo

Generar todos los comandos necesarios para crear la solución completa del proyecto, siguiendo Clean Architecture y dividiendo la solución en los siguientes proyectos:

FoodCampus.Domain

FoodCampus.Application

FoodCampus.Infrastructure

FoodCampus.Console

Arquitectura y reglas de dependencia
Domain

Contiene:

Entidades

Reglas de negocio

Value Objects

Restricciones:

No depende de ningún proyecto.

Application

Contiene:

Casos de uso

DTOs

Interfaces de repositorios

Mappers

Restricciones:

Solo depende de Domain.

Infrastructure

Contiene:

Persistencia de datos

Implementaciones de repositorios

Configuración de base de datos

Restricciones:

Depende de Application.

Console (Presentación)

Contiene:

Program.cs

Menú interactivo

Configuración de dependencias

Restricciones:

Solo puede depender de Application.

La capa Console no debe depender directamente de Infrastructure.

Requisitos de la respuesta

La respuesta debe incluir:

1. Comandos completos de .NET CLI

Genera los comandos necesarios para:

Crear la solución

Crear los proyectos

Crear la carpeta src y mover los proyectos dentro

Agregar los proyectos a la solución

Agregar referencias entre proyectos

Ejemplo de sintaxis correcta:

dotnet new sln -n FoodCampus
dotnet new classlib -n FoodCampus.Domain
dotnet new classlib -n FoodCampus.Application
dotnet new classlib -n FoodCampus.Infrastructure
dotnet new console -n FoodCampus.Console
dotnet sln add src/FoodCampus.Domain/FoodCampus.Domain.csproj
dotnet sln add src/FoodCampus.Application/FoodCampus.Application.csproj
dotnet sln add src/FoodCampus.Infrastructure/FoodCampus.Infrastructure.csproj
dotnet sln add src/FoodCampus.Console/FoodCampus.Console.csproj
dotnet add src/FoodCampus.Application/FoodCampus.Application.csproj reference src/FoodCampus.Domain/FoodCampus.Domain.csproj
dotnet add src/FoodCampus.Infrastructure/FoodCampus.Infrastructure.csproj reference src/FoodCampus.Application/FoodCampus.Application.csproj
dotnet add src/FoodCampus.Console/FoodCampus.Console.csproj reference src/FoodCampus.Application/FoodCampus.Application.csproj

Asegúrate de usar rutas relativas correctas si los proyectos se mueven dentro de src.

2. Estructura final de carpetas

Muestra el árbol de carpetas completo:

FoodCampus
│
├── src
│   ├── FoodCampus.Domain
│   ├── FoodCampus.Application
│   ├── FoodCampus.Infrastructure
│   └── FoodCampus.Console
│
├── db-scripts
│   ├── ddl
│   └── dml
│
└── prompts
3. Explicación breve de cada capa

Domain: contiene toda la lógica de negocio y reglas de dominio. Es independiente de cualquier otra capa.

Application: orquesta los casos de uso, define interfaces y DTOs, depende únicamente de Domain.

Infrastructure: implementa la persistencia, mapea entidades y maneja la configuración de base de datos; depende de Application.

Console: capa de presentación, maneja menús y DI; depende solo de Application para acceder a los casos de uso.

Ventaja: esta estructura sigue Clean Architecture, permitiendo alta mantenibilidad, escalabilidad y testabilidad, ya que las dependencias siempre apuntan hacia adentro y cada capa tiene responsabilidades claras.

4. Buenas prácticas recomendadas

Evitar que la capa Console dependa directamente de Infrastructure.

Usar DI (Dependency Injection) para registrar repositorios y cadenas de conexión en Program.cs.

Mantener las clases pequeñas y enfocadas en una sola responsabilidad (SOLID).

Separar scripts de base de datos (db-scripts/ddl y db-scripts/dml) para facilitar mantenimiento.

Mantener prompts o documentación en una carpeta dedicada (prompts/) para referencia futura.