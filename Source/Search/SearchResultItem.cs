using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoiceVideoDownloader
{
    public class SearchResultItem
    {

        private string thumbnailURL;
        public string ThumbnailURL
        {
            get { return thumbnailURL; }
            set { thumbnailURL = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string discripion;
        public string Discripion
        {
            get { return discripion; }
            set { discripion = value; }
        }

        private string sourceUrl;
        public string SourceUrl
        {
            get { return sourceUrl; }
            set { sourceUrl = value; }
        }
    }
}
