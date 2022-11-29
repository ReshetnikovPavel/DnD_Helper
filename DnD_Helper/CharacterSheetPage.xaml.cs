using Domain;

namespace DnD_Helper;

public partial class CharacterSheetPage : ContentPage
{
	public CharacterSheetPage()
	{
		InitializeComponent();

		BindingContext = this;
	}

	public string NameDisplay
		=> $"Имя: {AppShell.Singleton.Character.Name}";

    public string MainInfoDisplay
	{
		get
		{
			var ch = AppShell.Singleton.Character;
			var race = ch.Race.SubraceName == null ? ch.Race.Name : ch.Race.SubraceName;
			return $"{race}, {ch.Class.Name}, {ch.Background.Name}";
		}
	}

	public string SpeedDisplay
		=> $"Скорость: {AppShell.Singleton.Character.Speed.Value}";



	//public string ArmourClassDisplay
	//	=> $"КД: {10 + AppShell.Singleton.Character.Abilities}";

}