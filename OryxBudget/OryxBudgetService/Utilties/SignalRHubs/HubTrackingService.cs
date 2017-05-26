using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxBudgetService.Utilities.SignalRHubs
{
    public class HubTrackingService: IHubTrackingService
    {
        public bool TrackConnection(HubTrack hubTrack)
        {
            // Do some stuff with your repo to keep tracking of connection;
            return true;
        }
    }




    
}
