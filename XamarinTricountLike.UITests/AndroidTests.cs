using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Utils;

namespace XamarinTricountLike.UITests
{

    [TestFixture]
    public class AndroidTests : CrossPlatformTests
    {
        [SetUp]
        public override void SetUp()
        {
            // an API key is required to publish on Xamarin Test Cloud for remote, multi-device testing
            App = ConfigureApp.Android.ApkFile(PathToApk).StartApp();
        }

        public string PathToApk { get; set; }


        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var fi = new FileInfo(currentFile);
            string dir = fi.Directory.Parent.Parent.Parent.FullName;
            // update the project name (Android) and output filename (UITestDemo.Android) for each app
            PathToApk = Path.Combine(dir, "XamarinTricountLike", "XamarinTricountLike.Droid", "bin", "Release",
                "zuehlke.muts.camp.apk");
        }
    }
}