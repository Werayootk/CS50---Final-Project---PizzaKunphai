using PizzaKunphai.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace PizzaKunphai.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context =
                applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Foods.Any())
            {
                context.AddRange
                (
                    new Food
                    {
                        Name = "Ham and Crab Sticks",
                        Price = 279M,
                        ShortDescription = "Pineapple, ham, crab stick, mozzarella cheese Thousand Island Sauce",
                        LongDescription = "Pineapple, ham, crab stick, mozzarella cheese Thousand Island Sauce",
                        Category = Categories["Meat-Deluxe"],
                        ImageUrl = "https://cdn.1112.com/1112/public/images/products/pizza/OCT2019/102226.png",
                        InStock = true,
                        IsPreferredFood = true,
                        ImageThumbnailUrl = "https://cdn.1112.com/1112/public/images/products/pizza/OCT2019/102226.png"
                    },
                    new Food
                    {
                        Name = "Seafood Cocktail",
                        Price = 379M,
                        ShortDescription = "Pineapple, ham, shrimp, crab stick, mozzarella cheese Thousand Island Sauce",
                        LongDescription = "Pineapple, ham, shrimp, crab stick, mozzarella cheese Thousand Island Sauce",
                        Category = Categories["SeaFood"],
                        ImageUrl = "https://cdn.1112.com/1112/public/images/products/pizza/website/Pan_Seafood-Cocktail.png",
                        InStock = true,
                        IsPreferredFood = true,
                        ImageThumbnailUrl = "https://cdn.1112.com/1112/public/images/products/pizza/website/Pan_Seafood-Cocktail.png"
                    },
                    new Food
                    {
                        Name = "Super Seafood",
                        Price = 379M,
                        ShortDescription = "Squid, shrimp, garlic, pepper, basil, onion, bell peppers and marinara sauce",
                        LongDescription = "Squid, shrimp, garlic, pepper, basil, onion, bell peppers and marinara sauce",
                        Category = Categories["SeaFood"],
                        ImageUrl = "https://cdn.1112.com/1112/public/images/products/pizza/OCT2019/102722.png",
                        InStock = true,
                        IsPreferredFood = true,
                        ImageThumbnailUrl = "https://cdn.1112.com/1112/public/images/products/pizza/OCT2019/102722.png"
                    },
                    new Food
                    {
                        Name = "Seafood Deluxe",
                        Price = 379M,
                        ShortDescription = "Onion, capsicum, seafood mixed, prawns, mozzarella cheese, crab sticks, marinara sauce",
                        LongDescription = "Onion, capsicum, seafood mixed, prawns, mozzarella cheese, crab sticks, marinara sauce",
                        Category = Categories["SeaFood"],
                        ImageUrl = "https://cdn.1112.com/1112/public/images/products/pizza/website/Pan_Seafood-Deluxe.png",
                        InStock = true,
                        IsPreferredFood = true,
                        ImageThumbnailUrl = "https://cdn.1112.com/1112/public/images/products/pizza/website/Pan_Seafood-Deluxe.png"
                    },

                    new Food
                    {
                        Name = "Super deluxe",
                        Price = 279M,
                        ShortDescription = "Pepperoni, mushrooms, pineapples, onions, bell peppers, ham, bacon strips, smoked pork sausage Italian sausage Mozzarella Cheese Pizza Sauce",
                        LongDescription = "Pepperoni, mushrooms, pineapples, onions, bell peppers, ham, bacon strips, smoked pork sausage Italian sausage Mozzarella Cheese Pizza Sauce",
                        Category = Categories["Meat-Deluxe"],
                        ImageUrl = "https://cdn.1112.com/1112/public/images/products/pizza/website/Pan_Super-Deluxe.png",
                        InStock = true,
                        IsPreferredFood = true,
                        ImageThumbnailUrl = "https://cdn.1112.com/1112/public/images/products/pizza/website/Pan_Super-Deluxe.png"
                    },
                    new Food
                    {
                        Name = "Pork Deluxe",
                        Price = 319M,
                        ShortDescription = "Ham, smoked pork sausage, pepperoni, mushrooms, pineapples, onions and bell peppers",
                        LongDescription = "Ham, smoked pork sausage, pepperoni, mushrooms, pineapples, onions and bell peppers",
                        Category = Categories["Meat-Deluxe"],
                        ImageUrl = "https://cdn.1112.com/1112/public/images/products/pizza/OCT2019/New-Pizza-Pork-Deluxe_en.png",
                        InStock = true,
                        IsPreferredFood = true,
                        ImageThumbnailUrl = "https://cdn.1112.com/1112/public/images/products/pizza/OCT2019/New-Pizza-Pork-Deluxe_en.png"
                    },
                    new Food
                    {
                        Name = "Hawaiian",
                        Price = 279M,
                        ShortDescription = "Pineapple, ham, bacon strips, mozzarella cheese, pizza sauce",
                        LongDescription = "Pineapple, ham, bacon strips, mozzarella cheese, pizza sauce",
                        Category = Categories["Meat-Deluxe"],
                        ImageUrl = "https://cdn.1112.com/1112/public/images/products/pizza/OCT2019/102204.png",
                        InStock = true,
                        IsPreferredFood = true,
                        ImageThumbnailUrl = "https://cdn.1112.com/1112/public/images/products/pizza/OCT2019/102204.png"
                    }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "SeaFood", Description="All SeaFood Foods" },
                        new Category { CategoryName = "Meat-Deluxe", Description="All Meat-Deluxe Foods" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}