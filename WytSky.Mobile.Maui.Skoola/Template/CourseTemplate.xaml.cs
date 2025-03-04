using WytSky.Mobile.Maui.Skoola.CustomControl;
using WytSky.Mobile.Maui.Skoola.Dtos.Used;
using System.Windows.Input;
using CommunityToolkit.Maui.Behaviors;

namespace WytSky.Mobile.Maui.Skoola.Template;

public partial class CourseTemplate : BaseContentView
{
    public CourseTemplate()
    {
        InitializeComponent();
    }

    #region DataModel
    public static readonly BindableProperty DataModelProperty =
    BindableProperty.Create(nameof(DataModel),
        typeof(StCourse), typeof(StCourse), default, BindingMode.TwoWay);
    public StCourse DataModel
    {
        get => (StCourse)GetValue(DataModelProperty);
        set => SetValue(DataModelProperty, value);
    }
    #endregion

    #region CommandParameter
    public static readonly BindableProperty CommandParameterProperty =
    BindableProperty.Create(nameof(CommandParameter),
        typeof(object), typeof(CourseTemplate), defaultValue: null, BindingMode.TwoWay);
    public object CommandParameter
    {
        get => (object)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }
    #endregion

    #region SelectedCourseCommand
    public static readonly BindableProperty SelectedCourseCommandProperty =
    BindableProperty.Create(nameof(SelectedCourseCommand),
        typeof(ICommand), typeof(CourseTemplate), defaultValue: null, BindingMode.TwoWay);
    public ICommand SelectedCourseCommand
    {
        get => (ICommand)GetValue(SelectedCourseCommandProperty);
        set => SetValue(SelectedCourseCommandProperty, value);
    }
    #endregion

    private void ChangeColor(object sender, TappedEventArgs e)
    {
        try
        {
            FileImageSource file = favImage.Source as FileImageSource;
            if (file.File == "favorite")
            {
                favImage.Source = "red_favourite";
            }
            else
            {
                favImage.Source = "favorite";
            }
        }
        catch (Exception ex)
        {
            string er = ex.Message;
            ExtensionLogMethods.LogExtension(ex, "", "CourseTemplate", "ChangeColor");
        }
    }
}