using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TareaMVVM.Views;
using Xamarin.Forms;

namespace TareaMVVM.ViewModels
{
    public class EmpleadosViewModels : BaseViewModel
    {

        private int _id;
        private string _nombre;
        private string _apellido;
        private string _edad;
        private string _direccion;
        private string _puesto;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; OnPropertyChanged(); }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; OnPropertyChanged(); }
        }

        public string Edad
        {
            get { return _edad; }
            set { _edad = value; OnPropertyChanged(); }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; OnPropertyChanged(); }
        }

        public string Puesto
        {
            get { return _puesto; }
            set { _puesto = value; OnPropertyChanged(); }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }

        //lista de comandos a utilizar en pantalla
        public ICommand CommandListar { get; set; }
        public ICommand CommandGuardar { get; set; }

        public ICommand CommandModificar { get; set; }
        public ICommand CommandEliminar { get; set; }

        
        //acciones ICommand 
        public async void Listado()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ListaEmpleados());
        }

        public async void Modificar()
        {
            if (String.IsNullOrEmpty(Nombre) || String.IsNullOrEmpty(Apellido) || String.IsNullOrEmpty(Edad) || String.IsNullOrEmpty(Direccion) || String.IsNullOrEmpty(Puesto))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debe Completar todos los datos", "Cerrar");
            }
            else
            {
                var emp = new Models.Empleados
                {
                    id = ID,
                    nombre = Nombre,
                    apellido = Apellido,
                    edad = Edad,
                    direccion = Direccion,
                    puesto = Puesto
                };

                var resultado = await App.BaseDatos.GrabarEmpleado(emp);

                if (resultado == 1)
                {
                    await Application.Current.MainPage.DisplayAlert("Advertencia", "Registro Modificado", "Cerrar");

                    await Application.Current.MainPage.Navigation.PushAsync(new ListaEmpleados());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Advertencia", "No se pudo Modificar", "Cerrar");
                }
            }           
        }

        public async void Eliminar()
        {
            var emp = new Models.Empleados
            {
                id = ID,
                nombre = Nombre,
                apellido = Apellido,
                edad = Edad,
                direccion = Direccion,
                puesto = Puesto
            };

            var resultado = await App.BaseDatos.EliminarEmpleado(emp);

            if (resultado == 1)
            {
                await Application.Current.MainPage.DisplayAlert("Advertencia", "Registro eliminado", "Cerrar");

                await Application.Current.MainPage.Navigation.PushAsync(new ListaEmpleados());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Advertencia", "No se pudo eliminar", "Cerrar");
            }


        }

        public async void Guardar()
        {
            if (String.IsNullOrEmpty(Nombre) || String.IsNullOrEmpty(Apellido)|| String.IsNullOrEmpty(Edad)|| String.IsNullOrEmpty(Direccion)|| String.IsNullOrEmpty(Puesto))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debe Completar todos los datos", "Cerrar");
            }
            else
            {
                var emp = new Models.Empleados
                {
                    nombre = Nombre,
                    apellido = Apellido,
                    edad = Edad,
                    direccion = Direccion,
                    puesto = Puesto
                };

                var resultado = await App.BaseDatos.GrabarEmpleado(emp);

                if (resultado == 1)
                {
                    await Application.Current.MainPage.DisplayAlert("Mensaje", "Registro guardado", "Cerrar");
                    Nombre = String.Empty;
                    Edad = String.Empty;
                    Apellido = String.Empty;
                    Direccion = String.Empty;
                    Puesto = String.Empty;

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se Pudo Guardar", "Cerrar");

                }
            }
        }

        public EmpleadosViewModels()
        {
            CommandListar = new Command(() => Listado());
            CommandGuardar = new Command(() => Guardar());
            CommandModificar = new Command(() => Modificar());
            CommandEliminar = new Command(() => Eliminar());
        }

    }
}
