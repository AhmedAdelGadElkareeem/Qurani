using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace WytSky.Mobile.Maui.Skoola.Behaviors
{
    public class FullNameValidBehavior : Behavior<Entry>
    {
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(string), typeof(FullNameValidBehavior), "error.png");

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public string IsValid
        {
            get { return (string)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

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
                if (!string.IsNullOrEmpty(test) && test.Length >= 5)
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
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "FullNameValidBehavior", "BindableOnTextChanged");

            }
        }
    }
}
