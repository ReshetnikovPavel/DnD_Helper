
/* Unmerged change from project 'DndHelper.App (net6.0-maccatalyst)'
Before:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DndHelper.Domain.Repositories;
After:
using DndHelper.App.ApplicationClasses;
using DndHelper.Domain.Dnd;
using System.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Repositories;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-ios)'
Before:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DndHelper.Domain.Repositories;
After:
using DndHelper.App.ApplicationClasses;
using DndHelper.Domain.Dnd;
using System.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Repositories;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-android)'
Before:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DndHelper.Domain.Repositories;
After:
using DndHelper.App.ApplicationClasses;
using DndHelper.Domain.Dnd;
using System.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Repositories;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-windows10.0.19041.0)'
Before:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DndHelper.Domain.Repositories;
After:
using DndHelper.App.ApplicationClasses;
using DndHelper.Domain.Dnd;
using System.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Repositories;
*/
using DndHelper.App.ApplicationClasses;
using DndHelper.Domain.Dnd;
/* Unmerged change from project 'DndHelper.App (net6.0-maccatalyst)'
Before:
using DndHelper.Domain.Dnd;
using DndHelper.App.ApplicationClasses;
After:
using System.Threading.Tasks;
using System.Windows.Input;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-ios)'
Before:
using DndHelper.Domain.Dnd;
using DndHelper.App.ApplicationClasses;
After:
using System.Threading.Tasks;
using System.Windows.Input;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-android)'
Before:
using DndHelper.Domain.Dnd;
using DndHelper.App.ApplicationClasses;
After:
using System.Threading.Tasks;
using System.Windows.Input;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-windows10.0.19041.0)'
Before:
using DndHelper.Domain.Dnd;
using DndHelper.App.ApplicationClasses;
After:
using System.Threading.Tasks;
using System.Windows.Input;
*/


namespace DndHelper.App.ViewModels
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
            MessageSender.SendSelectionMade(this, nameof(Character.Class), selectedName);
            MessageSender.SendPageCompleted<ClassSelectionModel>(this);
        }
    }
}
