using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using PushApp.Core.Model;
using PushApp.Core.Servicios;

namespace PushApp.Core.ViewModels
{
    public class DetalleViewModel : MvxViewModel
    {
        // Propiedades
        public Smartphone Smartphone { get; set; }
        public string PrecioFormateado { get; set; }

        // Comandos
        public ICommand CmdBorrar { get; set; }

        // Servicios
        private readonly IServicioDatos _servicioDatos;

        public DetalleViewModel(IServicioDatos servicioDatos)
        {
            _servicioDatos = servicioDatos;
            CmdBorrar = new MvxCommand(RunBorrar);
        }

        public void Init(Smartphone smartphone)
        {
            Smartphone = smartphone;
            PrecioFormateado = Smartphone.Precio + " €";
        }

        private void RunBorrar()
        {
            _servicioDatos.DeleteSmartphone(Smartphone);
            Close(this);
        }


    }
}