using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using RssFeeder.Models;

namespace RssFeeder
{
    public class FeedParser
    {
        public Meta RssMeta { get; private set; }
        public List<Article> RssArticles { get; set; }

        public void GetFeeds(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException("Please provide a valid url.");
            }
            var rssReader = new XmlTextReader(url);
            var rssDoc = new XmlDocument();
            rssDoc.Load(rssReader);
            XmlNode channel = null;
            XmlNodeList items = null;
            if (rssDoc.SelectSingleNode("rss/channel") != null)
            {
                channel = rssDoc.SelectSingleNode("rss/channel");
            }
            else if (rssDoc.GetElementsByTagName("feed").Count != 0)
            {
                channel = rssDoc.GetElementsByTagName("feed").Item(0);
            }
            if (channel != null)
            {
                RssMeta = HandleMeta(channel);
                if (rssDoc.SelectNodes("rss/channel/item").Count != 0)
                {
                    items = rssDoc.SelectNodes("rss/channel/item");
                }
                else if (rssDoc.GetElementsByTagName("entry").Count != 0)
                {
                    items = rssDoc.GetElementsByTagName("entry");
                }
                if (items != null)
                {
                    RssArticles = new List<Article>();
                    foreach (XmlNode node in items)
                    {
                        RssArticles.Add(HandleArticle(node, RssMeta));
                    }
                }
            }
            rssReader.Close();
            rssReader.Dispose();
        }
        private Meta HandleMeta(XmlNode node)
        {
            Meta meta = new Meta();
            List<string> categories = new List<string>();
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                switch (node.ChildNodes[i].Name.ToLower())
                {
                    case "title":
                        meta.title = node.ChildNodes[i].InnerText;
                        break;
                    case "description":
                    case "subtitle":
                        meta.description = node.ChildNodes[i].InnerText;
                        break;
                    case "pubdate":
                    case "lastbuilddate":
                    case "published":
                    case "modified":
                    case "updated":
                    case "dc:date":
                        DateTime? date = DateTime.Parse(node.ChildNodes[i].InnerText);
                        if (date == null) break;
                        if (meta.pubdate == null || node.ChildNodes[i].Name == "pubdate" || node.ChildNodes[i].Name == "published")
                        {
                            meta.pubdate = date;
                        }
                        if (meta.date == null || node.ChildNodes[i].Name == "lastbuilddate" || node.ChildNodes[i].Name == "modified" || node.ChildNodes[i].Name == "updated")
                        {
                            meta.date = date;
                        }
                        break;
                    case "link":
                    case "atom:link":
                    case "atom10:link":
                        meta.link = node.ChildNodes[i].InnerText;
                        break;
                    case "managingeditor":
                    case "webmaster":
                    case "author":
                        if (node.ChildNodes[i].Name == "author")
                        {
                            if (node.ChildNodes[i].SelectSingleNode("uri") != null)
                            {
                                meta.author = node.ChildNodes[i].SelectSingleNode("uri").InnerText;
                            }
                            else if (node.ChildNodes[i].SelectSingleNode("email") != null)
                            {
                                meta.author = node.ChildNodes[i].SelectSingleNode("email").InnerText;
                            }
                            else if (node.ChildNodes[i].SelectSingleNode("name") != null)
                            {
                                meta.author = node.ChildNodes[i].SelectSingleNode("name").InnerText;
                            }
                            else
                            {
                                meta.author = node.ChildNodes[i].InnerText;
                            }
                        }
                        break;
                    case "cloud":
                        break;
                    case "language":
                        meta.language = node.ChildNodes[i].InnerText;
                        break;
                    case "image":
                    case "logo":
                        Image image = new Image();
                        if (node.ChildNodes[i].SelectSingleNode("url") != null)
                        {
                            image.url = node.ChildNodes[i].SelectSingleNode("url").InnerText;
                        }
                        if (node.ChildNodes[i].SelectSingleNode("title") != null)
                        {
                            image.title = node.ChildNodes[i].SelectSingleNode("title").InnerText;
                        }
                        else
                        {
                            image.url = node.ChildNodes[i].InnerText;
                        }
                        meta.image = image;
                        break;
                    case "icon":
                        meta.favicon = node.ChildNodes[i].InnerText;
                        break;
                    case "copyright":
                    case "rights":
                    case "dc:rights":
                        meta.copyright = node.ChildNodes[i].InnerText;
                        break;
                    case "generator":
                        break;
                    case "category":
                    case "dc:subject":
                    case "itunes:category":
                    case "media:category":
                        categories.Add(node.ChildNodes[i].InnerText);
                        break;
                }
               
            }
            meta.categories = categories.ToArray();
            return meta;
        }
        private Article HandleArticle(XmlNode node, Meta meta)
        {
            Article article = new Article();
            List<string> categories = new List<string>();
            article.meta = meta;
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                switch (node.ChildNodes[i].Name.ToLower())
                {
                    case "title":
                        article.title = node.ChildNodes[i].InnerText;
                        break;
                    case "description":
                    case "summary":
                        article.summary = node.ChildNodes[i].InnerText;
                        if(String.IsNullOrEmpty(article.description))
                        {
                            article.description = node.ChildNodes[i].InnerText;
                        }
                        break;
                    case "content":
                    case "content:encoded":
                        article.description = node.ChildNodes[i].InnerText;
                        break;
                    case "pubdate":
                    case "published":
                    case "issued":
                    case "modified":
                    case "updated":
                    case "dc:date":
                        DateTime? date = DateTime.Parse(node.ChildNodes[i].InnerText);
                        if (date == null) break;
                        if (article.pubdate == null || node.ChildNodes[i].Name == "pubdate" || node.ChildNodes[i].Name == "published" || node.ChildNodes[i].Name == "issued")
                        {
                            article.pubdate = date;
                        }
                        if (article.date == null || node.ChildNodes[i].Name == "modified" || node.ChildNodes[i].Name == "updated")
                        {
                            article.date = date;
                        }
                        break;
                    case "link":
                        article.link = node.ChildNodes[i].InnerText;
                        break;
                    case "guid":
                    case "id":
                        article.guid = node.ChildNodes[i].InnerText;
                        break;
                    case "author":
                        article.author = node.ChildNodes[i].InnerText;
                        break;
                    case "dc:creator":
                        article.author = node.ChildNodes[i].InnerText;
                        break;
                    case "comments":
                        article.comments = node.ChildNodes[i].InnerText;
                        break;
                    case "source":
                        break;
                    case "enclosure":
                        break;
                    case "media:content":
                        break;
                    case "enc:enclosure":
                        break;
                    case "category":
                    case "dc:subject":
                    case "itunes:category":
                    case "media:category":
                        categories.Add(node.ChildNodes[i].InnerText);
                        break;
                    case "feedburner:origlink":
                    case "pheedo:origlink":
                        if (String.IsNullOrEmpty(article.origlink))
                        {
                            article.origlink = node.ChildNodes[i].InnerText;
                        }
                        break;
                }
            }
            article.categories = categories.ToArray();
            return article;
        }
    }
}
