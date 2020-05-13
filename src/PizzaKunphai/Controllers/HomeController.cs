using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaKunphai.Data.Interfaces;
using PizzaKunphai.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaKunphai.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFoodRepository _drinkRepository;
        public HomeController(IFoodRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }
      
        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredFoods = _drinkRepository.PreferredFoods
            };
            return View(homeViewModel);
        }
    }
}
