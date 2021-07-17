using Challenge_3_Komodo_Insurance_BadgesPOCO;
using Challenge_3_Komodo_Insurance_BadgesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3_Komodo_Insurance_Badges
{
    class ProgramUI
    {
        //Program will allow a security staff to do the following:
        //Create a new badge
        //Update Doors on the existing badge
        //Show a list w/all badge numbers and door access
        //(make sure to keep the responsibilities of your UI,
        //  your repo, and your tests separate.  Only your UI
        //  class should ever take input from the user

        private BadgeRepository _badgeRepo = new BadgeRepository();

        public void Run()
        {
            SeedList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                //Display options to the user

                Console.WriteLine("Select a menu option:\n" +
                    "1. Create new Badge\n" +
                    "2. View All Badges\n" +
                    "3. View Badge by BadgeID\n" +
                    "4. Update Doors on Existing Badge\n" +
                    "5. Delete All Doors from Existing Badge\n" +
                    "6. Exit");

                //Get the user's input
                string input = Console.ReadLine();

                //Evaluate user's input and act accordingly

                switch (input)
                {
                    case "1":
                        //Create new Badge"
                        CreateNewBadge();
                        break;
                    case "2":
                        //View All Badges"
                        DisplayAllBadges();
                        break;
                    case "3":
                        //View Badge by BadgeID
                        DisplayBadgeByBadgeID();
                        break;
                    case "4":
                        //Update Existing Badge
                        UpdateExistingBadge();
                        break;
                    case "5":
                        //Delete Existing Badge
                        DeleteExistingBadge();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Badge List now complete. Go forth, and conquer!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;

                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
       }
            //Create new Badge
            private void CreateNewBadge()
            {
                Console.Clear();
                Badge newBadge = new Badge();

                //ClaimID
                Console.WriteLine("Enter BadgeID Number:");
                string badgeIDAsString = Console.ReadLine();
                newBadge.BadgeID = int.Parse(badgeIDAsString);

                //List of doors to be added
                List<string> nameOfDoor = new List<string>();
                bool isDone = true;
                do
                {
                    Console.WriteLine("List a door that it needs access to or 'done' if there are no more doors to be added:");
                    var access = Console.ReadLine();
                    if (nameOfDoor.ToLower() != "done")
                    {
                        listOfDoors.Add(nameOfDoor);
                        Console.WriteLine("Door added to List");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    isDone = false;
                } while (isDone);
                Console.WriteLine("List of doors now complete.");


                newBadge.AccessibleDoors = listOfDoors;
          
                _badgeRepo.AddNewBadgeToList(newBadge);
                Console.WriteLine("Badge now Added.");
            }

            //View All Badges
            private void DisplayAllBadges()
            {
                Console.Clear();

                List<Badge> listOfBadges = _badgeRepo.GetBadges();

                foreach (Badge item in listOfBadges)
                {
                    Console.WriteLine($"BadgeID: {item.BadgeID}, Accessible Doors: {item.AccessibleDoors}");

                }
            }
            //View Badge by BadgeID
            private void DisplayBadgeByBadgeID()
            {
                Console.Clear();
                Badge newBadge = new Badge();
                //Prompt the user to give me a badgeID
                Console.WriteLine("Enter the BadgeID you'd like to view:");

                //Get the user's input
                string badgeIDAsString = Console.ReadLine();
                newBadge.BadgeID = int.Parse(badgeIDAsString);

                //Find the Badge by that BadgeID
                Badge badge = _badgeRepo.GetBadgeByID(badgeID);

                //Display said Badge if it isn't null
                if (badge != null)
                {
                    Console.WriteLine($"BadgeID: {badge.BadgeID}\n" +
                        $"List of Ingredients: {badge.listOfDoors}");
                }
                else
                {
                    Console.WriteLine("No meal name found.");
                }
            }

            //Update Menu Item
            private void UpdateExistingBadge()
            {
                Badge newBadge = new Badge();
                //Display all Badges
                DisplayAllBadges();

                //Ask for the BadgeID of the Badge to update
                Console.WriteLine("Enter the BadgeID of the Badge you'd like to update:");

                //Get that Badge
                string oldBadge = Console.ReadLine();

                //we will build a new object
                Badge badge = new Badge();

                //Meal Number
                Console.WriteLine("Enter BadgeID:");
                string badgeIDAsString = Console.ReadLine();
                newBadge.BadgeID = int.Parse(badgeIDAsString);

                //Verify the update worked
                bool wasUpdated = _badgeRepo.UpdateExistingBadge(oldBadge, newBadge);

                if (wasUpdated)
                {
                    Console.WriteLine("Badge Item successfully updated.");
                }
                else
                {
                    Console.WriteLine("Could not update Badge.");
                }
            }

            //Delete Badge
            private void DeleteExistingBadge()
            {
                DisplayAllBadges();

                //Get the BadgeID you want to delete
                Console.WriteLine("\nEnter the BadgeID of Badge you'd like to delete:");

                string input = Console.ReadLine();

                //Call the delete method
                
                bool wasDeleted = _badgeRepo.RemoveDoorsFromBadge(string.Parse(input));

                //If the content was deleted, say so
                //Otherwise state it could not be deleted
                if (wasDeleted)
                {
                    Console.WriteLine("Badge was successfully deleted.");
                }
                else
                {
                    Console.WriteLine("Badge could not be deleted.");
                }
            }

        private void SeedList()
        {

            Badge badge1 = new Badge(2, new List<string> { "A3", "C10" });
            Badge badge2 = new Badge(6, new List<string> { "B7", "C6" });
            Badge badge3 = new Badge(23, new List<string> { "A1", "D4" });


            _badgeRepo.AddNewBadgeToList(badge1);
            _badgeRepo.AddNewBadgeToList(badge2);
            _badgeRepo.AddNewBadgeToList(badge3);

        }
    
    }
}
