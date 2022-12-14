using CommunityToolkit.Maui;
using DnD_Helper.ApplicationClasses;
using DnD_Helper.ViewModels;
using DndHelper.App;
using DndHelper.Domain.Repositories;
using DndHelper.Domain.Services;
using DndHelper.Firebase.Adapters;
using DndHelper.Firebase.Repositories;
using DndHelper.Xml.Repositories;
using System.Xml.Linq;

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
			.AddTransient<BackgroundSelectionPage>();
		return services;
	}

	private static IServiceCollection RegisterServices(this IServiceCollection services)
	{
		services
			.RegisterFirebaseAuth()
			.RegiserRepositories()
			.AddTransient<DistributorAbilityScore>()
			.AddTransient<Abilities>()
			.AddTransient<ICreatesCharacter, CharacterCreator>()
			.AddTransient<IModelNavigator, CharacterCreationNavigator>();
		return services;
	}

	private static IServiceCollection RegisterFirebaseAuth(this IServiceCollection services)
	{
		services
            .AddTransient<IAuthProvider, FirebaseAuthProviderAdapter>();
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
			.AddTransient<IDndFactory<XElement>, DndCompendiumFactory>();
		
		return services;
	}
}
