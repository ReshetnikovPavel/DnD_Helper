using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class PartySelectionModel : BindableObject
    {
        public ICommand SelectMyParty { get; }

        public ICommand SelectMyMasterParty { get; }

        public ICommand CreateNewParty { get; }
        public ICommand JoinNewParty { get; }

        public string[] MyPartyNames
            => new string[] { "Дикие пингвины", "Пельмешковые воины", "Культ водоисточающей лампы" };

        public string[] MyMasterPartyNames
            => new string[] { "Культ любви к Соне Мельковой", "Петряшовские мелодрамы", "Филлипа не добавляем!!" };


    }
}
