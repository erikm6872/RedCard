using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Graphics;

namespace RedCard
{
    [Activity(Label = "RedCard", MainLauncher = true, Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Disable screen dim/sleep
            Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);

            // Set screen brightness to 100%
            var attributesWindow = new WindowManagerLayoutParams();
            attributesWindow.CopyFrom(Window.Attributes);
            attributesWindow.ScreenBrightness = 1f;
            Window.Attributes = attributesWindow;


            var view = FindViewById<SurfaceView>(Resource.Id.surfaceView1);

            // Set initial background color to green 
            view.SetBackgroundColor(Color.LimeGreen);
            var isGreen = true;
            
            // Change color when screen is clicked
            view.Click += delegate {
                if(isGreen)
                    view.SetBackgroundColor(Color.Red);
                else
                    view.SetBackgroundColor(Color.LimeGreen);
                isGreen = !isGreen;
            };

            // Display About message when screen is long pressed
            view.LongClick += delegate
            {
                var context = this.ApplicationContext;
                var version = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;
                using (var builder = new AlertDialog.Builder(this))
                {
                    builder.SetMessage("RedCard v" + version + "\nErik C. McLaughlin\nhttps://erikcmclaughlin.com");
                    builder.SetTitle("About");
                    builder.Create();
                    builder.Show();
                }
                
            };
        }

    }
}

