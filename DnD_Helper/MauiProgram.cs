using CommunityToolkit.Maui;
using DnD_Helper.ApplicationClasses;
using DnD_Helper.ViewModels;
using DndHelper.App.Authentication;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using DndHelper.Domain.Services;
using DndHelper.Firebase.Adapters;
using DndHelper.App.Repositories;
using DndHelper.Xml.Repositories;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using DndHelper.App.Database;
using Firebase.Database.Query;
using Firebase.Auth;

namespace DnD_Helper;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services
			.RegisterServices()
			.RegisterViewModels()
			.RegisterPages()
			.RegisterShells();

		return builder.Build();
	}

	private static IServiceCollection RegisterViewModels(this IServiceCollection services)
	{
		services
			.AddTransient<AppShellViewModel>()
			.AddTransient<LoginViewModel>()
			.AddTransient<RegisterViewModel>()
			.AddTransient<AbilityScoreSelectionModel>()
			.AddTransient<ClassSelectionModel>()
			.AddTransient<RaceSelectionModel>()
			.AddTransient<BackgroundSelectionModel>();
		return services;
	}

    private static IServiceCollection RegisterShells(this IServiceCollection services)
    {
		services
			.AddTransient<AppShell>();
        return services;
    }

    private static IServiceCollection RegisterPages(this IServiceCollection services)
	{
		services
			.AddTransient<MenuPage>()
			.AddTransient<LoginPage>()
			.AddTransient<RegisterPage>()
			.AddTransient<AbilityScoresSelectionPage>()
			.AddTransient<ClassSelectionPage>()
			.AddTransient<RaceSelectionPage>()
			.AddTransient<BackgroundSelectionPage>()
			.AddTransientWithShellRoute<CharacterSelectionPage, CharacterSelectionModel>(nameof(CharacterSelectionModel));
		return services;
	}

	private static IServiceCollection RegisterServices(this IServiceCollection services)
	{
		services
			.RegisterFirebase()
			.RegiserRepositories()
			.AddTransient<DistributorAbilityScore>()
			.AddTransient<Abilities>()
			.AddTransient<ICreatesCharacter, CharacterCreator>()
			.AddTransient<IModelNavigator, CharacterCreationNavigator>();
		return services;
	}

	private static IServiceCollection RegisterFirebase(this IServiceCollection services)
	{
		services
            .AddSingleton<IAuthenticationProvider<string>, FirebaseAuthProviderAdapter>()
			.AddSingleton<IDatabaseClient, FirebaseClientAdapter>()
			.AddSingleton(new FirebaseDatabaseUrl("https://dndhelper-e695e-default-rtdb.asia-southeast1.firebasedatabase.app/"))
            .AddSingleton(new FirebaseConfig("AIzaSyAsyhRQKmYdtXBaH8LOgFe_tgHWGRh6wJQ"));
        return services;
    }

	private static IServiceCollection RegiserRepositories(this IServiceCollection services)
	{
		services
			.AddTransient<IClassRepository, XmlClassRepository>()
			.AddTransient<ILanguageRepository, XmlLanguageRepository>()
			.AddTransient<IRaceRepository, XmlRaceRepository>()
			.AddTransient<IBackgroundRepository, XmlBackgroundRepository>()
			.AddTransient<ISpellRepository, XmlSpellRepository>()
			.AddTransient<IWeaponRepository, XmlWeaponRepository>()
			.AddTransient<IDndParser, DndCompendiumParser>()
			.AddTransient<IDndFactory<XElement>, DndCompendiumFactory>()
			.AddTransient<ICharacterRepository, DatabaseCharacterRepository<string>>();
		
		return services;
	}
}
