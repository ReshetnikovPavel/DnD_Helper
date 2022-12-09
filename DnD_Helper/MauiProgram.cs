using Domain;
using Domain.Repositories;
using Firebase.Auth;
using Infrastructure;

namespace DnD_Helper;

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
            })
            .RegisterAppServices()
            .RegisterViewModels()
            .RegisterViews()
            .RegisterRepositories();

		return builder.Build();
	}

    private static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
    {
        builder.Services
            .AddTransient<DistributorAbilityScore>();

        builder.Services
            .AddSingleton<IAuthProvider, FirebaseAuthProviderAdapter>()
            .AddSingleton<FirebaseAuthProvider>();
        return builder;
    }

    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services
            .AddSingleton<ViewModels.RegisterViewModel>()
            .AddSingleton<ViewModels.LoginViewModel>();
        return builder;
    }

    private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
    {
        return builder;
    }

    private static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
    {
        builder.Services
            .AddSingleton<IClassRepository, XmlClassRepository>()
            .AddSingleton<IRaceRepository, XmlRaceRepository>()
            .AddSingleton<IBackgroundRepository, XmlBackgroundRepository>()
            .AddSingleton<ILanguageRepository, XmlLanguageRepository>()
            .AddSingleton<ISpellRepository, XmlSpellRepository>()
            .AddSingleton<IWeaponRepository, XmlWeaponRepository>()
            .AddSingleton<ICharacterRepository, FirebaseCharacterRepository>();
        return builder;
    }
}
