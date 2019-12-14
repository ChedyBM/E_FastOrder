using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using E_FastOrder1.Models;
using E_FastOrder1.ViewModels;
using System.Collections.ObjectModel;

namespace E_FastOrder1.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Cart : ContentPage
    {
        
        CartViewModel cvm;
        public Cart()
        {
            InitializeComponent();

           

            BindingContext = cvm = new CartViewModel();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (cvm.CartList.Count == 0)
                cvm.LoadCartCommand.Execute(null);

            //cvm.CartList = new ObservableCollection<Product>();

            ItemsListView.ItemsSource = cvm.CartList;

            cvm.Title = "Cart";

            totallabel.Text = "Total: " + cvm.totalbind + "dt";

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var product = button.BindingContext as Product;
            cvm.DataStore.DeleteItemAsync(product.Id);

            cvm.CartList.Clear();
            cvm.LoadCartCommand.Execute(null);
            ItemsListView.ItemsSource = null;
            
            ItemsListView.ItemsSource = cvm.CartList;
            totallabel.Text = "Total: " +cvm.totalbind + "dt";
            if (cvm.CartList.Count == 0)
                totallabel.Text = "";
        }
    }
}