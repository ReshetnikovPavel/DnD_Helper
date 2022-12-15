using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DndHelper.App.Authentication;

namespace DndHelper.App.Database
{
    public interface IDatabaseClient
    {
        IDatabaseQuery Child(string name);
        void SignIn<T>(User<T> user);
    }
}
