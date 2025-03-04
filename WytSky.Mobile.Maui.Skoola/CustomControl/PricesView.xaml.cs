namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class PricesView : ContentView
{
	public PricesView()
	{
        try
        {
            InitializeComponent();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex,"", "PricesView", "Constructor");
        }
	}

    #region IsPaymentMethodVisible
    public static readonly BindableProperty IsPaymentMethodVisibleProperty =
        BindableProperty.Create(nameof(IsPaymentMethodVisible), typeof(bool), typeof(PricesView), false, BindingMode.TwoWay);
    public bool IsPaymentMethodVisible
    {
        get => (bool)GetValue(IsPaymentMethodVisibleProperty);
        set => SetValue(IsPaymentMethodVisibleProperty, value);
    }
    #endregion

    #region SubTotal
    public static readonly BindableProperty SubTotalProperty =
        BindableProperty.Create(nameof(SubTotal), typeof(string), typeof(PricesView), null, BindingMode.TwoWay);
    public string SubTotal
    {
        get => (string)GetValue(SubTotalProperty);
        set => SetValue(SubTotalProperty, value);
    }
    #endregion

    #region CurrencyName
    public static readonly BindableProperty CurrencyNameProperty =
        BindableProperty.Create(nameof(CurrencyName), typeof(string), typeof(PricesView), null, BindingMode.TwoWay);
    public string CurrencyName
    {
        get => (string)GetValue(CurrencyNameProperty);
        set => SetValue(CurrencyNameProperty, value);
    }
    #endregion

    #region Delivery
    public static readonly BindableProperty DeliveryProperty =
        BindableProperty.Create(nameof(Delivery), typeof(string), typeof(PricesView), null, BindingMode.TwoWay);
    public string Delivery
    {
        get => (string)GetValue(DeliveryProperty);
        set => SetValue(DeliveryProperty, value);
    }
    #endregion

    #region Vat
    public static readonly BindableProperty VatProperty =
        BindableProperty.Create(nameof(Vat), typeof(string), typeof(PricesView), null, BindingMode.TwoWay);
    public string Vat
    {
        get => (string)GetValue(VatProperty);
        set => SetValue(VatProperty, value);
    }
    #endregion


    #region Discount
    public static readonly BindableProperty DiscountProperty =
        BindableProperty.Create(nameof(Discount), typeof(string), typeof(PricesView), null, BindingMode.TwoWay);
    public string Discount
    {
        get => (string)GetValue(DiscountProperty);
        set => SetValue(DiscountProperty, value);
    }
    #endregion

    #region BounsToDelivery
    public static readonly BindableProperty BounsToDeliveryProperty =
        BindableProperty.Create(nameof(BounsToDelivery), typeof(string), typeof(PricesView), null, BindingMode.TwoWay);
    public string BounsToDelivery
    {
        get => (string)GetValue(BounsToDeliveryProperty);
        set => SetValue(BounsToDeliveryProperty, value);
    }
    #endregion

    #region TotalItems
    public static readonly BindableProperty TotalItemsProperty =
        BindableProperty.Create(nameof(TotalItems), typeof(string), typeof(PricesView), null, BindingMode.TwoWay);
    public string TotalItems
    {
        get => (string)GetValue(TotalItemsProperty);
        set => SetValue(TotalItemsProperty, value);
    }
    #endregion

    #region TotalPrice
    public static readonly BindableProperty TotalPriceProperty =
        BindableProperty.Create(nameof(TotalPrice), typeof(string), typeof(PricesView), null, BindingMode.TwoWay);
    public string TotalPrice
    {
        get => (string)GetValue(TotalPriceProperty);
        set => SetValue(TotalPriceProperty, value);
    }
    #endregion
    
}