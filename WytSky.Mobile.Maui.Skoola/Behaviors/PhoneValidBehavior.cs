using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace WytSky.Mobile.Maui.Skoola.Behaviors
{
    public class PhoneValidBehavior : Behavior<Entry>
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
            var test = e.NewTextValue;
            var pwEntry = sender as Entry;

            try
            {
                if (!string.IsNullOrEmpty(test) && test.Length >= 10)
                {
                    pwEntry.TextColor = Colors.Black;
                    // IsValid = "success.png";
                }
                else
                {
                    pwEntry.TextColor = Colors.Red;
                    // IsValid = "error.png";
                }
            }
            catch (System.Exception ex)
            {
                string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "PhoneValidBehavior", "BindableOnTextChanged");

            }
        }
    }
}
