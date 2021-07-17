using Challenge_2_Komodo_Claims_DeptPOCO; 
using Challenge_2_Komodo_Claims_DeptRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Challenge_2_Komodo_Claims_DeptPOCO.Claim;

namespace Challenge_2_Komodo_Claims_DeptUnitTest
{
    [TestClass]
    public class ClaimRepositoryTest
    {

        private ClaimsRepository _repo;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepository();

            _claim = new Claim(23, ClaimType.Car, "Rearended", 4000, DateTime.Parse("2021/01/01"), DateTime.Parse("2021/01/07"), true);
            _repo.AddClaimToList(_claim);
        }


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

        [TestMethod]
        public void Update_ShouldReturnTrue()
        {
            Claim newClaim = new Claim(34, ClaimType.Car, "Front Collision", 6000, DateTime.Parse("2021/06/14"), DateTime.Parse("2021/06/28"),true);
            bool shouldUpdate = _repo.UpdateExistingClaim(2, newClaim);

            Assert.IsTrue(shouldUpdate);
        }

        [TestMethod]
        public void Delete_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveExistingClaimFromList(_claim.ClaimID);
            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void Helper_ShouldGetNotNull()
        {
            Claim claim = new Claim(23, ClaimType.Car, "Rarended", 4000, DateTime.Parse("2021/01/01"), DateTime.Parse("2021/01/07"), true);
            _repo.GetClaimByClaimID(1);

            Assert.IsNotNull(claim);
        }

    }
}
