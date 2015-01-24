using EhimeEventCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Codeplex.Data;

namespace EhimeEventCalendar.Service
{
    public class Doorkeeper
    {
        public EventInfo GetById(int id)
        {
            var url = "http://api.doorkeeper.jp/events/{0}";

            var @event = new EventInfo();

            using (var wc = new WebClient())
            {
                string res;
                try
                {
                    res = wc.DownloadString(string.Format(url, id));
                }
                catch (WebException e)
                {
                    return new EventInfo();
                }
                var json = DynamicJson.Parse(res);
                @event.Title = @json.@event.title;
                @event.StartTime = DateTime.Parse( @json.@event.starts_at);
                @event.EndTime =DateTime.Parse(@json.@event.ends_at);
                @event.Contents = @json.@event.description;
                @event.Url = @json.@event.public_url;
                @event.Venue.Name = @json.@event.venue_name;
            }

            return @event;
        }
    }
}
