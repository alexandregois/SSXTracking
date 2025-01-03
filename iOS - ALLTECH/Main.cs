﻿using System;
using Microsoft.AppCenter.Crashes;
using UIKit;

namespace axistracking.iOS
{
	public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            try
            {
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (Exception ex)
			{

                Crashes.TrackError(ex);

                Console.WriteLine ("Main ex.Message: " + ex.Message);

				Console.WriteLine ("Main ex.InnerException: " + ex.InnerException);
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }

        }
    }
}
