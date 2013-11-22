using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeeder.Models
{
    public struct Meta
    {
        /*
        #ns {Array} key,value pairs of each namespace declared for the feed
        #type {String} one of 'atom', 'rss', 'rdf'
        #version {String}
        title {String}
        description {String}
        date {Date} (or null)
        pubdate {Date} (or null)
        link {String} i.e., to the website, not the feed
        xmlurl {String} the canonical URL of the feed, as declared by the feed
        author {String}
        language {String}
        image {Object}
        favicon {String}
        copyright {String}
        generator {String}
        categories {Array}
         */

        public string[] ns;
        public string type;
        public string version;
        public string title;
        public string description;
        public DateTime? date;
        public DateTime? pubdate;
        public string link;
        public string xmlurl;
        public string author;
        public string language;
        public Image image;
        public string favicon;
        public string copyright;
        public string generator;
        public string[] categories;
    }
}
