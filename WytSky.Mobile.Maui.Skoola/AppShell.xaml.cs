namespace WytSky.Mobile.Maui.Skoola
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }
      
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return false;
        }
    }
}
