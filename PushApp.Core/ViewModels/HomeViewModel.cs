using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
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

        // Comandos
        public ICommand CmdNuevo { get; set; }

        // Servicios
        private readonly IServicioDatos _servicioDatos;

        public HomeViewModel(IServicioDatos servicioDatos)
        {
            _servicioDatos = servicioDatos;
            CmdNuevo = new MvxCommand(RunNuevo);
            Task.Run(CargarLista);
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