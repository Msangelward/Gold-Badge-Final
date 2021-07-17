using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2_Komodo_Claims_DeptPOCO
{
    public class Claim
    {
        //GOAL: Create Claim Class with properties, constructors, and any necessary fields
        //Claim has the following properties:
        //      ClaimID, ClaimType, Description, ClaimAmount, DateOfClaim, DateOfIncident, IsValid
        //      ClaimType: Car, Home, Theft

        public enum ClaimType
        {
            Car,
            Home,
            Theft,
            Other
        }
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public String Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }
        public Claim(int claimID, ClaimType typeOfClaim, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }




    }
}
