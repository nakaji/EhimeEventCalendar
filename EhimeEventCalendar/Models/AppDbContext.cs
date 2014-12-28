using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EhimeEventCalendar.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<EventInfo> EventInfos { get; set; }
    }
}