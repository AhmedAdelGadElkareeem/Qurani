using System.Text.RegularExpressions;

namespace WytSky.Mobile.Maui.Skoola.Behaviors
{
    public class EmailValidBehavior : Behavior<Entry>
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
                var email = e.NewTextValue;

                var emailEntry = sender as Entry;
            
                if (RegexIsMatch(email))
                {
                    emailEntry.TextColor = Colors.Black;
                }
                else
                {
                    emailEntry.TextColor = Colors.Red;
                }
            }
            catch (System.Exception ex)
            {
                string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "EmailValidBehavior", "BindableOnTextChanged");
            }
        }

        public static bool RegexIsMatch(string email)
        {
            try
            {
                var emailPattern = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
                if (Regex.IsMatch(email, emailPattern))
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
