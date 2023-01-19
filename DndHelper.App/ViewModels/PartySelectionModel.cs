using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class PartySelectionModel : BindableObject
    {
        public ICommand SelectMyParty { get; }

        public ICommand SelectMyMasterParty { get; }

        public ICommand CreateNewParty { get; }
        public ICommand JoinNewParty { get; }

        public PartySelectionModel()
        {
            SelectMyParty = new Command<string>(OnPartySelected);
            SelectMyMasterParty = new Command<string>(OnPartySelected);
        }

        public string[] MyPartyNames
            => new string[] { "Дикие пингвины", "Пельмешковые воины", "Культ водоисточающей лампы" };

        public string[] MyMasterPartyNames
            => new string[] { "Культ любви к Соне Мельковой", "Петряшовские мелодрамы", "Филлипа не добавляем!!" };

        private async void OnPartySelected(string partyName)
        {
            await Shell.Current.GoToAsync($"/{nameof(ModelParty)}",
                new Dictionary<string, object>
                {
                    ["Party"] = null //TODO: вставить сюда партию
                }
                );
        }
    }
}
