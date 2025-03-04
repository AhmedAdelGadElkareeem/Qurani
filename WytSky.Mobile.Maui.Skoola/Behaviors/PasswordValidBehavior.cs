using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace WytSky.Mobile.Maui.Skoola.Behaviors
{
    public class PasswordValidBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += BindableOnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= BindableOnTextChanged;
        }

        private void BindableOnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var password = e.NewTextValue;
                var pwEntry = sender as Entry;
                //pwEntry.IsPassword = true;
            
                if (RegexIsMatch(password))
                {
                    pwEntry.TextColor = Colors.Black;
                }
                else
                {
                    pwEntry.TextColor = Colors.Red;
                }
            }
            catch (System.Exception ex)
            {
                string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "PasswordValidBehavior", "BindableOnTextChanged");
            }
        }
        public static bool RegexIsMatch(string password)
        {
            try
            {
                var passwordPattern = "^(?=(.*\\d))(?=(.*[@]))(?=.*[a-zA-Z])(?=.*[^a-zA-Z\\d]).{8,}$";
                if (Regex.IsMatch(password, passwordPattern))
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "EmailValidBehavior", "BindableOnTextChanged");
            }
            return false;
        }
    }
}
