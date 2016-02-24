using System.Windows.Input;
using MvvmCross.Core.ViewModels;
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

        public NuevoViewModel(IServicioDatos servicioDatos)
        {
            _servicioDatos = servicioDatos;
            _smartphone = new Smartphone();
            CmdAgregar = new MvxCommand(RunAgregar);
            
        }

        private async void RunAgregar()
        {
            await _servicioDatos.AddSmartphone(Smartphone);
            Close(this);
        }
    }
}