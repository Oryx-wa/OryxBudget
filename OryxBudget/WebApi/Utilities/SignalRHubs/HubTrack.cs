using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.Utilities.SignalRHubs
{
    public class HubTrack
    {
        public string HubName { get; set; }
        public string UserId { get; set; }
        public string ConnectionId { get; set; }
        public DateTime ConnectionTime { get; set; }
    }
}
