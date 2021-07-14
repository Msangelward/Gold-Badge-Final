using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1_Komodo_CafePOCO
{
    public class MenuItem
    {
        //menu items:  meal number, meal name,
        //a description, list of ingredients, price


        //use properties, constructors and fields

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }

        public List<string> ListOfIngredients { get; set; }
        public double Price { get; set; }

        public MenuItem() { }

        public MenuItem(int mealNumber, string mealName, string description, List<string> listOfIngredients, double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            ListOfIngredients = listOfIngredients;
            Price = price;

        }
    }
}
