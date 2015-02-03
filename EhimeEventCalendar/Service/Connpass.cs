using EhimeEventCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Codeplex.Data;

namespace EhimeEventCalendar.Service
{
    public class Connpass:IService
    {
        private EventInfo GetEvent(int id)
        {
            var url = "http://connpass.com/api/v1/event/?format=json&event_id={0}";

            var @event = new EventInfo();

            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string res;
                try
                {
                    res = wc.DownloadString(string.Format(url, id));
                }
                catch (WebException e)
                {
                    return new EventInfo();
                }
                var json = DynamicJson.Parse(res).events[0];
                @event.Title = @json.title;
                @event.StartTime = DateTime.Parse(@json.started_at);
                @event.EndTime = DateTime.Parse(@json.ended_at);
                @event.Contents = @json.description;
                @event.Url = @json.event_url;
                @event.Venue.Name = @json.place;
                @event.Venue.Address = @json.address;
            }

            return @event;
        }

        public EventInfo GetEvent(string url)
        {
            var match = Regex.Match(url, "event/(?<EventId>[0-9]+)/");

            if (match.Groups.Count <= 1) return null;

            var eventId = match.Groups["EventId"].Value;

            return GetEvent(int.Parse(eventId));
        }
    }
}