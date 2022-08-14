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
         * with instatnce of the Die class check if the class exists or not
         * @TestMethod
         */
        [TestMethod]
        public void DieNullTest()
        {
            d.Should().NotBeNull();
        }

        /**
        * with instatnce of Die class check that all default values are assigned or not 
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

        [TestMethod]
        public void RollSetsSideCorrectly()
        {
           for (int i = 0; i <1000; i++)
           {
                d.rollDice();
                d.getCurrentUpSide().Should().BeInRange(1, 6);
            }

        }

        /**
       * By instatntiang the die class as new object check that all the setters for Die class  
       * on the getter methods of Die class
       * @TestMethod
       */
        [TestMethod]
        [DataRow(3, "d3")] 
        [DataRow(4, "d4")]
        [DataRow(8, "d8")]
        [DataRow(10, "d10")]
        [DataRow(12, "d12")]
        [DataRow(20, "d20")]
        public void DieHasCustomSides(int sides, string name)
        {
            Die die = new Die(sides);
            die.getDiceType().Should().Be(name);
            die.getSidesNumber().Should().Be(sides);
            die.getCurrentUpSide().Should().BeInRange(1, sides);
        }

        /**
        * By instatntiang the die class as new object check that all the setters for Die class  
        * on the getter methods of Die class
        * @TestMethod
        */
        [TestMethod]
        [DataRow(3, 2)]
        [DataRow(4, 2)]
        [DataRow(8, 2)]
        [DataRow(10, 2)]
        [DataRow(12, 2)]
        [DataRow(20, 2)]
        public void SetSideUpChangeSide(int sides, int newSides)
        {
            Die die = new Die(sides);
            die.setCurrentUpSide(newSides);
            die.getSidesNumber().Should().Be(newSides);
        }

        /**
        * By instatntiang the die class as new object check that all the setters for Die class  
        * on the getter methods of Die class
        * @TestMethod
        */
       /* [TestMethod]
        [DataRow(3, 2)]
        [DataRow(4, 2)]
        [DataRow(8, 2)]
        [DataRow(10, 2)]
        [DataRow(12, 2)]
        [DataRow(20, 2)]
        public void SetSideUpSetsValidSide(int sides, int newSides)
        {
            Die die = new Die(sides);
            die.setCurrentUpSide(newSides);
            die.getSidesNumber().Should().BeInRange(1, sides);
        }*/

        [TestMethod]
        public void DefaultGetDiceTypeValue()
        {
            d.getDiceType().Should().BeOfType<string>();
            d.getDiceType().Should().Be("d6");
        }



        [TestMethod]
        public void DefaultGetSidesNumber()
        {

            d.getSidesNumber().Should().Be(6);
        }



        [TestMethod]
        public void DefaultGetCurrentUpSide()
        {
            d.getCurrentUpSide().Should().BeInRange(1, 6);
        }
    }
}
