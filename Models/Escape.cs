public static class Escape
{
    private static string[] incognitasSalas;
    private static int estadoJuego;

    // Inicializa el juego con el array de incógnitas correctas
    private static void InicializarJuego()
    {
        incognitasSalas = new string[]
        {
            "742", // Clave para la primera sala
            "HELP", // Reemplazar con las claves reales de cada sala
            "clave3",
            // Agregar tantas claves como salas existan
        };
        estadoJuego = 1;
    }

    // Retorna el estado del juego
    public static int GetEstadoJuego()
    {
        if (incognitasSalas == null || incognitasSalas.Length == 0)
        {
            InicializarJuego();
        }
        return estadoJuego;
    }

    // Recibe el número de sala a resolver y la incógnita elegida por el usuario.
    public static bool ResolverSala(int sala, string incognita)
    {
        if (incognitasSalas == null || incognitasSalas.Length == 0)
        {
            InicializarJuego();
        }

        if (sala != estadoJuego)
        {
            return false; // Intentando resolver una sala a la que aún no tiene acceso
        }

        if (incognitasSalas[sala - 1].Equals(incognita, StringComparison.OrdinalIgnoreCase))
        {
            estadoJuego++;
            return true;
        }
        return false;
    }

    // Verifica si es la última sala
    public static bool EsUltimaSala(int sala)
    {
        return sala == incognitasSalas.Length;
    }

    // Reinicia el juego
    public static void ReiniciarJuego()
    {
        InicializarJuego();
    }
}
