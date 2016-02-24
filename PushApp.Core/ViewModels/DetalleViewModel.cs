using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
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
        private readonly IMvxMessenger _messenger;

        public DetalleViewModel(IServicioDatos servicioDatos, IMvxMessenger messenger)
        {
            _servicioDatos = servicioDatos;
            _messenger = messenger;
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
            var vmMensaje = new ViewModelMessage(this, "Delete", Smartphone);
            _messenger.Publish(vmMensaje);

            Close(this);
        }


    }
}