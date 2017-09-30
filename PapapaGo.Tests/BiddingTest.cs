using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PapapaGo.Models.Bidding;

namespace PapapaGo.Tests
{
    [TestClass]
    public class BiddingTest
    {
        [TestMethod]
        public void Amount_100_Multiple_2_MakeMoney_Should_Be_20()
        {
            var target = new Bidding();
            target.Amount = 100;
            target.Multiple = 2;
            var expectedResult = 20m;

            Assert.AreEqual(expectedResult, target.MakeMoney);
        }

        [TestMethod]
        public void Amount_100_Multiple_2_Should_Be_200()
        {
            var target = new Bidding();
            target.Amount = 100;
            target.Multiple = 2;
            var expectedResult = 200;

            Assert.AreEqual(expectedResult, target.DisplayAmount);
        }
    }
}