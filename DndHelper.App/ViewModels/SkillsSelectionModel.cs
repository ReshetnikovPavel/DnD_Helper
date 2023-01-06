using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class SkillsSelectionModel : BindableObject
    {
        public ICommand SelectSkills { get; set;} 

        public int NumberOfSkills => 2;

        public string[] Skills
            => new string[] { "Акробатика", "Атлетика", "Анализ", "Запугивание", "Внимательность", "Выживание"};
    }
}
