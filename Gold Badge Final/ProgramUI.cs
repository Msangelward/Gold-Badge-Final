using Challenge_1_Komodo_CafePOCO;
using Challenge_1_Komodo_CafeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Final
{
    class ProgramUI
    {

        //create Program file that allows manager to
        //add, delete, and see all items in menu list
        //no need to update at this time 

        private MenuItemRepository _itemRepo = new MenuItemRepository();

        //Method that runs/starts the UI portion of the application
        public void Run()
        {
            //this is the setup, anything that needs to be done before user sees it
            Menu();
        }

        //Menu Method
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                //Display options to the user

                Console.WriteLine("Select a menu option:\n" +
                    "1. Create new Menu Item\n" +
                    "2. View All Menu Items\n" +
                    "3. View Menu Item by Meal Name\n" +
                    "4. Update Existing Menu Item\n" +
                    "5. Delete Existing Menu Item\n" +
                    "6. Exit");

                //Get the user's input
                string input = Console.ReadLine();

                //Evaluate user's input and act accordingly

                switch (input)
                {
                    case "1":
                        //Create new Menu Item"
                        CreateNewMenuItem();
                        break;
                    case "2":
                        //View All Menu Items"
                        DisplayAllMenuItems();
                        break;
                    case "3":
                        //View Menu Item by Meal Name
                        DisplayMenuItemByMealName();
                        break;
                    case "4":
                        //Update Existing Menu Item
                        UpdateExistingMenuItem();
                        break;
                    case "5":
                        //Delete Existing Menu Item
                        DeleteExistingMenuItem();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Menu now complete. Go forth, and be destressed!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;

                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Create new MenuItem
        private void CreateNewMenuItem()
        {
            Console.Clear();
            MenuItem newMenuItem = new MenuItem();

            //Meal Number
            Console.WriteLine("Enter Menu Number:");
            string mealNumberAsString = Console.ReadLine();
            newMenuItem.MealNumber = int.Parse(mealNumberAsString);

            //Meal Name
            Console.WriteLine("Enter the Meal Name:");
            newMenuItem.MealName = Console.ReadLine();

            //Description
            Console.WriteLine("Enter the Description of Meal:");
            newMenuItem.Description = Console.ReadLine();

            //List of Ingredients  new List<string>()
            List<string> listOfIngredients = new List<string>();
            bool isDone = true;
            do
            {
                Console.WriteLine("Enter an ingredient or 'done' if there are no more ingredient to be added:");
                var ingredient = Console.ReadLine();
                if (ingredient.ToLower() != "done")
                {
                    listOfIngredients.Add(ingredient);
                    Console.WriteLine("Ingredient added to List");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                isDone = false;
            } while (isDone);
                Console.WriteLine("Ingredients list now complete.");
            
            
            newMenuItem.ListOfIngredients = listOfIngredients;

            //Price
            Console.WriteLine("Enter Price of Meal:");
            string priceAsString = Console.ReadLine();
            newMenuItem.Price = double.Parse(priceAsString);

            _itemRepo.AddMenuItemToList(newMenuItem);
            Console.WriteLine("Menu Item now Added.");
        }

        //View All Menu Items that is Saved
        private void DisplayAllMenuItems()
        {
            Console.Clear();

            List<MenuItem> listOfMenuItems = _itemRepo.GetMenuItemList();

            foreach (MenuItem item in listOfMenuItems)
            {
                Console.WriteLine($"MealName: {item.MealName}, MealNumber: {item.MealNumber}, Price: {item.Price}");

            }
        }
        //View Menu Item by Meal Name
        private void DisplayMenuItemByMealName()
        {
            Console.Clear();
            //Prompt the user to give me a menu name
            Console.WriteLine("Enter the Meal Name of Item you'd like to view:");

            //Get the user's input
            string mealName = Console.ReadLine();

            //Find the item by that menu name
            MenuItem item = _itemRepo.GetItemByMealName(mealName);

            //Display said item if it isn't null
            if(item != null)
            {
                Console.WriteLine($"MealName: {item.MealName}\n" +
                    $"MealNumber: {item.MealNumber}\n" +
                    $"Description: {item.Description}\n" +
                    $"List of Ingredients: {item.ListOfIngredients}\n" +
                    $"Price: {item.Price}");
            }
            else
            {
                Console.WriteLine("No meal name found.");
            }
        }

        //Update Menu Item
        private void UpdateExistingMenuItem()
        {
            //Display all menu items
            DisplayAllMenuItems();

            //Ask for the meal name of the item to update
            Console.WriteLine("Enter the meal name of the item you'd like to update:");

            //Get that title
            string oldItem = Console.ReadLine();

            //we will build a new object
            MenuItem newMenuItem = new MenuItem();

            //Meal Number
            Console.WriteLine("Enter Menu Number:");
            string mealNumberAsString = Console.ReadLine();
            newMenuItem.MealNumber = int.Parse(mealNumberAsString);

            //Meal Name
            Console.WriteLine("Enter the Meal Name:");
            newMenuItem.MealName = Console.ReadLine();

            //Description
            Console.WriteLine("Enter the Description of Meal:");
            newMenuItem.Description = Console.ReadLine();

            //List of Ingredients  new List<string>()
            List<string> listOfIngredients = new List<string>();
            bool isDone = true;
            do
            {
                Console.WriteLine("Enter an ingredient or 'done' if there are no more ingredient to be added:");
                var ingredient = Console.ReadLine();
                if (ingredient.ToLower() != "done")
                {
                    listOfIngredients.Add(ingredient);
                    Console.WriteLine("Ingredient added to List");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                isDone = false;
            } while (isDone);
            Console.WriteLine("Ingredients list now complete.");

            //Price
            Console.WriteLine("Enter Price of Meal:");
            string priceAsString = Console.ReadLine();
            newMenuItem.Price = double.Parse(priceAsString);

            //Verify the update worked
            bool wasUpdated = _itemRepo.UpdateExistingItem(oldItem, newMenuItem);

            if (wasUpdated)
            {
                Console.WriteLine("Menu Item successfully updated.");
            }
            else
            {
                Console.WriteLine("Could not update Menu Item.");
            }
        }

        //Delete Menu Item
        private void DeleteExistingMenuItem()
        {
                DisplayAllMenuItems();

                //Get the MealName you want to delete
                Console.WriteLine("\nEnter the Meal Name you'd like to delete:");

                string input = Console.ReadLine();

                //Call the delete method
                bool wasDeleted = _itemRepo.RemoveItemFromList(input);

                //If the content was deleted, say so
                //Otherwise state it could not be deleted
                if (wasDeleted)
                {
                    Console.WriteLine("Menu Item was successfully deleted.");
                }
                else
                {
                    Console.WriteLine("Menu Item could not be deleted.");
                }
        }

        //Seed Method
        //Seed is at 5 min on Delete (read)
        //double check list of ingredients to seed and to View by Name

        //Don't forget to complete ReadME.for each
    }
}
