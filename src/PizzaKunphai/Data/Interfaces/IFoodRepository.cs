using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaKunphai.Data.Models;

namespace PizzaKunphai.Data.Interfaces
{
    public interface IFoodRepository
    {
        IEnumerable<Food> Foods { get; }
        IEnumerable<Food> PreferredFoods { get; }
        Food GetDrinkById(int FoodId);
    }
}
