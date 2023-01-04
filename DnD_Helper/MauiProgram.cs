using CommunityToolkit.Maui;
using DndHelper.App.ApplicationClasses;
using DndHelper.App.Authentication;
using DndHelper.App.Database;
using DndHelper.App.Repositories;
using DndHelper.App.RouteNavigation;
using DndHelper.App.ViewModels;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using DndHelper.Domain.Services;
using DndHelper.Firebase.Adapters;
using DndHelper.Xml.Repositories;
using Firebase.Auth;
using System.Xml.Linq;
using DnD_Helper.Navigation;

namespace DnD_Helper;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        AppDomain.CurrentDomain.UnhandledException += ProcessException;
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
            .AddTransient<CharacterCreationShellViewModel>()
            .AddTransient<LoginViewModel>()
            .AddTransient<RegisterViewModel>()
            .AddTransient<AbilityScoreSelectionModel>()
            .AddTransient<ClassSelectionModel>()
            .AddTransient<RaceSelectionModel>()
            .AddTransient<BackgroundSelectionModel>()
            .AddTransient<MenuModel>();
        return services;
    }

    private static IServiceCollection RegisterShells(this IServiceCollection services)
    {
        services
            .AddTransient<CharacterCreationShell>()
            .AddTransient<MenuShell>();
        return services;
    }

    private static IServiceCollection RegisterPages(this IServiceCollection services)
    {
        services
            .AddTransient<MenuPage>()
            .AddTransientWithShellRoute<LoginPage, LoginViewModel>(nameof(LoginViewModel))
            .AddTransientWithShellRoute<RegisterPage, RegisterViewModel>(nameof(RegisterViewModel))
            .AddTransient<AbilityScoresSelectionPage>()
            .AddTransient<ClassSelectionPage>()
            .AddTransient<RaceSelectionPage>()
            .AddTransient<BackgroundSelectionPage>()
            .AddTransientWithShellRoute<CharacterSelectionPage, CharacterSelectionModel>(nameof(CharacterSelectionModel))
            .AddTransientWithShellRoute<PartySelectionPage, PartySelectionModel>(nameof(PartySelectionModel))
            .AddTransientWithShellRoute<CharacterSheetPage, CharacterSheetViewModel>(nameof(CharacterSheetViewModel))
            .AddTransientWithShellRoute<MenuPage, MenuModel>(nameof(MenuModel));

        return services;
    }

	private static IServiceCollection RegisterServices(this IServiceCollection services)
	{
		services
			.RegisterFirebase()
			.RegisterRepositories()
			.AddTransient<DistributorAbilityScore>()
			.AddTransient<Abilities>()
			.AddTransient<CharacterCreationNavigator>()
			.AddSingleton<ICreatesCharacter, CharacterCreator>()
            .AddSingleton<IShellNavigator, ShellNavigator>()
            .AddTransient<IModelNavigator, RouteCollectionNavigator>()
			.AddTransient<IHasRouteCollection, RouteCollection>()
			.AddTransient<IStateManager<string, object>, StateDictionary<string, object>>()
			.AddTransient<RepositoryFacade>();
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

    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
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

    private static void ProcessException(object sender, UnhandledExceptionEventArgs args)
    {
        Application.Current!.MainPage!.DisplayAlert("Необработанная ошибка!", (args.ExceptionObject as Exception)?.StackTrace, "Эх...");
    }
}
