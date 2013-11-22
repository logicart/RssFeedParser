using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeeder
{
    public static class Namespaces
    {
        public static readonly Dictionary<string, string> NS = new Dictionary<string, string> 
        { 
            {"http://www.w3.org/2005/Atom", "atom"},
            {"http://purl.org/atom/ns#", "atom"},
            {"http://www.w3.org/1999/02/22-rdf-syntax-ns#", "rdf"},
            {"http://purl.org/rss/1.0/", "rdf"},
            {"http://my.netscape.com/rdf/simple/0.9/", "rdf"},
            {"http://webns.net/mvcb/", "admin"},
            {"http://creativecommons.org/ns#", "cc"},
            {"http://web.resource.org/cc/", "cc"},
            {"http://purl.org/rss/1.0/modules/content/", "content"},
            {"http://backend.userland.com/creativeCommonsRSSModule", "creativecommons"},
            {"http://cyber.law.harvard.edu/rss/creativeCommonsRssModule.html", "creativecommons"},
            {"http://purl.org/dc/elements/1.1/", "dc"},
            {"http://purl.org/dc/elements/1.0/", "dc"},
            {"http://purl.oclc.org/net/rss_2.0/enc#", "enc"},
            {"http://rssnamespace.org/feedburner/ext/1.0", "feedburner"},
            {"http://www.itunes.com/dtds/podcast-1.0.dtd", "itunes"},
            {"http://www.w3.org/2003/01/geo/wgs84_pos#", "geo"},
            {"http://www.georss.org/georss", "georss"},
            {"http://search.yahoo.com/mrss/", "media"},
            {"http://search.yahoo.com/mrss", "media"},
            {"http://www.pheedo.com/namespace/pheedo", "pheedo"},
            {"http://purl.org/rss/1.0/modules/syndication/", "syn"},
            {"http://feedsync.org/2007/feedsync", "sx"}, 
            {"http://purl.org/rss/1.0/modules/taxonomy/", "taxo"},
            {"http://purl.org/syndication/thread/1.0", "thr"},
            {"http://www.w3.org/1999/xhtml", "xhtml"},
            {"http://www.w3.org/XML/1998/namespace", "xml"}
        };

    }
}
