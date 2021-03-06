﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EhimeEventCalendar.Models
{
    public class EventInfo
    {
        public EventInfo()
        {
            Title = string.Empty;
            Contents = string.Empty;
            Venue = new Venue();
            Url = string.Empty;
        }

        public int Id { get; set; }

        [Display(Name = "タイトル")]
        public string Title { get; set; }

        [Display(Name = "開始日時")]
        public DateTime StartTime { get; set; }

        [Display(Name = "終了日時")]
        public DateTime EndTime { get; set; }

        [Display(Name = "内容")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Contents { get; set; }

        public Venue Venue { get; set; }

        [Display(Name = "告知サイトURL")]
        public string Url { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }

    public class Venue
    {
        public Venue()
        {
            Name = string.Empty;
            Address = string.Empty;
            Url = string.Empty;
        }

        [Display(Name = "会場名")]
        public string Name { get; set; }

        [Display(Name = "会場住所")]
        public string Address { get; set; }

        [Display(Name = "会場URL")]
        public string Url { get; set; }
    }
}