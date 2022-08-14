﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        [Category("UI")]
        //matches the text that we want displayed.
        public void PromptLabelIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Select a die:"));
            Assert.IsTrue(results.Any());
        }

        [Test]
        [Category("UI")]
        //query is going to return to us all of the elements on the page all of the elements on the screen that match this description.
        public void OptionsAreDisplayed()
        {
            Assert.IsTrue(app.Query(c => c.Marked("d4")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d6")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d8")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d10")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d12")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d20")).Any());
        }


        [Test]
        [Category("UI")]
        public void OptionsCanBeChecked()
        {
            app.Tap(c => c.Marked("d4"));

            Assert.IsTrue(app.Query(c =>
            c.Marked("d4")// Look for itens marked du
            .Invoke("isChecked")) // call the isChecked method of the RadioButton 
            .FirstOrDefault() // get the first result (there should only be one)
            .Equals(true) // check that the view is checked (isChecked true)
            );

            app.Tap(c => c.Marked("d6"));

            Assert.IsTrue(app.Query(c =>
            c.Marked("d4")// Look for itens marked du
            .Invoke("isChecked")) // call the isChecked method of the RadioButton 
            .FirstOrDefault() // get the first result (there should only be one)
            .Equals(true) // check that the view is checked (isChecked true)
            );

            app.Tap(c => c.Marked("d4"));

            Assert.IsTrue(app.Query(c =>
            c.Marked("d4")// Look for itens marked du
            .Invoke("isChecked")) // call the isChecked method of the RadioButton 
            .FirstOrDefault() // get the first result (there should only be one)
            .Equals(false) // check that the view is checked (isChecked true)
            );

        }

    }
}
