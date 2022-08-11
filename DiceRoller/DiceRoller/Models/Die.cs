using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRoller.Models
{
    public class Die
    {
        /**
         * private modifier to indicate variables are not intended to be publicly
         * accessible
         * but should be accessible publicly via getter and setters.
         */
        private string diceType { get; set; }
        private int sidesNumber { get; set; }
        private int currentUpSide { get; set; }

        // The default constructor is the no-argument constructor uninitialised fields
        // will be set to their default values.
        public Die()
        {
            diceType = "d6";
            sidesNumber = 6;
            rollDice(); // calling the rollDice to get value for current side up
        }

        // A parameterized constructor to initialize fields of the class with our own
        // values. Passing number of sides as a parameter
        public Die(int sidesVal)
        {
            diceType = "d" + sidesVal;
            sidesNumber = sidesVal;
            rollDice();
        }

        //set the value for  currentUpSide side to the  newUpSide
        public void setCurrentUpSide(int newUpSide) 
        {
            if (sidesNumber >= 1 && newUpSide <= sidesNumber)
                currentUpSide = newUpSide;
        }

        /**
         * Method to generate Random values to get the roll for a dice
         * and stores it in currentUpSide variable
         */
        public void rollDice()
        {
            Random r = new Random();
            currentUpSide = r.Next(sidesNumber) + 1;
        }

       
        /**
         * Getter
         * @return number of sides of dice
         */
        public int getSidesNumber()
        {
            return sidesNumber;
        }

        /**
         * Getter
         * @return current up Side
         */
        public int getCurrentUpSide()
        {
            return currentUpSide;
        }

        /**
         * Getter
         * @return returns the dice type
         */
        public string getDiceType()
        {
            return diceType;
        }

    }
}
