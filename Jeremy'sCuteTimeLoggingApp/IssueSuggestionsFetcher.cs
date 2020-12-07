using Atlassian.Jira;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeremy_sCuteTimeLoggingApp
{
    class IssueSuggestionsFetcher
    {

        public async Task<IEnumerable<IssueSuggestion>> GetWorkEntriesAsync(string text)
        {
            ICollection<IssueSuggestion> issueSuggestions = new List<IssueSuggestion>();
            var suggestions = await GetSuggestions(text);
            var issues = suggestions["sections"][0]["issues"];
            foreach (var issue in issues)
            {
                issueSuggestions.Add(new IssueSuggestion(issue["id"].ToString(), issue["key"].ToString(), issue["keyHtml"].ToString(), issue["img"].ToString(), issue["summary"].ToString(), issue["summaryText"].ToString()));
            }
            return issueSuggestions;
        }

        private Task<JToken> GetSuggestions(string text)
        {
            return App.JiraClient.RestClient.ExecuteRequestAsync(RestSharp.Method.GET, $"/rest/api/3/issue/picker?query={text}");
        }
    }
}
