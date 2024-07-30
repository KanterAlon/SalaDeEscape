using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    // Action Methods

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Tutorial()
    {
        return View();
    }

    public IActionResult Comenzar()
{
    Escape.ReiniciarJuego(); // Reiniciar el juego antes de comenzar
    int estadoJuego = Escape.GetEstadoJuego();

    // Usar TempData para indicar que se debe reiniciar el temporizador
    TempData["ResetTime"] = true;

    return RedirectToAction("Habitacion", new { sala = estadoJuego });
}


    public IActionResult Creditos()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Habitacion(int sala, string clave)
    {
        int estadoJuego = Escape.GetEstadoJuego();
        ViewBag.ResetTime = TempData["ResetTime"];

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
                TempData["ResetTime"] = true;
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

    public IActionResult Habitacion(int sala)
    {
        ViewBag.ResetTime = TempData["ResetTime"];
        return View($"Habitacion{sala}");
    }

    public IActionResult Tiempo()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AgregarTiempo()
    {
        var lastRoom = HttpContext.Session.GetString("lastRoom") ?? "1";
        return RedirectToAction("Habitacion", new { sala = lastRoom });
    }
}

