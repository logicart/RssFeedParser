using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeeder.Models
{
    public struct Article
    {
        /*
        title {String}
        description {String}
        summary {String}
        date {Date} (or null)
        pubdate {Date} (or null)
        link {String}
        origlink {String}
        author {String}
        guid {String}
        comments {String}
        image {Object}
        categories {Array}
        source {Object}
        enclosures {Array}
        meta {Object}
         */

        public string title;
        public string description;
        public string summary;
        public DateTime? date;
        public DateTime? pubdate;
        public string link;
        public string origlink;
        public string author;
        public string guid;
        public string comments;
        public Image image;
        public string[] categories;
        //Source
        public string[] enclosures;
        public Meta meta;
    }
}
