using DnD_Helper.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Windows.Input;
using Domain.Repositories;

namespace DnD_Helper.ViewModels
{
    public class ClassSelectionModel : BindableObject
    {
        public ICommand SelectClass { get; }
        private IClassRepository classRepository;

        public ClassSelectionModel(IClassRepository classRepository) 
        {
            this.classRepository = classRepository;

            SelectClass = new Command<string>(OnClassSelected);
        }

        public IEnumerable<string> ClassNames => classRepository.GetNames();

        private void OnClassSelected(string selectedName)
        {
            MessageSender.SendAttributeSelected<Class>(this, selectedName);
            SendPageCompletedMessage(); //TODO: Я не знаю почему, но если заменить на точно такой же метод, но в MessageSender, то переход ломается
        }

        private void SendPageCompletedMessage()
        {
            MessagingCenter.Send<BindableObject, string>(this, Messages.PageCompleted.ToString(),
                nameof(ClassSelectionModel));
        }
    }
}
