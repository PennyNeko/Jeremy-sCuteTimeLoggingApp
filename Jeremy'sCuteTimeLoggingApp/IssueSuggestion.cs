using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeremy_sCuteTimeLoggingApp
{
    class IssueSuggestion
    {
        public IssueSuggestion(string id, string key, string keyHtml, string img, string summary, string summaryText)
        {
            Id = id;
            Key = key;
            KeyHtml = keyHtml;
            Img = img;
            Summary = summary;
            SummaryText = summaryText;
        }

        string Id { set; get; }
        string Key { set; get; }
        string KeyHtml { set; get; }
        string Img { set; get; }
        string Summary { set; get; }
        string SummaryText { set; get; }
    }
}
