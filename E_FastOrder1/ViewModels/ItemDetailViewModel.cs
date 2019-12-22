using System;
using System.Diagnostics;
using System.Threading.Tasks;
using E_FastOrder1.Models;
using Xamarin.Forms;

namespace E_FastOrder1.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Command AddtoCartCommand { get; set; }
        public Product Item { get; set; }
        public ItemDetailViewModel(Product item = null)
        {
            Title = item?.Name;
            Item = item;
            AddtoCartCommand = new Command(async () => await ExecuteAddtoCartCommand(Item));
        }

        async Task ExecuteAddtoCartCommand(Product addedItem)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var itemAdded = await DataStore.AddItemAsync(addedItem);
                


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
