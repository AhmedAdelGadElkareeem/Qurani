using CommunityToolkit.Maui.Layouts;
using WytSky.Mobile.Maui.Skoola.CustomControl;
using WytSky.Mobile.Maui.Skoola.Dtos.Used;
using System.Collections;
using System.Windows.Input;

namespace WytSky.Mobile.Maui.Skoola.Template;

public partial class ReviewTemplate : BaseContentView
{
	public ReviewTemplate()
	{
		InitializeComponent();
	}

    #region ReviewsCount : IList
    public static readonly BindableProperty ReviewsCountProperty =
    BindableProperty.Create(nameof(ReviewsCount),
        typeof(IList), typeof(ReviewTemplate), default, BindingMode.TwoWay);
    public IList ReviewsCount
    {
        get => (IList)GetValue(ReviewsCountProperty);
        set => SetValue(ReviewsCountProperty, value);
    }
    #endregion

    #region ReviewItems : IList
    public static readonly BindableProperty ReviewItemsProperty =
    BindableProperty.Create(nameof(ReviewItems),
        typeof(IList), typeof(ReviewTemplate), default, BindingMode.TwoWay);
    public IList ReviewItems
    {
        get => (IList)GetValue(ReviewItemsProperty);
        set => SetValue(ReviewItemsProperty, value);
    }
    #endregion

    #region SelectedReviewCommand
    public static readonly BindableProperty SelectedReviewCommandProperty =
    BindableProperty.Create(nameof(SelectedReviewCommand),
        typeof(ICommand), typeof(ReviewTemplate), defaultValue: null, BindingMode.TwoWay);
    public ICommand SelectedReviewCommand
    {
        get => (ICommand)GetValue(SelectedReviewCommandProperty);
        set => SetValue(SelectedReviewCommandProperty, value);
    }
    #endregion

    #region CommandParameter
    public static readonly BindableProperty CommandParameterProperty =
    BindableProperty.Create(nameof(CommandParameter),
        typeof(object), typeof(ReviewTemplate), defaultValue: null, BindingMode.TwoWay);
    public object CommandParameter
    {
        get => (object)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }
    #endregion
}