using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaverTail.API.BLL
{
    public class LogConfiguration
    {
        public string ApplicationName { get; set; }

        public List<string> ServerList { get; set; }

        public List<string> RelativeLogPaths { get; set; }

        public string SelfLink => $"/api/logconfiguration/applications/{ApplicationName}";
    }
}
