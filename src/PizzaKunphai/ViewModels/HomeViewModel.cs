using PizzaKunphai.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaKunphai.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Food> PreferredFoods { get; set; }
    }
}
