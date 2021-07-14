using Challenge_1_Komodo_CafePOCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge_1_Komodo_CafeUnitTest
{
    [TestClass]
    public class MenuItemTest
    {
        [TestMethod]
        public void SetMealName_ShouldSetCorrectString()
        {
            MenuItem item = new MenuItem();

            item.MealName = "BLT";

            string expected = "BLT";
            string actual = item.MealName;

            Assert.AreEqual(expected, actual);
        }
    }
}
