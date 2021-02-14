using EkinKececiBlogSite.Models.DataContext;
using EkinKececiBlogSite.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Web;

namespace EkinKececiBlogSite
{
    
    public class Monitizer
    {

        EkinDBContext db = new EkinDBContext();
        public void AddLog(string text)
        {
            Logs lg = new Logs();
            lg.LogDate = DateTime.Now;
            lg.MethodLog = text;

            db.Logs.Add(lg);

        }

    }
}