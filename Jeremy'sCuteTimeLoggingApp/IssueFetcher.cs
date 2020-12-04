using Atlassian.Jira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeremy_sCuteTimeLoggingApp
{
    class IssueFetcher
    {
        Jira _jira;

        public IssueFetcher(Jira jira)
        {
            _jira = jira;
        }

        public Task<IEnumerable<WorkEntry>> GetRecentIssuesAsync()
        {
            return GetIssuesAsync("issue in issueHistory() ORDER BY lastViewed DESC");
        }

        public async Task<IEnumerable<WorkEntry>> GetIssuesAsync(string jql)
        {
            var recentIssues = await _jira.Issues.GetIssuesFromJqlAsync(new IssueSearchOptions(jql));
            return GetJiraIssues(recentIssues);
            //TO-DO: error handling

        }

        private IEnumerable<WorkEntry> GetJiraIssues(IPagedQueryResult<Issue> issues)
        {
            ICollection<WorkEntry> jiraIssues = new List<WorkEntry>();
            foreach(var i in issues)
            {
                jiraIssues.Add(new WorkEntry(false, i.Key.ToString() , i.Summary, i.Description, DateTime.Now, DateTime.Now, _jira.Url + "browse/" + i.Key, i.Reporter, "Jira"));
            }
            return jiraIssues;
        }
    }
}
