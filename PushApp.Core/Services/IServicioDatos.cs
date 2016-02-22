using System.Threading.Tasks;
using PushApp.Core.Models;

namespace PushApp.Core.Services
{
    public interface IServicioDatos
    {

        #region Usuario

        Task<UsuarioModel> Validar(UsuarioModel model);

        #endregion

    }
}