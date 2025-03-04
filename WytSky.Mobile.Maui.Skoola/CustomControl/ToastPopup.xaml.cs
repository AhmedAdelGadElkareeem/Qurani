using CommunityToolkit.Maui.Views;

namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class ToastPopup : Popup
{
	public ToastPopup()
	{
		InitializeComponent();
	}

    #region ToastType
    public static readonly BindableProperty ToastTypeProperty =
    BindableProperty.Create(nameof(ToastType),
        typeof(Enums.TypeOfToast), typeof(ToastPopup), default, BindingMode.TwoWay, propertyChanged: SelectedItemChanged);
    private static void SelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((ToastPopup)bindable)?.ChangeVisualState();
    }

    // Gets or sets ToastType value  
    public Enums.TypeOfToast ToastType
    {
        get => (Enums.TypeOfToast)GetValue(ToastTypeProperty);
        set => SetValue(ToastTypeProperty, value);
    }
    #endregion

    #region ImageSource
    public static readonly BindableProperty ImageSourceProperty =
    BindableProperty.Create(nameof(ImageSource),
        typeof(string), typeof(ToastPopup), "", BindingMode.TwoWay);
    // Gets or sets ImageSource value  
    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }
    #endregion

    #region ToastMessage
    public static readonly BindableProperty ToastMessageProperty =
    BindableProperty.Create(nameof(ToastMessage),
        typeof(string), typeof(ToastPopup), "", BindingMode.TwoWay);
    // Gets or sets ToastMessage value  
    public string ToastMessage
    {
        get => (string)GetValue(ToastMessageProperty);
        set => SetValue(ToastMessageProperty, value);
    }
    #endregion

    #region ToastTitle
    public static readonly BindableProperty ToastTitleProperty =
    BindableProperty.Create(nameof(ToastTitle),
        typeof(string), typeof(ToastPopup), "", BindingMode.TwoWay);
    // Gets or sets ToastTitle value  
    public string ToastTitle
    {
        get => (string)GetValue(ToastTitleProperty);
        set => SetValue(ToastTitleProperty, value);
    }
    #endregion

    #region Methods

    public void ChangeVisualState()
    {
        VisualStateManager.GoToState(MainView, ToastType.ToString());
    }

    #endregion
}