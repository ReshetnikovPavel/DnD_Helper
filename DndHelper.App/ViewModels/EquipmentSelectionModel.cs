using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class EquipmentSelectionModel : BindableObject
    {
        public ICommand SelectEquipmentWeapons { get; set;} 
        public ICommand SelectEquipmentAddWeapons { get; set;}
        public ICommand SelectEquipmentArmor { get; set;}
        public ICommand SelectEquipmentInstrument { get; set;}
        public ICommand SelectEquipmentMusicInstrument { get; set;}
        public ICommand SelectEquipmentArcanaComponent { get; set;}

        public int NumberOfEquipmentWeapons => 2;
        public int NumberOfEquipmentAddWeapons => 3;

        public string[] EquipmentWeapons
            => new string[] { "Меч", "Кирка из майнкрафта", "Детские рыдания"};

        public string[] EquipmentAddWeapons
            => new string[] { "Не предусмотрено"};

        public string[] EquipmentArmor
            => new string[] { "Кольчуга", "Самомнение", "Верный друндль"};

        public string[] EquipmentInstrument
            => new string[] { "Набор месителя интриг", "Набор жены на выданье", "Набор ножей для сосисок"};

        public string[] EquipmentMusicInstrument
            => new string[] { "Не предусмотрено"};

        public string[] EquipmentArcanaComponent
            => new string[] { "Мешочек с компонентами", "Магическая фокусировка"};

        
    }
}
