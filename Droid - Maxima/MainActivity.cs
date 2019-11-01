﻿
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Telephony;
using axistracking.Droid.CustomClass;
using Com.OneSignal;
using Firebase;

namespace axistracking.Droid
{
    [Activity(
        Label = "MXM Tracking"
        , Icon = "@drawable/ic_launcher"
        , Theme = "@style/MyTheme"
        , ConfigurationChanges = ConfigChanges.ScreenSize
                                | ConfigChanges.Orientation
        , ScreenOrientation = ScreenOrientation.Portrait
    )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            try
            {

                base.OnCreate(bundle);

                //Push Notification
                OneSignal.Current.StartInit("6967aeda-2235-4059-bfe2-e70281ebc90b")
                   .EndInit();

                global::Xamarin.Forms.Forms.Init(this, bundle);

                global::Xamarin.FormsGoogleMaps.Init(this, bundle);

                FirebaseOptions options = new FirebaseOptions.Builder()
                    .SetApplicationId("br.com.maxima.tracking")
                    .SetDatabaseUrl("https://mxm-tracking.firebaseio.com")
                    .SetGcmSenderId("757192689047")
                    .Build();

                var apps = Firebase.FirebaseApp.GetApps(this);
                if (apps.Count == 0)
                {
                    FirebaseApp.InitializeApp(this, options);
                }


                //Firebase.FirebaseApp.InitializeApp(this);
                //Firebase.Iid.FirebaseInstanceId.GetInstance(Firebase.FirebaseApp.InitializeApp(this));


                LoadApplication(new App(true, "maxima"));

            }
            catch (System.Exception)
            {
                Firebase.FirebaseApp.InitializeApp(this);
                Firebase.Iid.FirebaseInstanceId.GetInstance(Firebase.FirebaseApp.InitializeApp(this));

                LoadApplication(new App(true, "maxima"));
            }
        }
    

    }
}
