using Challenge_2_Komodo_Claims_DeptPOCO;
using Challenge_2_Komodo_Claims_DeptRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Challenge_2_Komodo_Claims_DeptPOCO.Claim;

namespace Challenge_2_Komodo_Claims_Dept
{
    class ProgramUI
    {
        //GOAL: Create a Program File that allows a claims mgr to manage items in the list of claims.

        private ClaimsRepository _claimRepo = new ClaimsRepository();

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

            //ClaimType
            Console.WriteLine("Enter the Number for the Type of Claim it is\n" +
                    "1. Car\n" +
                    "2. Home\n" +
                    "3. Theft");
            string claimTypeAsString = Console.ReadLine();
            newClaim.TypeOfClaim = (ClaimType)int.Parse(claimTypeAsString);
                      

            //Description
            Console.WriteLine("Enter the Description of Claim:");
            newClaim.Description = Console.ReadLine();

            //ClaimAmount
            Console.WriteLine("Enter Amount of Claim");
            newClaim.ClaimAmount = int.Parse(Console.ReadLine());

            //Date of Incident
            bool dateOfIncident = false;
            while (!dateOfIncident);
            {
                Console.WriteLine("Enter Date of Incident");
                string mDateTime = Console.ReadLine();
                if (!DateTime.TryParse(mDateTime, out DateTime incidentDate))
                {
                    Console.WriteLine("Not a Valid Claim");
                }
                else
                {
                    newClaim.DateOfIncident = incidentDate;
                    dateOfIncident = true;
                }
                //Date of Claim

                bool dateOfClaim = false;
                while (!dateOfClaim)
                {
                    Console.WriteLine("Enter Date of Claim");
                    string inputDateOfClaim = Console.ReadLine();
                    if (!DateTime.TryParse(inputDateOfClaim, out DateTime newdateOfClaim))
                    {
                        Console.WriteLine("Not a valid input");
                    }
                    else
                    {
                        newClaim.DateOfClaim = newdateOfClaim;
                        dateOfClaim = true;
                    }
                }
            }

            //IsValid
            bool isValid = false;
            while (!isValid)
            {
                bool isNotValid = false;
                var timeSpan2 = 30;
                var validClaim = newClaim.DateOfClaim - newClaim.DateOfIncident;
                var timeSpan = validClaim.TotalDays;
                if (timeSpan > timeSpan2)
                {
                    newClaim.IsValid = isNotValid;
                    isValid = true;
                }
            }

            _claimRepo.AddClaimToList(newClaim);
            Console.WriteLine("Claim now Added.");
        }

        //ViewAllClaims
        private void DisplayAllClaims()
        {
            Console.Clear();
            Queue<Claim> claims = _claimRepo.GetClaimsList();
            string[] headerColumns = { "Claim ID", "Claim Type", "Claim Description", "Claim Amount", "Date of Incident", "Date of Claim", "IsValidClaim" };
            Console.WriteLine("{0,10} {1,20} {2,30} {4,40} {5,25} {6, 35}", headerColumns[0], headerColumns[1], headerColumns[2], headerColumns[3], headerColumns[4], headerColumns[5], headerColumns[6] );

            foreach (var claim in claims)
            {
                int claimID = claim.ClaimID;
                Claim.ClaimType type = claim.TypeOfClaim;
                string description = claim.Description;
                double amountOfClaim = claim.ClaimAmount;
                DateTime dateOfIncident = claim.DateOfIncident;
                DateTime dateOfClaim = claim.DateOfClaim;
                bool isValid = claim.IsValid;
                Console.WriteLine($"{claimID,10}, {type,20} {description,30} {amountOfClaim,20} {dateOfIncident,30} {isValid,20}");
            }
        }

        //Process Next Claim
        private void ProcessNextClaim()
        {
            Queue<Claim> claims = _claimRepo.GetClaimsList();
            Claim claim = claims.Peek();
            Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                $"Claim Type: {claim.TypeOfClaim}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount of Claim: {claim.ClaimAmount}\n" +
                $"Date of Incident: {claim.DateOfIncident}\n" +
                $"Date of Claim: {claim.DateOfClaim}|n" +
                $"Is this a Valid Claim? {claim.IsValid} ");
            string input = Console.ReadLine();
            if (input == "y" || input == "Y")
            {
                claims.Dequeue();
                Menu();
            }
            else if (input == "n" || input == "N")
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Please Enter a Valid Response");
            }
        }

        private void SeedList()
        {
            Claim claim1 = new Claim(1, Claim.ClaimType.Car, "Frontend Collision", 4000, DateTime.Parse("2021 / 03 / 02"), DateTime.Parse("2020 / 02 / 27"), true);
            Claim claim2 = new Claim(21, Claim.ClaimType.Home, "Hail Damange on Roof", 9000, DateTime.Parse("2020 / 12 / 25"), DateTime.Parse("2020 / 12 / 27"), true);
            Claim claim3 = new Claim(56, Claim.ClaimType.Car, "BreakIn, Driver Side Door", 1200, DateTime.Parse("2021 / 01 / 02"), DateTime.Parse("2021 / 02 / 15"), false);

            _claimRepo.AddClaimToList(claim1);
            _claimRepo.AddClaimToList(claim2);
            _claimRepo.AddClaimToList(claim3);
        }

    }
}
