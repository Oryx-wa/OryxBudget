using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxBudgetService.Utilities.SignalRHubs
{
    public interface IHubTrackingService
    {
        bool TrackConnection(HubTrack hubTrack);
    }
}
