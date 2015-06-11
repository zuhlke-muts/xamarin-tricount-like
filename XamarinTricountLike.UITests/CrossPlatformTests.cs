﻿using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamarinTricountLike.UITests
{
    public class CrossPlatformTests
    {
        protected IApp App;
            
        static readonly Func<AppQuery, AppQuery> AddButton = c => c.All().Property("Text", "Add");
        static readonly Func<AppQuery, AppQuery> SaveButton = c => c.Marked("SaveButton");
        
        [SetUp]
        public virtual void SetUp()
        {
            Assert.Ignore();
        }

        /// <summary>
        /// This test checks the value of a Label, presses a AddButton, then checks the Label text again
        /// </summary>
        [Test()]
        public void TestCase()
        {
            // Arrange
            
            // Act
            App.Tap(AddButton);

            // Assert
            var result = App.Query(SaveButton);
            Assert.IsTrue(result.Any(), "SaveButton not shown");
        }
    }
}