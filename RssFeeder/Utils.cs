using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeeder
{
    public static class Utils
    {
        public static bool NSLookup(string uri, string def)
        {
            return Namespaces.NS[uri] == def;
        }

        public static string NSPrefix(string uri)
        {
            return Namespaces.NS[uri];
        }
    }
}
 