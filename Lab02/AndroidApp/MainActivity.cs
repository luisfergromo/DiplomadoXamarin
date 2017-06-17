﻿using Android.App;
using Android.OS;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private async void Validate()
        {
            SALLab02.ServiceClient ServiceClient = new SALLab02.ServiceClient();
            string StudentEmail = "...@iteso.mx";
            string Password = "....";
            string myDevice = 
                Android.Provider.Settings.Secure.GetString(
                    ContentResolver,
                    Android.Provider.Settings.Secure.AndroidId);
            SALLab02.ResultInfo Result = 
                await ServiceClient.ValidateAsync(
                    StudentEmail, Password, myDevice);

            Android.App.AlertDialog.Builder Builder = new AlertDialog.Builder(this);
            AlertDialog Alert = Builder.Create();
            Alert.SetTitle("Resultado de la verificación");
            Alert.SetIcon(Resource.Drawable.Icon);
            Alert.SetMessage(
                $"{Result.Status}\n{Result.Fullname}\n{Result.Token}");
            Alert.SetButton("Ok", (s, ev) => { });
            Alert.Show();
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Validate();

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }
}

