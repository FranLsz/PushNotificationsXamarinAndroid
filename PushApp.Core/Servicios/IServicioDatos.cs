using System.Collections.Generic;
using System.Threading.Tasks;
using PushApp.Core.Model;

namespace PushApp.Core.Servicios
{
    public interface IServicioDatos
    {
        Task<List<Smartphone>> GetSmartphones();
        Task<Smartphone> AddSmartphone(Smartphone model);
        void DeleteSmartphone(Smartphone model);
    }
}