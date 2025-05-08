using GenovaAI.ViewModels;
using GenovaAI.Services;

namespace GenovaAI.Helpers;

public static class ViewModelLocator
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<CryptoServices>();
        services.AddTransient<CryptoCardListViewModel>();
    }
}