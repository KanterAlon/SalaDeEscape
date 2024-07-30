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
        ViewBag.IntentosExtras = Escape.GetIntentosExtras();
        ViewBag.PistasUsadas = Escape.GetPistasUsadas();
        ViewBag.NombreJugador = Escape.GetNombreJugador();
        return View();
    }

    [HttpPost]
    public IActionResult Comenzar(string jugador, int nivel)
    {
        Escape.ReiniciarJuego();
        Escape.SetNombreJugador(jugador);

        int initialTime;
        switch (nivel)
        {
            case 1:
                initialTime = 900; // 15 minutos
                break;
            case 2:
                initialTime = 600; // 10 minutos
                break;
            case 3:
                initialTime = 300; // 5 minutos
                break;
            default:
                initialTime = 600; // Valor por defecto (10 minutos)
                break;
        }

        TempData["InitialTime"] = initialTime;
        TempData["ResetTime"] = true;

        int estadoJuego = Escape.GetEstadoJuego();
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
            if (Escape.EsUltimaSala(sala))
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
            Escape.IncrementarIntentos();
            ViewBag.Error = "Clave incorrecta. Inténtalo nuevamente.";
            ViewBag.NombreJugador = Escape.GetNombreJugador();
            return View($"Habitacion{sala}");
        }
    }

    public IActionResult Habitacion(int sala)
    {
        if (sala != Escape.GetEstadoJuego())
        {
            return RedirectToAction("Habitacion", new { sala = Escape.GetEstadoJuego() });
        }

        ViewBag.NombreJugador = Escape.GetNombreJugador();
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

    [HttpPost]
    public IActionResult UsarPista(int sala)
    {
        Escape.UsarPista();
        return new EmptyResult();
    }
}
