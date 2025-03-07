namespace WytSky.Mobile.Maui.Skoola.Views.Zekr;

public partial class ZekrPage : BaseContentPage
{
    int count = 0;

    public ZekrPage()
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