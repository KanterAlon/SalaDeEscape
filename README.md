# Proyecto Sala de Escape

## Descripción
Bienvenidos al repositorio del proyecto de Sala de Escape desarrollado para la materia Taller de Programación 2 de la Escuela ORT sede Almagro. Este proyecto tiene como objetivo crear un juego interactivo de Sala de Escape utilizando ASP.NET Core MVC. Los jugadores deberán resolver acertijos para avanzar entre diferentes salas, siguiendo una narrativa interesante y un diseño visual atractivo.

## Objetivos
- Implementar formularios web para capturar y procesar entradas de usuarios.
- Familiarizarse con los IActionResult del Controller, el desarrollo de Vistas y la creación de Models en ASP.NET Core MVC.
- Desarrollar un juego con una historia cohesiva y visualmente atractiva.

## Estructura del Proyecto

### Models
#### Clase Estática Escape.cs
- **Atributos:**
  - static string[] incognitasSalas: Soluciones de cada sala.
  - static int estadoJuego: Número de sala resuelta (inicialmente 1).
- **Métodos:**
  - private static void InicializarJuego(): Inicializa el juego con las soluciones correctas.
  - public static int GetEstadoJuego(): Retorna el estado del juego.
  - public static bool ResolverSala(int Sala, string Incognita): Valida la resolución de una sala.

### Controllers
#### HomeController
- **Acciones:**
  - Index: Muestra la vista de presentación del juego.
  - Tutorial: Muestra la vista con las instrucciones del juego.
  - Comenzar: Muestra la vista de la próxima habitación a resolver.
  - Habitacion: Verifica y procesa las respuestas de las habitaciones.

### Views
- **index.cshtml**: Contiene la presentación del juego con nombre, logo, imágenes descriptivas y enlaces a otras vistas.
- **tutorial.cshtml**: Explicación del juego con texto e imágenes.
- **creditos.cshtml**: Información del equipo de desarrollo.
- **Vistas de habitaciones**: Cada vista contiene un título, descripción, elementos multimedia y formularios para resolver las salas.
- **victoria.cshtml**: Vista de finalización del juego.

## Instrucciones de Instalación
1. Clonar el repositorio: `git clone https://github.com/usuario/proyecto-sala-de-escape.git`
2. Navegar al directorio del proyecto: `cd proyecto-sala-de-escape`
3. Restaurar las dependencias: `dotnet restore`
4. Ejecutar el proyecto: `dotnet run`
