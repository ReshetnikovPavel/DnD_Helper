using DnD_Helper.ViewModels;
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
			});
		builder
			.RegisterServices()
			.RegisterViewModels()
			.RegisterPages();

		return builder.Build();
	}

	private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
	{
		builder.Services
			.AddTransient<LoginViewModel>()
			.AddTransient<RegisterViewModel>();
		return builder;
	}

	private static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
	{
		builder.Services
			.AddTransient<LoginPage>()
			.AddTransient<RegisterPage>();
		return builder;
	}

	private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
	{
		builder.RegisterFirebaseAuth();

		return builder;
	}

	private static MauiAppBuilder RegisterFirebaseAuth(this MauiAppBuilder builder)
	{
        builder.Services
            .AddSingleton<IAuthProvider, FirebaseAuthProviderAdapter>()
            .AddTransient<FirebaseAuth>()
            .AddSingleton(new FirebaseConfig("AIzaSyAsyhRQKmYdtXBaH8LOgFe_tgHWGRh6wJQ"));
        return builder;
    }
}
