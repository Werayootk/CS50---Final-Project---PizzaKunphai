using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaKunphai.Data.Interfaces;
using PizzaKunphai.Data.Models;
using PizzaKunphai.ViewModels;


namespace PizzaKunphai.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IFoodRepository _drinkRepository;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(IFoodRepository drinkRepository, ShoppingCart shoppingCart)
        {
            _drinkRepository = drinkRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;


            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(sCVM);
        }
        public RedirectToActionResult AddToShoppingCart(int FoodId)
        {
            var selectedDrink = _drinkRepository.Foods.FirstOrDefault(p => p.FoodId == FoodId);
            if (selectedDrink != null)
            {
                _shoppingCart.AddToCart(selectedDrink,1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int FoodId)
        {
            var selectedDrink = _drinkRepository.Foods.FirstOrDefault(p => p.FoodId == FoodId);
            if (selectedDrink != null)
            {
                _shoppingCart.RemoveFromCart(selectedDrink);
            }
            return RedirectToAction("Index");
        }
    }
}
