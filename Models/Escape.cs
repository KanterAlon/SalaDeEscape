public static class Escape
{
    private static string[] incognitasSalas = {
        "742", // Respuesta para sala 1
        "HELP", // Respuesta para sala 2
        "SIERRA PAPA INDIA ROMEO INDIA TANGO", // Respuesta para sala 3
        "27", // Respuesta para sala 4
        "450", // Respuesta para sala 5
        "x" // Respuesta para sala 6
    };
    private static int estadoJuego;
    private static int intentosExtras;
    private static int pistasUsadas;
    private static string nombreJugador;

    static Escape()
    {
        InicializarJuego();
    }

    private static void InicializarJuego()
    {
        estadoJuego = 1;
        intentosExtras = 0;
        pistasUsadas = 0;
        nombreJugador = string.Empty;
    }

    public static int GetEstadoJuego()
    {
        return estadoJuego;
    }

    public static void ReiniciarJuego()
    {
        estadoJuego = 1;
        intentosExtras = 0;
        pistasUsadas = 0;
        nombreJugador = string.Empty;
    }

    public static bool ResolverSala(int sala, string incognita)
    {
        if (sala != estadoJuego || sala < 1 || sala > incognitasSalas.Length)
            return false;

        if (incognitasSalas[sala - 1].Equals(incognita, StringComparison.OrdinalIgnoreCase))
        {
            estadoJuego++;
            return true;
        }

        intentosExtras++;
        return false;
    }

    public static bool EsUltimaSala(int sala)
    {
        return sala == incognitasSalas.Length;
    }

    public static void IncrementarIntentos()
    {
        intentosExtras++;
    }

    public static void UsarPista()
    {
        pistasUsadas++;
    }

    public static int GetIntentosExtras()
    {
        return intentosExtras;
    }

    public static int GetPistasUsadas()
    {
        return pistasUsadas;
    }

    public static void SetNombreJugador(string nombre)
    {
        nombreJugador = nombre;
    }

    public static string GetNombreJugador()
    {
        return nombreJugador;
    }
}
