using E_FastOrder1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_FastOrder1.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]


    public partial class MenuPage : ContentPage
    {

        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<Categorie> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<Categorie>
            {
                new Categorie {Id = Categories.Sandwich, image="FoodandDrink.png" },
                new Categorie {Id = Categories.Hamburgur, image="burger.png" },
                new Categorie {Id = Categories.Plates, image="plate512.png" },
                new Categorie {Id = Categories.Libanais, image="libanais512.png" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((Categorie)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}