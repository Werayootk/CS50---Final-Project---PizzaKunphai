using PizzaKunphai.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaKunphai.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzaKunphai.Data.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly AppDbContext _appDbContext;
        public FoodRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Food> Foods => _appDbContext.Foods.Include(c => c.Category);

        public IEnumerable<Food> PreferredFoods => _appDbContext.Foods.Where(p => p.IsPreferredFood).Include(c => c.Category);

        public Food GetDrinkById(int FoodId) => _appDbContext.Foods.FirstOrDefault(p => p.FoodId == FoodId);
    }
}
