using System;
using System.IO;
using TareaMVVM.Controller;
using TareaMVVM.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaMVVM
{
    public partial class App : Application
    {

        static DataBaseSQLite basedatos;


        public static DataBaseSQLite BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new DataBaseSQLite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MVVM.db3"));
                }


                return basedatos;
            }

        }


        public App()
        {
            InitializeComponent();

             MainPage = new NavigationPage(new Views.Empleados());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
