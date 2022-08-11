using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceRoller.Models;
using FluentAssertions;

namespace DieUnitTests
{
    [TestClass]
    public class DieTests
    {
        private Die d = new Die();

        /**
         * By instatntiang the die class check if the class exists or not
         * @TestMethod
         */
        [TestMethod]
        public void DieNullTest()
        {
            d.Should().NotBeNull();
        }

        /**
        * By instatntiang the die class check that all default values are assigned or not 
        * on the getter methods of Die class
        * @TestMethod
        */
        [TestMethod]
        public void DieHasAllDefaultValues() 
        {
            d.getDiceType().Should().Be("d6"); //passing parameter with "d6" as the name
            d.getSidesNumber().Should().Be(6);//passing parameter 6 as the number of sides
            d.getCurrentUpSide().Should().BeInRange(1, 6); // passing 2 parameter 1 and 6 as the number of sides to roll the dice 
        }
    }
}
