using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    public interface ICreatesCharacter
    {
        public void SubscribeToModel<TModel>() where TModel : BindableObject;
        public bool CanCreate();
        public Character Create();
    }
}
