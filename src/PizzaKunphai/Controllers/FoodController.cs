using PizzaKunphai.Data.Interfaces;
using PizzaKunphai.Data.Models;
using PizzaKunphai.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaKunphai.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodRepository _drinkRepository;
        private readonly ICategoryRepository _categoryRepository;

        public FoodController(IFoodRepository drinkRepository, ICategoryRepository categoryRepository)
        {
            _drinkRepository = drinkRepository;
            _categoryRepository = categoryRepository;
        }
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Food> Foods;

            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                Foods = _drinkRepository.Foods.OrderBy(n=>n.FoodId);
                currentCategory = "All Foods";
            }
            else
            {
                if (string.Equals("SeaFood",_category,StringComparison.OrdinalIgnoreCase))
                {
                    Foods = _drinkRepository.Foods.Where(p => p.Category.CategoryName.Equals("SeaFood")).OrderBy(p=>p.Name);
                }
                else
                {
                    Foods = _drinkRepository.Foods.Where(p => p.Category.CategoryName.Equals("Meat-Deluxe")).OrderBy(p => p.Name);
                }
                currentCategory = _category;
             }
            var foodListViewModel = new FoodsListViewModel
            {
                Foods = Foods,
                CurrentCategory = currentCategory
            };
            return View(foodListViewModel);
        //ViewBag.Name = "DotNet,How?";
        //FoodsListViewModel vm = new FoodsListViewModel();
        //vm.Foods = _drinkRepository.Foods;
        //vm.CurrentCategory = "DrinkCategory";
        //return View(vm);
       }
    }
}
