using Android.App;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var Helper = new SharedProject.MySharedCode();
            new AlertDialog.Builder(this)
                .SetMessage(Helper.GetFilePath("demo.dat"))
                .Show();
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }
}

