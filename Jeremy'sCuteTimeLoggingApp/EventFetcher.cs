using Microsoft.Graph;
using Microsoft.Graph.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jeremy_sCuteTimeLoggingApp
{
    class EventFetcher
    {
        GraphServiceClient _graphClient;

        public EventFetcher(GraphServiceClient graphClient)
        {
            _graphClient = graphClient;
        }

        public async Task<IEnumerable<WorkEntry>> GetEventsAsync()
        {
            var events = await _graphClient.Me.Events.Request().GetAsync();
            return GetOutlookEvents(events);
            //TO-DO: error handling

        }

        private IEnumerable<WorkEntry> GetOutlookEvents(IUserEventsCollectionPage events)
        {
            ICollection<WorkEntry> eventList = new List<WorkEntry>();
            foreach (var ev in events)
            {
                eventList.Add(new WorkEntry(ev.Subject, ev.BodyPreview, ev.Start.ToDateTime(), ev.End.ToDateTime(), ev.WebLink, ev.Organizer.EmailAddress.Name, "Outlook"));
            }
            return eventList;
        }
    }

}
