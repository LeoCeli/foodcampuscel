# Corrección de Error de Conversión de Hora - FoodCampus

## Rol

Actúa como un *Senior Software Engineer especializado en .NET 8+, C# y SQL Server, con experiencia en **Clean Architecture, DDD y aplicaciones de consola*.

Debes realizar *correcciones mínimas y seguras*, sin modificar la arquitectura del sistema ni romper funcionalidades existentes.

---

# Problema Detectado

Al registrar un restaurante desde la consola aparece el siguiente error:

Conversion failed when converting date and/or time from character string

Esto ocurre al ingresar horarios como:

Horario Apertura: 10:30  
Horario Cierre: 12:40

El problema se debe a que el sistema está enviando *strings al SQL Server* en lugar de convertirlos correctamente a *TimeSpan* antes de enviarlos como parámetros.

---

# Objetivo

Corregir la conversión de horario para que:

- La consola reciba texto en formato HH:mm
- El texto se convierta a TimeSpan
- El repositorio envíe correctamente el parámetro al SQL Server
- No se modifique ninguna otra funcionalidad del sistema

---

# Restricciones Importantes

NO debes:

- Cambiar la arquitectura del proyecto
- Modificar interfaces existentes
- Cambiar nombres de clases o métodos
- Alterar otros casos de uso
- Cambiar la estructura de la base de datos

SOLO debes corregir la conversión del horario.

---

# Implementación Correcta

Cuando la consola solicite el horario:

```csharp
Console.Write("Horario Apertura (HH:mm): ");
var aperturaInput = Console.ReadLine();

Console.Write("Horario Cierre (HH:mm): ");
var cierreInput = Console.ReadLine();

TimeSpan horarioApertura = TimeSpan.Parse(aperturaInput);
TimeSpan horarioCierre = TimeSpan.Parse(cierreInput);
El repositorio debe enviar los parámetros así:
C#
Copiar código
command.Parameters.AddWithValue("@HorarioApertura", horarioApertura);
command.Parameters.AddWithValue("@HorarioCierre", horarioCierre);
Validación adicional recomendada
Si el formato es incorrecto, mostrar un mensaje claro al usuario:
C#
Copiar código
if (!TimeSpan.TryParse(aperturaInput, out var horarioApertura))
{
    Console.WriteLine("Formato de hora inválido. Use HH:mm");
    return;
}
Resultado esperado
El sistema debe permitir registrar restaurantes con horarios como:
10:30
12:40
sin generar errores de conversión en SQL Server.
Entrega esperada
Mostrar únicamente los fragmentos de código modificados
Explicar brevemente el cambio realizado
Garantizar que no afecta otras partes del sistema