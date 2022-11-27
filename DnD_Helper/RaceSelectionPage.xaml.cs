using Domain;
using Domain.Repositories;

namespace DnD_Helper;

public partial class RaceSelectionPage : ContentPage
{
	public RaceSelectionPage()
	{
		InitializeComponent();

		BindingContext = this;
	}

	public IEnumerable<string> RaceNames
		=> AppShell.RaceRepository.GetNames();
}