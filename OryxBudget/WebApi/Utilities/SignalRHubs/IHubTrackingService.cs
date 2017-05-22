using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.Utilities.SignalRHubs
{
    public interface IHubTrackingService
    {
        bool TrackConnection(HubTrack hubTrack);
    }
}
