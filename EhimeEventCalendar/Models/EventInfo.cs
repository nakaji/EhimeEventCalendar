using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Web;

namespace EhimeEventCalendar.Models
{
    public class EventInfo
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }
        
        public string PlaceName { get; set; }
        
        public string PlaceAddress { get; set; }
        
        public string PlaceUrl { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; } 
    }
}