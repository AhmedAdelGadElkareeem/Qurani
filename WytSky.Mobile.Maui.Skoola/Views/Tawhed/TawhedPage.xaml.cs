namespace WytSky.Mobile.Maui.Skoola.Views.Tawhed;

public partial class TawhedPage : BaseContentPage
{
    int count = 0;

    public TawhedPage()
	{
		InitializeComponent();
	}
    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"{count}";
        else
            CounterBtn.Text = $"{count}";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}