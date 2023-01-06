using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class SpellSelectionModel : BindableObject
    {
        public ICommand SelectSpell { get; set;} 

        public int NumberOfSpells => 2;

        public string[] Spells
            => new string[] { "Злая Насмешка", "Великий пук", "Призыв Андрея"};
    }
}
