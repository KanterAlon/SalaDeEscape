public static class Escape
{
    private static string[] incognitasSalas = {
        "742", // Respuesta para sala 1
        "HELP", // Respuesta para sala 2
        "SIERRA PAPA INDIA ROMEO INDIA TANGO", // Respuesta para sala 3
        "27", // Respuesta para sala 4
        "450", 
        // Respuesta para sala 5
    };
    private static int estadoJuego;

    static Escape()
    {
        InicializarJuego();
    }

    private static void InicializarJuego()
    {
        incognitasSalas = new string[]
        {
            "742", // Respuesta para sala 1
            "HELP", // Respuesta para sala 2
            "SIERRA PAPA INDIA ROMEO INDIA TANGO", // Respuesta para sala 3
            "27", // Respuesta para sala 4
            "450", // Respuesta para sala 5
            "450" // Respuesta para sala 6
        };
        estadoJuego = 1;
    }

    public static int GetEstadoJuego()
    {
        return estadoJuego;
    }

    public static void ReiniciarJuego()
    {
        estadoJuego = 1;
    }

    public static bool ResolverSala(int sala, string incognita)
    {
        if (sala != estadoJuego || sala < 1 || sala > incognitasSalas.Length)
            return false;

        if (incognitasSalas[sala - 1] == incognita)
        {
            estadoJuego++;
            return true;
        }

        return false;
    }

    public static bool EsUltimaSala(int sala)
    {
        return sala == incognitasSalas.Length;
    }
}
