using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Utils;

namespace XamarinTricountLike.UITests
{
    public class WaitTimes : IWaitTimes
    {
        public TimeSpan WaitForTimeout
        {
            get { return TimeSpan.FromSeconds(120); }
        }

        public TimeSpan GestureWaitTimeout
        {
            get { return TimeSpan.FromSeconds(10); }
        }
    }

    [TestFixture]
    public class AndroidTests : CrossPlatformTests
    {
        [SetUp]
        public void SetUp()
        {
            // an API key is required to publish on Xamarin Test Cloud for remote, multi-device testing
            App = ConfigureApp.Android.ApkFile(PathToApk).DeviceSerial("019314f0").WaitTimes(new WaitTimes()).StartApp();
        }

        public string PathToApk { get; set; }


        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var fi = new FileInfo(currentFile);
            string dir = fi.Directory.Parent.Parent.Parent.FullName;
            // update the project name (Android) and output filename (UITestDemo.Android) for each app
            PathToApk = Path.Combine(dir, "XamarinTricountLike", "XamarinTricountLike.Droid", "bin", "Debug",
                "zuehlke.muts.camp.apk");
        }
    }
}