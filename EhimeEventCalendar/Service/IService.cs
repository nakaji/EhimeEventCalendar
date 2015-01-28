using EhimeEventCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EhimeEventCalendar.Service
{
    public interface IService
    {
        EventInfo GetEvent(string url);
    }
}
