using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_FastOrder1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_FastOrder1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel lvm;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = lvm = new LoginViewModel();
        }

        
       
    }
}