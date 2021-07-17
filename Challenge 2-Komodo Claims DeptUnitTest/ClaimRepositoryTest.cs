using Challenge_2_Komodo_Claims_DeptPOCO; 
using Challenge_2_Komodo_Claims_DeptRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge_2_Komodo_Claims_DeptUnitTest
{
    [TestClass]
    public class ClaimRepositoryTest
    {

        //Test Add Method
        [TestMethod]
        public void AddToList_ShouldGetAnythingButZero()
        {
            //Arrange
            Claim claim = new Claim();
            claim.ClaimID = 3214;
            ClaimsRepository repository = new ClaimsRepository();

            //Act
            repository.AddClaimToList(claim);
            Claim claimFromDirectory = repository.GetClaimByClaimID(3214);


            //Assert
            Assert.IsNotNull(claimFromDirectory);
        }
    }
}
