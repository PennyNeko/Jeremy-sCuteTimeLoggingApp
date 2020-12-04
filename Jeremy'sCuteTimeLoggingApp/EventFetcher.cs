using Microsoft.Graph;
using Microsoft.Graph.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

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

        public async Task<IEnumerable<WorkEntry>> GetDaysEventsAsync(DateTime date)
        {
            var events = await _graphClient.Me.Events.Request().GetAsync();
            return GetOutlookEvents(events.Where(x => x.Start.ToDateTime().Date == date.Date));
        }

        private IEnumerable<WorkEntry> GetOutlookEvents(IEnumerable<Event> events)
        {
            ICollection<WorkEntry> eventList = new List<WorkEntry>();
            foreach (var ev in events)
            {
                eventList.Add(new WorkEntry(true, "MT-19" ,ev.Subject, ev.BodyPreview, ev.Start.ToDateTime(), ev.End.ToDateTime(), ev.WebLink, ev.Organizer.EmailAddress.Name, "Outlook"));
            }           
            return eventList;   
        }
    }

}
