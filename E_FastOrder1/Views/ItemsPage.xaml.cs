using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using E_FastOrder1.Models;
using E_FastOrder1.Views;
using E_FastOrder1.ViewModels;
using System.Collections.ObjectModel;

namespace E_FastOrder1.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }
        public Categories categ;
        public ItemsPage(Categories cat)
        {
            InitializeComponent();
            this.categ = cat;
            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Product;
            if (item == null)
                return;
            
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void open_cart(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Cart()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);

           viewModel.Items = new ObservableCollection<Product>(viewModel.Items.Where(s=> s.cat_id == categ).ToList());

            ItemsListView.ItemsSource = viewModel.Items;

            viewModel.Title = categ.ToString();
        }
    }
}