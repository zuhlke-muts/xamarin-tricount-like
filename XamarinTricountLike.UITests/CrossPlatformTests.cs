using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamarinTricountLike.UITests
{
    public class CrossPlatformTests
    {
        protected IApp App;
            
		static readonly Func<AppQuery, AppQuery> SaveButton = c => c.Marked("SaveButton");
        
        [SetUp]
        public virtual void SetUp()
        {
			Assert.Ignore("This class requires a platform-specific bootstrapper to override the `SetUp` method");
        }

        /// <summary>
        /// This test checks the value of a Label, presses a AddButton, then checks the Label text again
        /// </summary>
        [Test()]
        public void TestCase()
        {
            // Arrange
            
            // Act
			App.Tap(ToolbarAddButton());

            // Assert
			var result = App.WaitForElement(SaveButton, "timeout waiting for properties view");
            Assert.IsTrue(result.Any(), "SaveButton not shown");
        }

		public virtual Func<AppQuery, AppQuery> ToolbarAddButton() {
			throw new NotImplementedException();
		}

		[Test]
		public void FirstUnitTest()
		{
			//Uncomment to start the console to watch the view tree (type tree)
			//App.Repl();
		}
    }
}