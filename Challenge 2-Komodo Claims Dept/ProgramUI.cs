using Challenge_2_Komodo_Claims_DeptPOCO;
using Challenge_2_Komodo_Claims_DeptRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2_Komodo_Claims_Dept
{
    class ProgramUI
    {
        //GOAL: Create a Program File that allows a claims mgr to manage items in the list of claims.

        private ClaimsRepository _claimRepo = new ClaimsRepository();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                //Display options to the user

                Console.WriteLine("Select a menu option:\n" +
                    "1. Create new Claim\n" +
                    "2. View All Claims\n" +
                    "3. Process Next Claim\n" +
                    "4. Update Existing Claim\n" +
                    "5. Delete Existing Claim\n" +
                    "6. Exit");

                //Get the user's input
                string input = Console.ReadLine();

                //Evaluate user's input and act accordingly

                switch (input)
                {
                    case "1":
                        //Create new Claim"
                        CreateNewClaim();
                        break;
                    case "2":
                        //View All Claims"
                        DisplayAllClaims();
                        break;
                    case "3":
                        //ProcessNextClaim
                        ProcessNextClaim();
                        break;
                    case "4":
                        //Update Existing Claim
                        UpdateClaim();
                        break;
                    case "5":
                        //Delete Existing Claim
                        DeleteExistingClaim();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Claims are complete. Go forth, and be destressed!");
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
        //Create new Claim
        private void CreateNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            //ClaimID
            Console.WriteLine("Enter The ClaimID Number:");
            string claimIDAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(claimIDAsString);

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
    }
}
