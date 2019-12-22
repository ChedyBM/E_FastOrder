using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using E_FastOrder1.Models;
using E_FastOrder1.ViewModels;

namespace E_FastOrder1.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        async void open_cart(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Cart()));
        }
        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Product
            {
                Name = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
       
    }
}