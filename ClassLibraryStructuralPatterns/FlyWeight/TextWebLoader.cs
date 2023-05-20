using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStructuralPatterns.FlyWeight
{
    public class TextWebLoader
    {
        private string href;

        public TextWebLoader(string href)
        {
            this.href = href;
        }

        public string GetText()
        {
            WebClient wc = new WebClient();
            byte[] raw = wc.DownloadData(href);

            string webData = Encoding.UTF8.GetString(raw);

            return webData;
        }
    }
}
