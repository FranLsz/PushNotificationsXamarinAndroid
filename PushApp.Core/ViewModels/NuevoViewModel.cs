using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using PushApp.Core.Model;
using PushApp.Core.Servicios;

namespace PushApp.Core.ViewModels
{
    public class NuevoViewModel : MvxViewModel
    {
        // Propiedades
        private Smartphone _smartphone;
        public Smartphone Smartphone
        {
            get { return _smartphone; }
            set { SetProperty(ref _smartphone, value); }
        }

        // Comandos
        public ICommand CmdAgregar { get; set; }

        // Servicios
        private readonly IServicioDatos _servicioDatos;
        private readonly IMvxMessenger _messenger;

        public NuevoViewModel(IServicioDatos servicioDatos, IMvxMessenger messenger)
        {
            _servicioDatos = servicioDatos;
            _messenger = messenger;
            _smartphone = new Smartphone();
            CmdAgregar = new MvxCommand(RunAgregar);

        }

        private async void RunAgregar()
        {
            var s = await _servicioDatos.AddSmartphone(Smartphone);
            var vmMensaje = new ViewModelMessage(this, "Add", s);
            _messenger.Publish(vmMensaje);

            Close(this);
        }
    }
}