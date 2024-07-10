public static class Escape
{
   
    private static string[] incognitasSalas;
    private static int estadoJuego;

 
    private static void InicializarJuego()
    {
     
        incognitasSalas = new string[]
        {
            "",
            "",
           
        };

        estadoJuego = 1; 
    }


    public static int ConseguirEstadoJuego()
    {
        return estadoJuego;
    }


    public static void AvanzarSala()
    {
        if (estadoJuego < incognitasSalas.Length)
        {
            estadoJuego++;
        }
     
    }

   
    public static bool ValidarRespuesta(string respuesta)
    {

        string solucion = incognitasSalas[estadoJuego - 1]; 

     
        return respuesta == solucion;
    }

   
    public static void ReiniciarJuego()
    {
        InicializarJuego(); 
    }
}
