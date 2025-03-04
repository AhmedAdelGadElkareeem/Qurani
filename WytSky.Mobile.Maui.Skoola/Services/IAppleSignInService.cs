using System;
using System.Collections.Generic;
using System.Text;
//using Xamarin.AppleSignIn;

namespace WytSky.Mobile.Maui.Skoola.Services
{
    public interface IAppleSignInService
    {
        bool Callback(string url);
        bool IsIos13();
        // Task<Xamarin.AppleSignIn.AppleAccount> SignInAsync();
    }

    //public class WebAppleSignInService : IAppleSignInService
    //{
    //    // IMPORTANT: This is what you register each native platform's url handler to be
    //    public const string CallbackUriScheme = "xamarinformsapplesignin";
    //    public const string InitialAuthUrl = "http://local.test:7071/api/applesignin_auth";

    //    string currentState;
    //    string currentNonce;

    //    System.Threading.Tasks.TaskCompletionSource<Models.AppleSignIn.AppleAccount> tcsAccount = null;

    //    public bool Callback(string url)
    //    {
    //        // Only handle the url with our callback uri scheme
    //        if (!url.StartsWith(CallbackUriScheme + "://"))
    //            return false;

    //        // Ensure we have a task waiting
    //        if (tcsAccount != null && !tcsAccount.Task.IsCompleted)
    //        {
    //            try
    //            {
    //                // Parse the account from the url the app opened with
    //                var account = Models.AppleSignIn.AppleAccount.FromUrl(url);

    //                // IMPORTANT: Validate the nonce returned is the same as our originating request!!
    //                if (!account.IdToken.Nonce.Equals(currentNonce))
    //                    tcsAccount.TrySetException(new InvalidOperationException("Invalid or non-matching nonce returned"));

    //                // Set our account result
    //                tcsAccount.TrySetResult(account);
    //            }
    //            catch (Exception ex)
    //            {
    //                tcsAccount.TrySetException(ex);
    //            }
    //        }

    //        tcsAccount.TrySetResult(null);
    //        return false;
    //    }

    //    public bool IsIos13()
    //    {
    //        return false;
    //    }

    //    public async System.Threading.Tasks.Task<Models.AppleSignIn.AppleAccount> SignInAsync()
    //    {
    //        tcsAccount = new System.Threading.Tasks.TaskCompletionSource<Models.AppleSignIn.AppleAccount>();

    //        // Generate state and nonce which the server will use to initial the auth
    //        // with Apple.  The nonce should flow all the way back to us when our function
    //        // redirects to our app
    //        currentState = Models.AppleSignIn.Util.GenerateState();
    //        currentNonce = Models.AppleSignIn.Util.GenerateNonce();

    //        // Start the auth request on our function (which will redirect to apple)
    //        // inside a browser (either SFSafariViewController, Chrome Custom Tabs, or native browser)
    //        await Xamarin.Essentials.Browser.OpenAsync($"{InitialAuthUrl}?&state={currentState}&nonce={currentNonce}",
    //            Xamarin.Essentials.BrowserLaunchMode.SystemPreferred);

    //        return await tcsAccount.Task;
    //    }
    //}

}

