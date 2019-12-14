using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_FastOrder1.Models;

namespace E_FastOrder1.Services
{
    public class MockDataStore : IDataStore<Product>
    {
        readonly List<Product> productsList;

        readonly List<Product> cartProduct;

        public MockDataStore()
        {
            cartProduct = new List<Product>
                    {
                        
                    };
            productsList = new List<Product>
                {
                    new Product
                    {
                        Name = "Chiken",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        Image = "i9618f.jpg",
                        Price = "5.5dt",
                        cat_id = Categories.Plates
                    },
                    new Product
                    {
                        Name = "Barakuda",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        Image = "ood.jpg",
                        Price = "1.5dt",
                        cat_id = Categories.Plates
                    },
                    new Product
                    {
                        Name = "KickUp",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        Image = "i1969d.png",
                        Price = "1.5dt",
                        cat_id = Categories.Plates
                    },
                    new Product
                    {
                        Name = "Fly",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        Image = "thon.jpg",
                        Price = "1.5dt",
                        cat_id = Categories.Plates
                    },
                     new Product
                    {
                        Name = "Freedom",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        Image = "i600.jpg",
                        Price = "1.5dt",
                        cat_id = Categories.Sandwich
                    },
                    new Product
                    {
                        Name = "Cream",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        Image = "xl.jpg",
                        Price = "1.5dt",
                        cat_id = Categories.Sandwich
                    },
                    new Product
                    {
                        Name = "Frensh",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        Image = "cafe.jpg",
                        Price = "1.5dt",
                        cat_id = Categories.Sandwich
                    },
                    new Product
                    {

                        Name = "Sindro",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        Image = "i42x428.jpg",
                        Price = "1.5dt",
                        cat_id = Categories.Libanais
                    },
                    new Product
                    {
                        Name = "Kazemo",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        Image = "i500x500.jpg",
                        Price = "1.5dt",
                        cat_id = Categories.Libanais
                    },
                    new Product
                    {
                        Name = "Sifon",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        Image = "chic3.jpg",
                        Price = "1.5dt",
                        cat_id = Categories.Libanais
                    },
                    new Product
                    {
                        Name = "Kids",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        Image = "amburger.jpg",
                        Price = "1.5dt",
                        cat_id = Categories.Hamburgur

                    },
                    new Product
                    {
                        Name = "Double Fat",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        Image = "vegetable.jpg",
                        Price = "1.5dt",
                        cat_id = Categories.Hamburgur
                    }
                };
        }

        public async Task<bool> AddItemAsync(Product item)
        {
            cartProduct.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Product item)
        {
            var oldItem = productsList.Where((Product arg) => arg.Id == item.Id).FirstOrDefault();
            productsList.Remove(oldItem);
            productsList.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = cartProduct.Where((Product arg) => arg.Id == id).FirstOrDefault();
            cartProduct.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Product> GetItemAsync(string id)
        {
            return await Task.FromResult(productsList.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Product>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(productsList);
        }

        public async Task<IEnumerable<Product>> GetCartAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(cartProduct);
        }
    }
}