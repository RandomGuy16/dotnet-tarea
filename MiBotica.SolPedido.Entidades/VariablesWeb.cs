using MiBotica.SolPedido.Entidades.Core;

namespace MiBotica.SolPedido.Entidades;

public class VariablesWeb
{
    private static List<Opcion> _gOpciones = new();
    private static Usuario _gUsuario;

    public static List<Opcion> gOpciones
    {
        get => _gOpciones;
        set => _gOpciones = value;
    }

    public static Usuario gUsuario
    {
        get => _gUsuario;
        set => _gUsuario = value;
    }
}
