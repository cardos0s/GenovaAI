using GenovaAI.Helpers;
using GenovaAI.Services;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using PanCardView;

namespace GenovaAI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
      
        var builder = MauiApp.CreateBuilder();
        builder
            .UseSkiaSharp() 
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
     
#if DEBUG
        builder.Logging.AddDebug();
        
#endif
        ViewModelLocator.RegisterServices(builder.Services);

        var app = builder.Build();
        App.ServiceProvider = app.Services;
        return app;
        
    }
}