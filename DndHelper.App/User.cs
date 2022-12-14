using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DndHelper.Infrastructure;

namespace DndHelper.App
{
    public class User : Entity<Guid>
    {
        public User(Guid id) : base(id)
        {
        }
    }
}
