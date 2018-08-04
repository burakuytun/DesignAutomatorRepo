using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class ServerInfo
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string ServerType { get; set; }
        public string Location { get; set; }
        public string SpserverName { get; set; }
        public string SpsiteHostName { get; set; }
        public string PhoenixServerName { get; set; }
        public string PhoenixSharedFolder { get; set; }
        public string SqlserverName { get; set; }
        public string SqlconnectionString { get; set; }
        public string SqlreplaceString { get; set; }
        public string WcfserviceUrl { get; set; }
    }
}
