﻿using CommunityToolkit.Maui;
using DndHelper.App.ApplicationClasses;
using DndHelper.App.Authentication;
using DndHelper.App.Database;
using DndHelper.App.Repositories;
using DndHelper.App.ViewModels;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using DndHelper.Domain.Services;
using DndHelper.Firebase.Adapters;
using DndHelper.Xml.Repositories;

/* Unmerged change from project 'DnD_Helper (net6.0-android)'
Before:
using Firebase.Database.Query;
using Firebase.Auth;
using DndHelper.App.ViewModels;
using DndHelper.App.ApplicationClasses;
After:
using Firebase.Auth;
using Firebase.Database.Query;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;
*/

/* Unmerged change from project 'DnD_Helper (net6.0-maccatalyst)'
Before:
using Firebase.Database.Query;
using Firebase.Auth;
using DndHelper.App.ViewModels;
using DndHelper.App.ApplicationClasses;
After:
using Firebase.Auth;
using Firebase.Database.Query;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;
*/

/* Unmerged change from project 'DnD_Helper (net6.0-windows10.0.19041.0)'
Before:
using Firebase.Database.Query;
using Firebase.Auth;
using DndHelper.App.ViewModels;
using DndHelper.App.ApplicationClasses;
After:
using Firebase.Auth;
using Firebase.Database.Query;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;
*/
using Firebase.Auth;
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
            .AddTransientWithShellRoute<RegisterPage, RegisterViewModel>(nameof(RegisterViewModel))
            .AddTransient<AbilityScoresSelectionPage>()
            .AddTransient<ClassSelectionPage>()
            .AddTransient<RaceSelectionPage>()
            .AddTransient<BackgroundSelectionPage>()
            .AddTransientWithShellRoute<CharacterSelectionPage, CharacterSelectionModel>(
                nameof(CharacterSelectionModel))
            .AddTransientWithShellRoute<CharacterSheetPage, CharacterSheetViewModel>(nameof(CharacterSheetViewModel));

        return services;
    }

    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services
            .RegisterFirebase()
            .RegiserRepositories()
            .AddTransient<DistributorAbilityScore>()
            .AddTransient<Abilities>()
            .AddTransient<CharacterCreationNavigator>()
            .AddSingleton<ICreatesCharacter, CharacterCreator>()
            .AddTransient<IModelNavigator, RouteCollectionNavigator>()
            .AddTransient<IHasRouteCollection, RouteCollection>()
            .AddTransient<IStateManager<string, object>, StateDictionary<string, object>>();
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
