using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using E_FastOrder1.Models;

namespace E_FastOrder1.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)Categories.Sandwich, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)Categories.Sandwich:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage(Categories.Sandwich)));
                        break;
                    case (int)Categories.Hamburgur:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage(Categories.Hamburgur)));
                        break;
                    case (int)Categories.Plates:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage(Categories.Plates)));
                        break;
                    case (int)Categories.Libanais:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage(Categories.Libanais)));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}