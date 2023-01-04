
/* Unmerged change from project 'DndHelper.App (net6.0-maccatalyst)'
Before:
using System;
After:
using DndHelper.App.Authentication;
using System;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-ios)'
Before:
using System;
After:
using DndHelper.App.Authentication;
using System;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-android)'
Before:
using System;
After:
using DndHelper.App.Authentication;
using System;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-windows10.0.19041.0)'
Before:
using System;
After:
using DndHelper.App.Authentication;
using System;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-maccatalyst)'
Before:
using System.Threading.Tasks;
using DndHelper.App.Authentication;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-ios)'
Before:
using System.Threading.Tasks;
using DndHelper.App.Authentication;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-android)'
Before:
using System.Threading.Tasks;
using DndHelper.App.Authentication;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-windows10.0.19041.0)'
Before:
using System.Threading.Tasks;
using DndHelper.App.Authentication;
After:
using System.Threading.Tasks;
*/
namespace DndHelper.App.Database
{
    public interface IDatabaseClient
    {
        IDatabaseQuery Child(string name);
        void SignIn<T>(User<T> user);
    }
}
