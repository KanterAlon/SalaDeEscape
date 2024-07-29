using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    // Action Methods

    // 1. Index: Retorna la View Index con la presentación del juego.
    public IActionResult Index()
    {
        return View();
    }

    // 2. Tutorial: Retorna la View Tutorial con la explicación del juego.
    public IActionResult Tutorial()
    {
        return View();
    }


    // 3. Comenzar → Devuelve la view de la próxima Habitación a resolver (Según lo que indique EstadoJuego)
  public IActionResult Comenzar()
    {
        Escape.ReiniciarJuego(); // Reiniciar el juego antes de comenzar
        int estadoJuego = Escape.GetEstadoJuego();
        return RedirectToAction("Habitacion", new { sala = estadoJuego });
    }

    
    // 4. Creditos: Retorna la View Creditos con lis credutis del juego.
        public IActionResult Creditos()
    {
        return View();
    }

    // 5. Habitacion(int sala, string clave) → Verifica que la sala que se está respondiendo coincida con EstadoJuego.
    [HttpPost]
    public IActionResult Habitacion(int sala, string clave)
    {
        int estadoJuego = Escape.GetEstadoJuego();

        // Verifica si está resolviendo la sala correcta
        if (sala != estadoJuego)
        {
            return RedirectToAction("Habitacion", new { sala = estadoJuego });
        }

        // Verifica la clave
        bool esCorrecta = Escape.ResolverSala(sala, clave);
        if (esCorrecta)
        {
            // Si es la última sala, ir a la vista Victoria
            if (Escape.EsUltimaSala(sala))
            {
                return View("Victoria");
            }
            else
            {
                // Ir a la siguiente habitación
                return RedirectToAction("Habitacion", new { sala = sala + 1 });
            }
        }
        else
        {
            // Llena el ViewBag.Error y vuelve a la misma vista
            ViewBag.Error = "La respuesta ingresada es incorrecta.";
            return View($"Habitacion{sala}");
        }
    }

    // Manejo de solicitudes GET para la vista de la habitación
    public IActionResult Habitacion(int sala)
    {
        return View($"Habitacion{sala}");
    }
       // Acción para manejar el tiempo agotado
    public IActionResult Tiempo()
    {
        return View();
    }

    // Acción para agregar 30 segundos más
    [HttpPost]
    public IActionResult AgregarTiempo()
    {
        // Lógica para agregar 30 segundos más
        // Por simplicidad, simplemente redirigimos a la última habitación
        int estadoJuego = Escape.GetEstadoJuego();
        return RedirectToAction("Habitacion", new { sala = estadoJuego });
    }
}
