using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TareaMVVM.Models;
using Xamarin.Forms;

namespace TareaMVVM.ViewModels
{
   public class ListEmpleadostViewModel: BaseViewModel
    {
        private ObservableCollection<Empleados> _empleados;

        public ObservableCollection<Empleados> Empleados
        {
            get { return _empleados; }
            set { _empleados = value; OnPropertyChanged(); }
        }

        private Empleados _selectedProduct;

        public Empleados SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged(); }

        }

        public ICommand GoToDetailsCommand { private set; get; }

        public INavigation Navigation { get; set; }

        public ListEmpleadostViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GoToDetailsCommand = new Command<Type>(async (pageType) => await GoToDetails(pageType));

            cargar();
        }

        public async void cargar()
        {
            Empleados = new ObservableCollection<Empleados>();

            List<Empleados> empleado = new List<Empleados>();
            empleado = await App.BaseDatos.ObtenerListaEmpleados();

           
            for(int i =0; i < empleado.Count; i++ )
            {
                Empleados.Add(new Empleados() { id = empleado[i].id, nombre = empleado[i].nombre, apellido = empleado[i].apellido, edad = empleado[i].edad, direccion = empleado[i].direccion, puesto = empleado[i].puesto });
            }
        }

        async Task GoToDetails(Type pageType)
        {
            if (SelectedProduct != null)
            {
                var page = (Page)Activator.CreateInstance(pageType);

                page.BindingContext = new EmpleadosViewModels()
                {
                    ID = SelectedProduct.id,
                    Nombre = SelectedProduct.nombre,
                    Apellido = SelectedProduct.apellido,
                    Edad = SelectedProduct.edad,
                    Direccion = SelectedProduct.direccion,
                    Puesto = SelectedProduct.puesto
                  
                };

                await Navigation.PushAsync(page);
            }
        }
    }
}
