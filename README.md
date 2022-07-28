# A failed attempt to update Xamarin.Facebook.IOS to work on iOS 15.5.

You may have noticed the official Xamarin FacebookComponent Nugets are using Facebook SDK 12.2.0.
See: https://github.com/xamarin/FacebookComponents

Unfortunately, that version of the Facebook SDK can't log events on most Apple phones (Any phone running >= iOS 14?).

So, I updated FacebookComponents project to pull down and build the Xamarin Nugets using the 14.1.0 version of the Facebook SDKs (the latest at this time).
You can see my update here: https://github.com/kevin-hine-innis/FacebookComponents

This project does log events on iOS 13.7, but it does NOT log events on iOS 15.5.
I have no idea if this is because my Nuget is bad, or because I am not interacting with Facebook correctly (perhaps a combination of both?).

If you decide to use this Nuget, or the Nugets generated in my fork, the API definitions were not updated. I verified the definitions used in this project, but many of the rest are certainly missing or broken.

If you know what I am doing wrong, I welcome the help.

Note: The Facebook docs say you have to request tracking permission from the user. I believe that is only for advertiser tracking events (AdvertiserTrackingEnabled), and not the auto logs events. Either way, I have tried both ways and I am simply unable to get events from iOS 15.5.


