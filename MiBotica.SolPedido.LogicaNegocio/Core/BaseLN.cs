namespace MiBotica.SolPedido.LogicaNegocio.Core;

using System.Reflection;
using log4net;

public class BaseLN
{
    protected ILog Log
    {
        get { return LogManager.GetLogger(GetType()); }
    }
}
