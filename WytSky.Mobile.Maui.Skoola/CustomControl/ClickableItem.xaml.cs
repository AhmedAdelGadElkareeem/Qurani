using System.Collections;
using System.Windows.Input;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Services;

namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class ClickableItem : ContentView
{
        #region Constractor
        public ClickableItem()
        {
            try
            {
                InitializeComponent();
                //container.HeightRequest = App.ScreenHeight / 60;
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "ClickableItem", "Constructor");
            }
        }

        #endregion

        #region ItemsSource : IList
        public static readonly BindableProperty ItemsSourceProperty =
        BindableProperty.Create(nameof(ItemsSource),
            typeof(IList), typeof(ClickableItem), default, BindingMode.TwoWay);
        public IList ItemsSource
        {
            get => (IList)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }
        #endregion

        #region SelectedIndex : int
        public static readonly BindableProperty SelectedIndexProperty =
        BindableProperty.Create(nameof(SelectedIndex),
            typeof(int), typeof(ClickableItem), -1, BindingMode.TwoWay);
        public int SelectedIndex
        {
            get => (int)GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }
        #endregion

        #region SelectedItem : object
        public static readonly BindableProperty SelectedItemProperty =
        BindableProperty.Create(nameof(SelectedItem),
            typeof(object), typeof(ClickableItem), null, BindingMode.TwoWay
            , propertyChanged: ItemChanged);
        public object SelectedItem
        {
            get => (object)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }
        private static void ItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = ((ClickableItem)bindable);
            if (newvalue != null && newvalue.Equals(SharedResources.Text_Status))
                ((ClickableItem)bindable).SelectedIndex = 1;
            control.Text = newvalue != null ? newvalue.ToString() : control.Title;
        }
        #endregion

        #region Text
        public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text),
            typeof(string), typeof(ClickableItem), string.Empty, BindingMode.TwoWay, propertyChanged: ItemChanged);
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        #endregion

        #region SearchText
        public static readonly BindableProperty SearchTextProperty =
        BindableProperty.Create(nameof(SearchText),
            typeof(string), typeof(ClickableItem), string.Empty, BindingMode.TwoWay, propertyChanged: ItemChanged);
        public string SearchText
        {
            get => (string)GetValue(SearchTextProperty);
            set => SetValue(SearchTextProperty, value);
        }
        #endregion

        #region Title
        public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title),
            typeof(string), typeof(ClickableItem), string.Empty, BindingMode.TwoWay, propertyChanged: ItemChanged);
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        #endregion

        #region FontSize
        public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create(nameof(FontSize),
            typeof(int), typeof(ClickableItem), 17, BindingMode.TwoWay);
        public int FontSize
        {
            get => (int)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }
        #endregion

        #region Icon
        public static readonly BindableProperty IconProperty =
        BindableProperty.Create(nameof(Icon),
            typeof(string), typeof(ClickableItem), "down_arrow.png", BindingMode.TwoWay);
        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
        #endregion

        #region IsEnabledPicker
        public static readonly BindableProperty IsEnabledPickerProperty =
        BindableProperty.Create(nameof(IsEnabledPicker),
            typeof(bool), typeof(ClickableItem), true, BindingMode.TwoWay);
        public bool IsEnabledPicker
        {
            get => (bool)GetValue(IsEnabledPickerProperty);
            set => SetValue(IsEnabledPickerProperty, value);
        }
        #endregion

        #region IsRequired
        public static readonly BindableProperty IsRequiredProperty =
        BindableProperty.Create(nameof(IsRequired),
            typeof(bool), typeof(ClickableItem), true, BindingMode.TwoWay);
        public bool IsRequired
        {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }
        #endregion

        #region IsEditMode
        public static readonly BindableProperty IsEditModeProperty =
        BindableProperty.Create(nameof(IsEditMode),
            typeof(bool), typeof(ClickableItem), false, BindingMode.TwoWay);
        public bool IsEditMode
        {
            get => (bool)GetValue(IsEditModeProperty);
            set => SetValue(IsEditModeProperty, value);
        }
        #endregion

        #region IsClickable
        public static readonly BindableProperty IsClickableProperty =
        BindableProperty.Create(nameof(IsClickable),
            typeof(bool), typeof(ClickableItem), true, BindingMode.TwoWay);
        public bool IsClickable
        {
            get => (bool)GetValue(IsClickableProperty);
            set => SetValue(IsClickableProperty, value);
        }
        #endregion

        #region IsSearchVisible
        public static readonly BindableProperty IsSearchVisibleProperty =
        BindableProperty.Create(nameof(IsSearchVisible),
            typeof(bool), typeof(ClickableItem), false, BindingMode.TwoWay);
        public bool IsSearchVisible
        {
            get => (bool)GetValue(IsSearchVisibleProperty);
            set => SetValue(IsSearchVisibleProperty, value);
        }
        #endregion

        #region SelectedIndexChangedCommand
        public static readonly BindableProperty SelectedIndexChangedCommandProperty =
        BindableProperty.Create(nameof(SelectedIndexChangedCommand),
            typeof(ICommand), typeof(ClickableItem), defaultValue: null, BindingMode.TwoWay);
        public ICommand SelectedIndexChangedCommand
        {
            get => (ICommand)GetValue(SelectedIndexChangedCommandProperty);
            set => SetValue(SelectedIndexChangedCommandProperty, value);
        }
        #endregion

        #region CommandParameter
        public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter),
            typeof(object), typeof(ClickableItem), defaultValue: null, BindingMode.TwoWay);
        public object CommandParameter
        {
            get => (object)GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }
        #endregion

        #region Command
        public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command),
            typeof(ICommand), typeof(ClickableItem), defaultValue: null, BindingMode.TwoWay);
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
        #endregion

        private async void OpenItemsPopup(object sender, TappedEventArgs e)
        {
            try
            {
                if (IsEnabledPicker && IsClickable)
                {
                    /*await MauiPopup.PopupAction.DisplayPopup(new ClickableItemsSource()
                    {
                        BindingContext = this
                    });*/

                    var item = DependencyService.Get<IShowPopupService>();
                    await App.ShowPopupService.Show(new ClickableItemsSource()
                    {
                        BindingContext = this
                    });
                }
                else
                {
                    if (Command != null && Command.CanExecute(null))
                    {
                        Command.Execute(null);
                    }
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "", "");
            }
        }
    }
