using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Firebase.Adapters
{
    public class FirebaseDatabaseUrl
    {
        public string Url { get; }
        public FirebaseDatabaseUrl(string url) 
        {
            Url = url;
        }
    }
}
