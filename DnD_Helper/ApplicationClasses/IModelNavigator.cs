using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    public interface IModelNavigator
    {
        void AddModel<TModel>() where TModel : BindableObject;
        bool TryGoToNextRoute(string currentRoute);
    }
}

