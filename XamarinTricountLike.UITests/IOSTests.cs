using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamarinTricountLike.UITests
{

    [TestFixture]
    public class IOSTests : CrossPlatformTests
    {
        public string PathToIPA { get; set; }

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            FileInfo fi = new FileInfo(currentFile);
            string dir = fi.Directory.Parent.Parent.Parent.FullName;
            // update the project name (iOS) and output filename (UITestDemoiOS) for each app
			PathToIPA = Path.Combine(dir, "XamarinTricountLike/XamarinTricountLike.iOS", "bin", "iPhoneSimulator", "Debug", "XamarinTricountLikeiOS.app");
        }

        [SetUp]
        public override void SetUp()
        {
            // an API key is required to publish on Xamarin Test Cloud for remote, multi-device testing
            App = ConfigureApp.iOS.AppBundle(PathToIPA).StartApp();
        }

		public override Func<AppQuery, AppQuery> ToolbarAddButton() {
			return c => c.Class ("UIButton").Marked("Add");
		}
    }
}
