using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EkinKececiBlogSite.Models.Model
{
    public class Logs
    {
        [Key]
        public int Logid { get; set; }
        public string MethodLog { get; set; }
        public DateTime LogDate { get; set; }
    }
}