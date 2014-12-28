using System;
using System.Data.Entity;
using EhimeEventCalendar.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EhimeEventCalendar.Tests
{
    [TestClass]
    public class TestInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

            Database.SetInitializer(new DropCreateDatabaseAlways<AppDbContext>());
        }
    }
}
