using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaEmpleados : ContentPage
    {
        public ListaEmpleados()
        {
            InitializeComponent();
            BindingContext = new ViewModels.ListEmpleadostViewModel(Navigation);
        }
    }
}