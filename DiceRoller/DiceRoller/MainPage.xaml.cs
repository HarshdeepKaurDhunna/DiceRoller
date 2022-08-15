using DiceRoller.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace DiceRoller
{
    public partial class MainPage : ContentPage
    {
        string selectedVal;
        int sides = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        /*
         * Get radio button value on selected
         * @return string selectedVal
        */
        void OnRadioButtonChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            selectedVal = (string)button.Content;
            
            
        }

        /*
         * Get Result of two die rolling by instantiating 
         * @return result2 label text
        */
        public void DisplayTwo(object sender, EventArgs args)
        {
            if (checkDieSelected())// to checks if die is selected or not
            {
                Die d1 = new Die(sides);
                Die d2 = new Die(sides);
                string getCurrentD1Val = d1.getCurrentUpSide().ToString();
                string getCurrentD2Val = d2.getCurrentUpSide().ToString();
                result2.IsVisible = true; // set result2 label
                result2.Text = $"{selectedVal} First Up side: {getCurrentD1Val} ;  Second Up Side: {getCurrentD2Val}  ";
            }
           


        }

        /*
         * Get Result of one die rolling by instantiating 
         * @return result1 label text
        */
        public void DisplayResultOne(object sender, EventArgs args)
        {
            if (checkDieSelected()) // to checks if die is selected or not
            {
                result2.IsVisible = false;
                Die d = new Die(sides);
                string getCurrentD1Val = d.getCurrentUpSide().ToString();
                result1.Text = $"{selectedVal} Up Side: {getCurrentD1Val} ";
            }
        }

        /*
         * check if value selected or not
        */
        public bool checkDieSelected()
        {
            if (string.IsNullOrEmpty(selectedVal))
            {
                result1.Text = $"Please Select a Die Type";
                return  false;
            }
            else
            {
                string intVal = selectedVal;
                Int32.TryParse(intVal.Replace("d", ""), out sides);
                return true;
            }
        }
        
    }
}
