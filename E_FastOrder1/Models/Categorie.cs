using System;
using System.Collections.Generic;
using System.Text;

namespace E_FastOrder1.Models
{
    public enum Categories
    {
        Sandwich,
        Plates,
        Libanais,
        Hamburgur
    }
    public class Categorie
    {
        public Categories Id { get; set; }

        public String image { get; set; }
    }
}
