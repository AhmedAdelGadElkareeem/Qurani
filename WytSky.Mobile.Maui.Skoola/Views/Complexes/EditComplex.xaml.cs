using Mopups.Pages;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.Views.Complexes;

public partial class EditComplex : PopupPage
{
    private ComplexModel selectedComplex;
    public EditComplex()
	{
		InitializeComponent();
	}
    public EditComplex(ComplexModel selectedComplex)
    {
        this.selectedComplex = selectedComplex;
    }
}