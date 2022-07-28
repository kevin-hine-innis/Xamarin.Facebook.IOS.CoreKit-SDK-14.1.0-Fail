using Foundation;
using UIKit;

namespace FacebookTest.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate you.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            Facebook.CoreKit.Settings.EnableLoggingBehavior(Facebook.CoreKit.LoggingBehavior.Informational);
            Facebook.CoreKit.Settings.EnableLoggingBehavior(Facebook.CoreKit.LoggingBehavior.AppEvents);
            Facebook.CoreKit.Settings.EnableLoggingBehavior(Facebook.CoreKit.LoggingBehavior.NetworkRequests);

            Facebook.CoreKit.Settings.AdvertiserIdCollectionEnabled = false;
            Facebook.CoreKit.Settings.AdvertiserTrackingEnabled = false; // This should be the only thing you need to prompt for?
            Facebook.CoreKit.Settings.AutoLogAppEventsEnabled = true; // Shouldn't this work without user permission? As far as I know these are not intended to track the user, just launches and installs.
            
            Facebook.CoreKit.Settings.AppId = NSBundle.MainBundle.ObjectForInfoDictionary("FacebookAppID").ToString();
            Facebook.CoreKit.Settings.ClientToken = NSBundle.MainBundle.ObjectForInfoDictionary("FacebookClientToken").ToString();
            Facebook.CoreKit.Settings.DisplayName = NSBundle.MainBundle.ObjectForInfoDictionary("FacebookDisplayName").ToString();

            // This method verifies if you have been logged into the app before, and keep you logged in after you reopen or kill your app.
            bool result =  Facebook.CoreKit.ApplicationDelegate.SharedInstance.FinishedLaunching(app, options);
            // Result is always false. I don't know why.

            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
}

