﻿using DnD_Helper.ViewModels;
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
		builder.Services
			.RegisterServices()
			.RegisterViewModels()
			.RegisterPages();

		return builder.Build();
	}

	private static IServiceCollection RegisterViewModels(this IServiceCollection services)
	{
		services
			.AddTransient<LoginViewModel>()
			.AddTransient<RegisterViewModel>();
		return services;
	}

	private static IServiceCollection RegisterPages(this IServiceCollection services)
	{
		services
			.AddTransient<LoginPage>()
			.AddTransient<RegisterPage>();
		return services;
	}

	private static IServiceCollection RegisterServices(this IServiceCollection services)
	{
		services.RegisterFirebaseAuth();

		return services;
	}

	private static IServiceCollection RegisterFirebaseAuth(this IServiceCollection services)
	{
        services
            .AddSingleton<IAuthProvider, FirebaseAuthProviderAdapter>()
            .AddTransient<FirebaseAuth>()
            .AddSingleton(new FirebaseConfig("AIzaSyAsyhRQKmYdtXBaH8LOgFe_tgHWGRh6wJQ"));
        return services;
    }
}
