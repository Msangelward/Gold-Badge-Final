using Challenge_1_Komodo_CafePOCO;
using Challenge_1_Komodo_CafeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge_1_Komodo_CafeUnitTest
{
    [TestClass]
    public class MenuItemRepositoryTest
    {

        private MenuItemRepository _repo;
        private MenuItem _item;
        
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemRepository();
            
            _item = new MenuItem(3, "Cheeseburger Combo", "1/2 Angus Meat with our signature spices cooked to a perfect medium well", new List<string>()
            {
                "American and ColbyJack Cheese", "Lettuce", "Tomato", "Pickle"
            }, 8.99);

            _repo.AddMenuItemToList(_item);
        }


        //Test Add Method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            //Arrange --> Setting up the playing field
            MenuItem item = new MenuItem();
            item.MealName = "BLT";
            MenuItemRepository repository = new MenuItemRepository();

            //Act --> Get/Run the code we want to test
            repository.AddMenuItemToList(item);
            MenuItem itemFromDirectory = repository.GetItemByMealName("BLT");

            //Assert -->
            Assert.IsNotNull(itemFromDirectory);
        }

        //Test Update
        [TestMethod]
        public void UpdateExistingItem_ShouldReturnTrue()
        {
            //Arrange
            //TestInitialize
            MenuItem newMenuItem = new MenuItem(3, "Cheeseburger Combo", "1/2 Angus Meat with our signature spices cooked to a perfect medium well", new List<string>()
            {
                "American and ColbyJack Cheese", "Lettuce", "Tomato", "Pickle", "Onion", "Mayo"
            }, 8.99);

            //Act
            bool updateResult = _repo.UpdateExistingItem("Cheeseburger Combo", newMenuItem);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [DataRow("Cheeseburger Combo", true)]
        [DataRow("BLT", false)]
        public void UpdatingExistingContent_ShouldMatchGivenBool(string originalMealName, bool shouldUpdate)
        {
            //Arrange
            //TestInitialize
            MenuItem newMenuItem = new MenuItem(3, "Cheeseburger Combo", "1/2 Angus Meat with our signature spices cooked to a perfect medium well", new List<string>()
            {
                "American and ColbyJack Cheese", "Lettuce", "Tomato", "Pickle", "Onion", "Mayo"
            }, 8.99);


            //Act
            bool updateResult = _repo.UpdateExistingItem(originalMealName, newMenuItem);

            //Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        //TestDelete
        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            //Arrange(Test Initialize)

            //Act
            bool deleteResult = _repo.RemoveItemFromList(_item.MealName);

            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
