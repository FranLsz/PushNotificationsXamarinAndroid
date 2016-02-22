using System.Threading.Tasks;
using PushApp.Core.Models;
using PushApp.Core.Utils;

namespace PushApp.Core.Services
{
    public class ServicioDatos : IServicioDatos
    {
        /*private readonly RestClient _client;

        public ServicioDatos()
        {
            _client = new RestClient(GlobalVars.UrlApi);
        }*/


        #region Usuario

        public async Task<UsuarioModel> Validar(UsuarioModel model)
        {
            return new UsuarioModel();
        }

        #endregion
    }
}