using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using PushApp.Core.Model;
using PushApp.Core.Servicios;

namespace PushApp.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        // Propiedades
        private ObservableCollection<Smartphone> _smartphoneLista;
        public ObservableCollection<Smartphone> SmartphoneLista
        {
            get { return _smartphoneLista; }
            set { SetProperty(ref _smartphoneLista, value); }
        }

        private Smartphone _smartphoneSeleccionado;
        public Smartphone SmartphoneSeleccionado
        {
            get { return _smartphoneSeleccionado; }
            set
            {
                SetProperty(ref _smartphoneSeleccionado, null);
                ShowViewModel<DetalleViewModel>(value);
            }
        }

        private readonly MvxSubscriptionToken _token;

        // Comandos
        public ICommand CmdNuevo { get; set; }

        // Servicios
        private readonly IServicioDatos _servicioDatos;

        public HomeViewModel(IServicioDatos servicioDatos, IMvxMessenger messenger)
        {
            _servicioDatos = servicioDatos;
            CmdNuevo = new MvxCommand(RunNuevo);
            _token = messenger.Subscribe<ViewModelMessage>(OnViewModelMessage);
            Task.Run(CargarLista);
        }

        private void OnViewModelMessage(ViewModelMessage obj)
        {
            var smartphone = obj.Elemento as Smartphone;

            switch (obj.Accion)
            {
                case "Add":
                    SmartphoneLista.Add(smartphone);
                    break;
                case "Delete":
                    SmartphoneLista.Remove(SmartphoneLista.FirstOrDefault(o => o.Id == smartphone.Id));
                    break;
            }
        }

        private async Task CargarLista()
        {
            var lista = await _servicioDatos.GetSmartphones();
            SmartphoneLista = new ObservableCollection<Smartphone>(lista);
        }

        private void RunNuevo()
        {
            ShowViewModel<NuevoViewModel>();
        }
    }
}