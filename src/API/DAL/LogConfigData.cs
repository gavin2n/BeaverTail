using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaverTail.API.DAL
{
    public class LogConfigData
    {
        public string Id { get; set; }

        public List<string> ServerList { get; set; }

        public List<string> RelativeLogPaths { get; set; }
    }
}
