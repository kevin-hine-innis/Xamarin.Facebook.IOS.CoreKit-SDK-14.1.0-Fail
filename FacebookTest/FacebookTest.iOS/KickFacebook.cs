using FacebookTest.DependencyServices;
using FacebookTest.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(KickFacebook))]
namespace FacebookTest.iOS
{
    public class KickFacebook : IPlatformKickFacebook
    {
        public void KickIt()
        {
            var status = AppTrackingTransparency.ATTrackingManager.TrackingAuthorizationStatus;
            if (status == AppTrackingTransparency.ATTrackingManagerAuthorizationStatus.NotDetermined)
            {
                AppTrackingTransparency.ATTrackingManager.RequestTrackingAuthorization((_status) =>
                {
                    if (_status == AppTrackingTransparency.ATTrackingManagerAuthorizationStatus.Authorized)
                    {
                        Facebook.CoreKit.Settings.AdvertiserTrackingEnabled = true;

                        Facebook.CoreKit.AppEvents.LogEvent("Facebook thanks you.");
                        Facebook.CoreKit.AppEvents.LogEvent(Facebook.CoreKit.AppEventName.CompletedRegistration);
                    }
                    else
                    {
                        Facebook.CoreKit.Settings.AdvertiserTrackingEnabled = true; // Do it anyways...

                        Facebook.CoreKit.AppEvents.LogEvent("Facebook says yes.");
                        Facebook.CoreKit.AppEvents.LogEvent(Facebook.CoreKit.AppEventName.AchievedLevel);
                    }
                });
            }
            else if (status == AppTrackingTransparency.ATTrackingManagerAuthorizationStatus.Authorized)
            {
                Facebook.CoreKit.Settings.AdvertiserTrackingEnabled = true;
            }
        }
    }
}