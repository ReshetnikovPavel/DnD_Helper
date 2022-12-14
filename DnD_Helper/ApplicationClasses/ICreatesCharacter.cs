using DndHelper.Domain;
using DndHelper.Domain.Dnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    public interface ICreatesCharacter
    {
        void SubscribeToModel<TModel>() where TModel : BindableObject;
        bool CanCreate();
        public Character Create();
    }
}
