# EV09 – Interfaces y manejo de excepciones en C#

**Evidencia:** 220501097-04-AA1 – EV09 – Aplicación de la programación orientada a objetos en C# – Interfaces y manejo de excepciones

## Datos del aprendiz

- **Nombre:** Jerónimo Henao Sánchez
- **Programa:** Tecnólogo en Análisis y Desarrollo de Software (ADSO) – SENA
- **Ficha:** 3412768

## Objetivo

Practicar la programación orientada a objetos en C# usando interfaces para definir contratos y el manejo de excepciones (`try`, `catch`, `finally`, `throw`) para controlar errores del usuario sin que el programa se caiga.

## Estructura

```
EV09-Interfaces-Excepciones-CSharp/
├── RetoInterfaces/
│   ├── RetoInterfaces.csproj
│   ├── IMediaPlayer.cs
│   ├── MusicPlayer.cs
│   └── Program.cs
├── RetoExcepciones/
│   ├── RetoExcepciones.csproj
│   ├── EdadInvalidaException.cs
│   └── Program.cs
├── .gitignore
└── README.md
```

## Descripción de los retos

### Reto 1 – Interfaces

La interfaz `IMediaPlayer` define cuatro métodos: `Play()`, `Pause()`, `Stop()` y `GetCurrentTrack()`. La clase `MusicPlayer` la implementa completa, guarda la pista en el campo privado `current_track` y tiene el método extra `LoadTrack(string track_name)` para cargar canciones. Todos los mensajes salen en español por consola.

### Reto 2 – Excepciones

Se pide la edad por consola y se convierte a `int`. La edad debe estar entre 0 y 120 (incluidos los dos). Si no cumple, se lanza con `throw` la excepción personalizada `EdadInvalidaException`, que hereda de `Exception`. Se capturan con varios `catch`:

- `FormatException`: cuando el texto no es un número (por ejemplo `hola`).
- `OverflowException`: cuando el número no cabe en un `int`.
- `EdadInvalidaException` con filtro `when (ex.Edad < 0)`: edades negativas.
- `EdadInvalidaException`: las demás edades fuera de rango.

El bloque `finally` siempre muestra que el proceso terminó.

## Conceptos aplicados

- Interfaces e implementación de interfaces
- Encapsulamiento (campos privados)
- Excepciones personalizadas
- `try`, `catch` múltiple y `finally`
- `throw`
- Filtros de excepciones con `when`
- Diferencia entre `FormatException` y `OverflowException`

## Cómo compilar y ejecutar

Desde PowerShell, dentro de la carpeta del repositorio:

```powershell
cd C:\EV09-Interfaces-Excepciones-CSharp

# Reto 1
dotnet build RetoInterfaces
dotnet run --project RetoInterfaces

# Reto 2
dotnet build RetoExcepciones
dotnet run --project RetoExcepciones
```

## Casos de prueba y resultados

Los dos proyectos compilaron con **0 advertencias y 0 errores** usando el SDK de .NET 10 (10.0.115).

### Reto 1 – Reproductor

Salida real del programa:

```
=== Reto de interfaces: reproductor de música ===

1. Intentar reproducir sin cargar nada:
No hay ninguna pista cargada. Usa LoadTrack primero.

2. Primera pista:
Pista cargada: Cumbia Paisa
Reproduciendo: Cumbia Paisa
Pausado: Cumbia Paisa
Pista actual: Cumbia Paisa
Reanudando: Cumbia Paisa
Detenido: Cumbia Paisa

3. Segunda pista:
Pista cargada: Salsa Suave
Reproduciendo: Salsa Suave
Pista actual: Salsa Suave
Detenido: Salsa Suave

Fin de la demostración.
```

| Verificación | Resultado |
|---|---|
| Carga de una pista | OK (`Pista cargada: Cumbia Paisa`) |
| Reproducción | OK |
| Pausa | OK |
| Consulta de pista actual | OK |
| Detención | OK |
| Carga de una segunda pista | OK (`Salsa Suave`) |

### Reto 2 – Excepciones

| Entrada | Resultado obtenido | ¿Se ejecutó `finally`? |
|---|---|---|
| `18` | Edad válida: 18 años. | Sí |
| `hola` | Error: debes escribir un número entero, no letras ni símbolos. | Sí |
| `-1` | Error: la edad no puede ser negativa. La edad -1 no es válida. Debe estar entre 0 y 120 años. | Sí |
| `121` | Error: La edad 121 no es válida. Debe estar entre 0 y 120 años. | Sí |
| `0` | Edad válida: 0 años. | Sí |
| `120` | Edad válida: 120 años. | Sí |
| `99999999999` | Error: el número es demasiado grande para ser una edad. | Sí |
| `2147483648` | Error: el número es demasiado grande para ser una edad. | Sí |
| (vacío, solo Enter) | Error: debes escribir un número entero, no letras ni símbolos. | Sí |

En todos los casos apareció al final `Proceso de validación finalizado.`
