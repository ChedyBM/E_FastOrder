using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using E_FastOrder1.Models;
using E_FastOrder1.Views;
using Xamarin.Forms;

namespace E_FastOrder1.ViewModels
{
    class CartViewModel:BaseViewModel
    {
        public Command LoadCartCommand { get; set; }
        public ObservableCollection<Product> CartList { get; set; }
        public float total { get; set; }
        public string totalbind { get; set; }
        public CartViewModel()
        {
            
            Title = "Cart";
            CartList = new ObservableCollection<Product>();
            LoadCartCommand = new Command(async () => await ExecuteLoadCartCommand());
            
            

        }

       

        async Task ExecuteLoadCartCommand()
        {

            if(IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await DataStore.GetCartAsync(true);
                foreach (var item in items)
                {
                    CartList.Add(item);
                }
                total = 0;
                foreach (var prod in CartList)
                {
                    total += float.Parse(prod.Price.Remove(prod.Price.Length - 2));
                    totalbind = total.ToString();
                    Debug.WriteLine(totalbind);
                    
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("chedy");
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
