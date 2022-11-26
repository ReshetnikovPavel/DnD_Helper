using DnD_Helper.Resources.Controls;
using Domain;

namespace DnD_Helper;

public partial class AbilityScoresSelectionPage : ContentPage
{
    private string testString = "the sweetest victory";
    private Abilities abilities = new Abilities(0, 0, 0, 0, 0, 0);

	public AbilityScoresSelectionPage()
	{
		InitializeComponent();

        BindingContext = this;
    }

    public AbilityScore Strength
        => abilities.Strength;

    public AbilityScore Intelligence
		=> abilities.Intelligence;

    public string TestString
    {
        get => testString;
        set
        {
            if (testString == value)
                return;
            testString = value;
            OnPropertyChanged();
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        TestString = "What?";
    }
}