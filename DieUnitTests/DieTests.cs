using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceRoller.Models;
using FluentAssertions;

namespace DieUnitTests
{
    [TestClass]
    public class DieTests
    {
        private Die d = new Die();

        //By instatntiang the die class check if the class exists or not
        [TestMethod]
        public void DieNullTest()
        {
            d.Should().NotBeNull();
        }


    }
}
