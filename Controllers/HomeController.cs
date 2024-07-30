using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        TempData["ResetTime"] = true;
        return View();
    }

    public IActionResult Tutorial()
    {
        return View();
    }

    public IActionResult Victoria()
    {
        return View();
    }

    public IActionResult Comenzar()
    {
        Escape.ReiniciarJuego();
        int estadoJuego = Escape.GetEstadoJuego();
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
        if (sala != Escape.GetEstadoJuego())
        {
            return RedirectToAction("Habitacion", new { sala = Escape.GetEstadoJuego() });
        }

        bool resultado = Escape.ResolverSala(sala, clave);

        if (resultado)
        {
            if (sala == 6)
            {
                return RedirectToAction("Victoria");
            }
            else
            {
                return RedirectToAction("Habitacion", new { sala = sala + 1 });
            }
        }
        else
        {
            ViewBag.Error = "Clave incorrecta. Inténtalo nuevamente.";
            return View($"Habitacion{sala}");
        }
    }

    public IActionResult Habitacion(int sala)
    {
        if (sala != Escape.GetEstadoJuego())
        {
            return RedirectToAction("Habitacion", new { sala = Escape.GetEstadoJuego() });
        }

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
