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

        public async Task<IEnumerable<WorkEntry>> GetDaysEventsAsync(DateTime date)
        {
            var events = await _graphClient.Me.Calendar.CalendarView.Request(new List<QueryOption>() { new QueryOption("startDateTime", date.ToUniversalTime().Date.ToString("s")), new QueryOption("endDateTime", date.ToUniversalTime().AddDays(1).Date.ToString("s")) }).GetAsync();
            
            return GetOutlookEvents(events);
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
