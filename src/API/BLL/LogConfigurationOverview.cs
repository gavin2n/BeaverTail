using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaverTail.API.BLL
{
    public class LogConfigurationOverview
    {
        public string ApplicationName { get; set; }

        public string MoreInformation => $"/api/logconfiguration/applications/{ApplicationName}";
    }
}
