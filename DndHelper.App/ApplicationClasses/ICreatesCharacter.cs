using DndHelper.Domain;
using DndHelper.Domain.Dnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.App.ApplicationClasses
{
    public interface ICreatesCharacter
    {
        bool CanCreate();
        public Character Create();
    }
}
