using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class InstrumentSelectionModel : BindableObject
    {
        public ICommand SelectInstruments { get; set;} 

        public int NumberOfInstruments => 2;

        public string[] Instruments
            => new string[] { "Вещь 1", "Вещь 2", "Вещь 3" };
    }
}
