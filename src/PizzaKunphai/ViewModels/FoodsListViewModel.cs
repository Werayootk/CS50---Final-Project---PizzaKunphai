using PizzaKunphai.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaKunphai.ViewModels
{
    public class FoodsListViewModel
    {
        public IEnumerable<Food> Foods { get; set; }
        public string CurrentCategory { get; set; }
    }
}
