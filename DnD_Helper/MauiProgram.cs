using System.Net;
using CommunityToolkit.Maui;
using DndHelper.App.ApplicationClasses;
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
using DndHelper.Domain.Campaign;
using DndHelper.Firebase.Campaign;
using DndHelper.Firebase.Repositories;
using Firebase.Database;
using Microsoft.Extensions.DependencyInjection;
using DndHelper.Infrastructure.Authentication;

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
            .AddSingleton<CharacterCreationShellViewModel>()
            .AddTransient<LoginViewModel>()
            .AddTransient<RegisterViewModel>()
            .AddTransient<AbilityScoreSelectionModel>()
            .AddTransient<ClassSelectionModel>()
            .AddTransient<RaceSelectionModel>()
            .AddTransient<SubraceSelectionModel>()
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
            .AddTransientWithShellRoute<AbilityRaceBonusSelectionPage, AbilityRaceBonusSelectionModel>(nameof(AbilityRaceBonusSelectionModel))
            .AddTransientWithShellRoute<LanguageSelectionPage, LanguageSelectionModel>(nameof(LanguageSelectionModel))
            .AddTransientWithShellRoute<SpellSelectionPage, SpellSelectionModel>(nameof(SpellSelectionModel))
            .AddTransientWithShellRoute<SkillsSelectionPage, SkillsSelectionModel>(nameof(SkillsSelectionModel))
            .AddTransientWithShellRoute<InstrumentSelectionPage, InstrumentSelectionModel>(nameof(InstrumentSelectionModel))
            .AddTransientWithShellRoute<SubraceSelectionPage, SubraceSelectionModel>(nameof(SubraceSelectionModel))
            .AddTransientWithShellRoute<CharacterSelectionPage, CharacterSelectionModel>(nameof(CharacterSelectionModel))
            .AddTransientWithShellRoute<PartySelectionPage, PartySelectionModel>(nameof(PartySelectionModel))
            .AddTransientWithShellRoute<CharacterSheetPage, CharacterSheetViewModel>(nameof(CharacterSheetViewModel))
            .AddTransientWithShellRoute<PageParty, ModelParty>(nameof(ModelParty))
            .AddTransientWithShellRoute<MenuPage, MenuModel>(nameof(MenuModel));

        return services;
    }

	private static IServiceCollection RegisterServices(this IServiceCollection services)
	{
		services
			.RegisterFirebase()
			.RegisterRepositories()
            .RegisterCampaignServices()
			.AddTransient<DistributorAbilityScore>()
			.AddTransient<Abilities>()
			.AddTransient<CharacterCreationNavigator>()
			.AddTransient<ICreatesCharacter, CharacterCreator>()
            .AddTransient<IShellNavigator, ShellNavigator>()
            .AddTransient<IModelNavigator, RouteCollectionNavigator>()
			.AddTransient<IHasRouteCollection, RouteCollection>()
			.AddTransient<IStateManager<CharacterAttributes, object>, StateDictionary<CharacterAttributes, object>>()
			.AddTransient<RepositoryFacade>();
		return services;
	}

    private static IServiceCollection RegisterFirebase(this IServiceCollection services)
    {
        services
            .AddSingleton<IAuthenticationProvider<string>, FirebaseAuthProviderAdapter>()
            .AddSingleton(new FirebaseDatabaseUrl("https://dndhelper-e695e-default-rtdb.asia-southeast1.firebasedatabase.app/"))
            .AddSingleton(new FirebaseConfig("AIzaSyAsyhRQKmYdtXBaH8LOgFe_tgHWGRh6wJQ"))
            .AddSingleton(serviceProvider => new FirebaseClient(((FirebaseDatabaseUrl)serviceProvider.GetService(typeof(FirebaseDatabaseUrl)))?.Url));
        return services;
    }

    private static IServiceCollection RegisterCampaignServices(this IServiceCollection services)
    {
        services
            .AddTransient<ICampaign<Guid, HttpStatusCode>, FirebaseDndCampaign>()
            .AddTransient<ICampaignFactory<Guid, HttpStatusCode>, FirebaseDndCampaignFactory>();
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
            .AddTransient<ICharacterRepository<HttpStatusCode>, FirebaseCharacterRepository>();

        return services;
    }

    private static void ProcessException(object sender, UnhandledExceptionEventArgs args)
    {
        Application.Current!.MainPage!.DisplayAlert("Необработанная ошибка!", (args.ExceptionObject as Exception)?.StackTrace, "Эх...");
    }
}
