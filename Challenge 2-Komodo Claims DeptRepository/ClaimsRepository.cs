using Challenge_2_Komodo_Claims_DeptPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2_Komodo_Claims_DeptRepository
{
    public class ClaimsRepository
    {
        //GOAL: Create a ClaimRepository class that has proper methods.
        //Show Claims Agent a menu:
        //Choose a Menu Item:
        //  1.  See all Claims, 2. Take care of next claim, 3. Enter a new claim

        // For #1, a claim agent could see all items in the queue listed out like this:
        // ClaimID  Type    Description             Amount      DateOfAccident      DateOfClaim     IsValid
        //  1       Car     Car accident on 465.    $400.00         4/25/18             4/27/18     true
        //  2       Home    House fire in kitchen.  $4000.00        4/11/18             4/12/18     true
        //  3       Theft   Stolen pancakes.        $4.00           4/27/18             6/01/18     false

        //For #2, when a claim agent needs to deal with an item they see the next item in the queue.
        //  See Assignment for details
        //  Do you want to deal(process) with this claim now (y/n)? 
        //  When agent press 'y', the claim will be pulled off the top of the queue. If the agent
        //  presses 'n', it will go back to the main menu.

        //For #3, when a claim agent enters new data about a claim they will be prompted for questions about it: 
        //  See assignment for details
        //

        private List<Claim> _listOfClaims = new List<Claim>();

        //Create
        public  void AddClaimToList(Claim claim)
        {
            _listOfClaims.Add(claim);
        }


        //Read
        public List<Claim> GetClaimsList()
        {
            return _listOfClaims;
        }


        //Update
        public bool UpdateExistingClaim(int originalClaim, Claim newClaim)
        {
            //find the content
            Claim oldClaim = GetClaimByClaimID(originalClaim);

            //update the content
            if (oldClaim != null)
            {
                oldClaim.ClaimID = newClaim.ClaimID;
                oldClaim.TypeOfClaim = newClaim.TypeOfClaim;
                oldClaim.Description = newClaim.Description;
                oldClaim.ClaimAmount = newClaim.ClaimAmount;
                oldClaim.DateOfIncident = newClaim.DateOfIncident;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;
                oldClaim.IsValid = newClaim.IsValid;

                return true;
            }
            else
            {
                return false;
            }




        }

        //Delete
        public bool RemoveExistingClaimFromList (int claimID)
        {
            Claim claim = GetClaimByClaimID(claimID);
            
            if(claimID == 0)
            {
                return false;
            }

            int initialCount = _listOfClaims.Count;
            _listOfClaims.Remove(claim);

            if (initialCount > _listOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Helper
        public Claim GetClaimByClaimID (int claimID)
        {
            foreach(Claim Claim in _listOfClaims)
            {
                if(Claim.ClaimID == claimID)
                {
                    return Claim;
                }
            }
            return null;
        }

    }
}
