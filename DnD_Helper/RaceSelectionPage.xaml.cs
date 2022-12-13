using DnD_Helper.ApplicationClasses;
using DnD_Helper.ViewModels;
using Domain;
using Domain.Repositories;

namespace DnD_Helper;

public partial class RaceSelectionPage : ContentPage
{
	public RaceSelectionPage(RaceSelectionModel raceSelectionViewModel)
	{
		InitializeComponent();

        BindingContext = raceSelectionViewModel;
	}
}