using Challenge_3_Komodo_Insurance_BadgesPOCO;
using Challenge_3_Komodo_Insurance_BadgesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge_3_Komodo_Insurance_BadgesUnitTest
{
    [TestClass]
    public class BadgesRepoTest
    {

        private BadgeRepository _repo;
        private Badge _badge;

        //don't need to test constructors or objects,
        //just test your methods

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepository();

            _badge = new Badge(23, new List<string> { "A1", "D4", "D6" });
            _repo.AddNewBadgeToDictionary(_badge);
            _repo.AddNewBadgeToList(_badge);
            
        }

        //Test Add Methods
        public void AddBadgeToDictionary_ShouldGetNotNull()
        {
            //Arrange --> Setting up the playing field
            Badge badge = new Badge();
            badge.BadgeID = 123;
            BadgeRepository repository = new BadgeRepository();

            //Act --> Get/Run the code we want to test
            repository.AddNewBadgeToDictionary(badge);
            Badge badgeFromDictionary = repository.GetBadgeByID(123);

            //Assert -->
            Assert.IsNotNull(badgeFromDictionary);
        }

        public void AddBadgeToList_ShouldGetNotNull()
        {
            //Arrange --> Setting up the playing field
            Badge badge = new Badge();
            badge.BadgeID = 123;
            BadgeRepository repository = new BadgeRepository();

            //Act --> Get/Run the code we want to test
            repository.AddNewBadgeToList(badge);
            Badge badgeFromList = repository.GetBadgeByID(123);

            //Assert -->
            Assert.IsNotNull(badgeFromList);

        }

        //Test Read Method
        [TestMethod]
        public void Read_ShouldReturnBadges() 
        {
            //Arrange
            Dictionary<int, List<string>> badge = _repo.GetDictionary();

            //Assert
            Assert.IsNotNull(badge);
        }


        [TestMethod]
        public void UpdateExistingBadge_ShouldReturnTrue()
        {
            //Arrange
            Badge newBadge = new Badge(234, new List<string> { "A3", "D7" });

            //Act
            bool updateExistingBadge = _repo.UpdateExistingBadge(432, newBadge);

            //Assert
            Assert.IsTrue(updateExistingBadge);


        }

        [TestMethod]
        public void DeleteExistingBadge_ShouldReturnTrue()
        {
            //Arrange(Test Initialize)

            //Act
            bool deleteBadge = _repo.RemoveDoorsFromBadge(_badge.BadgeID);

            //Assert
            Assert.IsTrue(deleteBadge);
        }

        [TestMethod]
        public void GetBadgebyID_ShouldGetNotNull()
        {
            //Arrange
            Badge badge = _repo.GetBadgeByID(456);
            
            //Act
            

            Assert.IsNotNull(badge);
        }
    }
}
