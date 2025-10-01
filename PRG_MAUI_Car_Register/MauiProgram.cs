using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Android.OS;
using Android.Views; // Behövs för SetStatusBarColor

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
using Microsoft.Maui.Platform;
#endif

namespace PRG_MAUI_Car_Register
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

#if WINDOWS
            builder.ConfigureLifecycleEvents(events =>
            {
                events.AddWindows(wndLifeCycleBuilder =>
                {
                    wndLifeCycleBuilder.OnWindowCreated(window =>
                    {
                        const int windowWidth = 400;
                        const int windowHeight = 800;

                        var mauiWindow = (MauiWinUIWindow)window;
                        var windowId = Win32Interop.GetWindowIdFromWindow(mauiWindow.WindowHandle);
                        var appWindow = AppWindow.GetFromWindowId(windowId);
                        if (appWindow != null)
                        {
                            appWindow.Resize(new SizeInt32(windowWidth, windowHeight));
                        }
                    });
                });
            });
//#endif

//#if ANDROID
//            builder.ConfigureLifecycleEvents(events =>
//            {
//                events.AddAndroid(android =>
//                {
//                    android.OnCreate((activity, bundle) =>
//                    {
//                        // Ändra färgen på statusfältet på Android
//                        if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
//                        {
//                            activity.Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#000000"));
//                        }
//                    });
//                });
//            });
#endif

            return builder.Build();
        }
    }
}