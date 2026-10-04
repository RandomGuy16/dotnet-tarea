using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.AccesoDatos.Core;

namespace MiBotica.SolPedido.LogicaNegocio.Core
{
    public class OpcionLN : BaseLN
    {
        public List<Opcion> ListaOpciones()
        {
            try
            {
                return new OpcionDA().ListaOpciones();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;

            }
        }
    }
}