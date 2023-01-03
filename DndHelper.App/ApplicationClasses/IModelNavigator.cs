using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.App.ApplicationClasses
{
    public interface IModelNavigator
    {
        void AddModel<TModel>() where TModel : BindableObject;
        bool TryGoToNextRoute(string currentRoute);
    }
}

