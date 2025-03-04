using System.Windows.Input;

namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class ProfileCard : BaseContentView
{
    public ProfileCard()
    {
        try
        {
            InitializeComponent();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "ProfileCard", "Contructor");
        }
    }

    #region OnCardClicked
    public static readonly BindableProperty OnCardClickedProperty =
    BindableProperty.Create(nameof(OnCardClicked),
        typeof(ICommand), typeof(ProfileCard), defaultValue: null, BindingMode.TwoWay);
    public ICommand OnCardClicked
    {
        get => (ICommand)GetValue(OnCardClickedProperty);
        set => SetValue(OnCardClickedProperty, value);
    }
    #endregion


    #region CardName
    public static readonly BindableProperty CardNameProperty =
        BindableProperty.Create(nameof(CardName), typeof(string), typeof(ProfileCard), null, BindingMode.TwoWay);
    public string CardName
    {
        get => (string)GetValue(CardNameProperty);
        set => SetValue(CardNameProperty, value);
    }
    #endregion

    #region PrefixImage
    public static readonly BindableProperty PrefixImageProperty =
        BindableProperty.Create(nameof(PrefixImage), typeof(string), typeof(ProfileCard), null, BindingMode.TwoWay);
    public string PrefixImage
    {
        get => (string)GetValue(PrefixImageProperty);
        set => SetValue(PrefixImageProperty, value);
    }
    #endregion
}