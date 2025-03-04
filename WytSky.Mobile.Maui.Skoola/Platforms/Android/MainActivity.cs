using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.AppCompat.App;
using AndroidX.Core.App;
using AndroidX.Core.Content;

namespace WytSky.Mobile.Maui.Skoola
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // to disable dark mode on Android from 31 and above
            var uiModeManager = (UiModeManager)GetSystemService(UiModeService);
            uiModeManager.SetApplicationNightMode(1);

            //to disable dark mode under Android 31
            ((AppCompatActivity)this).Delegate.SetLocalNightMode(AppCompatDelegate.ModeNightNo);

            #region Run time permissions
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.PostNotifications) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new[] { Manifest.Permission.PostNotifications }, 0);
            }
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadContacts) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new[] { Manifest.Permission.ReadContacts }, 1);
            }
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteContacts) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new[] { Manifest.Permission.WriteContacts }, 2);
            }
            #endregion
        }
    }
}
