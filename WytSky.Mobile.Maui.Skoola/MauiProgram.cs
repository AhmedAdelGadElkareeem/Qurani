using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Mopups.Hosting;
using SkiaSharp.Views.Maui.Controls.Hosting;
using WytSky.Mobile.Maui.Skoola.CustomControl.Borderless;
using WytSky.Mobile.Maui.Skoola.Services;
using WytSky.Mobile.Maui.Skoola.Services.Implementation;

namespace WytSky.Mobile.Maui.Skoola
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
                builder.UseMauiApp<App>()
                        .UseMauiCommunityToolkit()
                        .UseFFImageLoading()
                        .UseSkiaSharp() // to use animation
                        .ConfigureMopups() // to use popups
                        .ConfigureFonts(fonts =>
                        {
                            fonts.AddFont("Manrope_Bold.ttf", "ManropeBold");
                            fonts.AddFont("Manrope_Regular.ttf", "ManropeRegular");
                            fonts.AddFont("materialdesignicons_webfont.ttf", "MaterialDesignIcons"); // for rate view
                            fonts.AddFont("FontAwesome6-Brands.otf", "FA6Brands"); // for credit card view
                            fonts.AddFont("FontAwesome6-Regular.otf", "FA6Regular"); // for credit card view
                        }).ConfigureMauiHandlers((handlers) =>
                        {
                        }).Services.AddTransient<IShowPopupService, ShowPopupService>();
            #if DEBUG
                        builder.Logging.AddDebug();
            #endif
                        AddHandlers();
            return builder.Build();
        }

        public static void AddHandlers()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
            {
                if (view is BorderlessEntry)
                {
#if ANDROID
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif IOS
                    handler.PlatformView.BackgroundColor = Colors.Transparent.ToPlatform();
                    //handler.PlatformView.Layer.BackgroundColor = Colors.Transparent.ToPlatform();
                    //handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                handler.PlatformView.Background = Colors.Transparent.ToPlatform();
#endif
                }
            });
            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping(nameof(BorderlessEditor), (handler, view) =>
            {
                if (view is BorderlessEditor)
                {
#if ANDROID
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif IOS
                    handler.PlatformView.BackgroundColor = Colors.Transparent.ToPlatform();
                    //handler.PlatformView.Layer.BackgroundColor = Colors.Transparent.ToPlatform();
                    //handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                handler.PlatformView.Background = Colors.Transparent.ToPlatform();
#endif
                }
            });
            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping(nameof(BorderlessDatePicker), (handler, view) =>
            {
                if (view is BorderlessDatePicker)
                {
#if ANDROID
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif IOS
                    handler.PlatformView.BackgroundColor = Colors.Transparent.ToPlatform();
                    //handler.PlatformView.Layer.BackgroundColor = Colors.Transparent.ToPlatform();
                    //handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                handler.PlatformView.Background = Colors.Transparent.ToPlatform();
#endif
                }
            });
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping(nameof(BorderlessPicker), (handler, view) =>
            {
                if (view is BorderlessPicker)
                {
#if ANDROID
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif IOS
                    handler.PlatformView.BackgroundColor = Colors.Transparent.ToPlatform();
                    //handler.PlatformView.Layer.BackgroundColor = Colors.Transparent.ToPlatform();
                    //handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                handler.PlatformView.Background = Colors.Transparent.ToPlatform();
#endif
                }
            });
        }

        private static void ApplyStyleCustomization()
        {
            // Remove the underline from the Entry ...

            PickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, _) =>
            {
#if ANDROID
                // Remove the underline from the Spinner (Picker)
                handler.PlatformView.Background = null;
#endif
            });

            PickerHandler.Mapper.AppendToMapping("SetUpPicker", (handler, _) =>
            {
#if ANDROID
                // Set the background to transparent
                handler.PlatformView.Background = null;
#elif IOS || MACCATALYST
    // Remove border for the UITextField (Picker)
    if (handler.PlatformView is UIKit.UITextField textField)
    {
        textField.BorderStyle = UIKit.UITextBorderStyle.None;
    }
#elif WINDOWS

#endif
            });
        }
    }
}