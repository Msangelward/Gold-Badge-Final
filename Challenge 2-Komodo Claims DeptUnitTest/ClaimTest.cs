using Challenge_2_Komodo_Claims_DeptPOCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge_2_Komodo_Claims_DeptUnitTest
{
    [TestClass]
    public class ClaimTest
    {
        [TestMethod]
        public void SetClaimID_ShouldSetCorrectInt()
        {
            Claim claim = new Claim();

            claim.ClaimID = 3214;

            int expected = 3214;
            int actual = claim.ClaimID;

            Assert.AreEqual(expected, actual);
        }
    }
}
