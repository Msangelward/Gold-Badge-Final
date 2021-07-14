using Challenge_1_Komodo_CafePOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1_Komodo_CafeRepository
{
    public class MenuItemRepository
    {
        //Create new menu items, delete menu items, receive a list of all
        //items on cafe's menu

        private List<MenuItem> _listOfMenuItem = new List<MenuItem>();

        //Create
        public void AddMenuItemToList(MenuItem item)
        {
            _listOfMenuItem.Add(item);
        }

        //Read
        public List<MenuItem> GetMenuItemList()
        {
            return _listOfMenuItem;
        }

        //Update
        public bool UpdateExistingItem(string originalItem, MenuItem newItem)
        {
            //find the content
            MenuItem oldItem = GetItemByMealName(originalItem);

            //update the content
            if(oldItem != null)
            {
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.MealName = newItem.MealName;
                oldItem.Description = newItem.Description;
                oldItem.ListOfIngredients = newItem.ListOfIngredients;
                oldItem.Price = newItem.Price;

                return true;

            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveItemFromList(string mealName)
        {
            MenuItem item = GetItemByMealName(mealName);

            if(mealName == null)
            {
                return false;
            }

            int initialCount = _listOfMenuItem.Count;
            _listOfMenuItem.Remove(item);

            if (initialCount > _listOfMenuItem.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Helper Method
        public MenuItem GetItemByMealName(string mealName)
        {
            foreach (MenuItem Item in _listOfMenuItem)
            {
                if(Item.MealName.ToLower() == mealName.ToLower())
                {
                    return Item;
                }
            }

            return null;
        }
    }
}
