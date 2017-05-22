using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace OryxWebApi.Utilities.SignalRHubs
{
    public class NotificationHub : Hub<INotification>
    {
        private readonly IHubTrackingService hubTrackingService;

        public NotificationHub(IHubTrackingService hubTrackingService)
        {
            this.hubTrackingService = hubTrackingService;
        }

        public override Task OnConnected()
        {
            RegisterConnection();
            // Set connection id for just connected client only
            return Clients.Client(Context.ConnectionId).SetConnectionId(Context.ConnectionId);
        }

        // Server side methods called from client
        public Task Subscribe(int matchId)
        {
            return Groups.Add(Context.ConnectionId, matchId.ToString());
        }

        public Task Unsubscribe(int matchId)
        {
            return Groups.Remove(Context.ConnectionId, matchId.ToString());
        }

        private void RegisterConnection()
        {
            this.hubTrackingService.TrackConnection(new HubTrack()
            {
                ConnectionId = Context.ConnectionId,
                HubName = nameof(NotificationHub),
                UserId = Context.User?.Identity?.Name ?? string.Empty,
                ConnectionTime = DateTime.UtcNow
            });
        }
    }

    // Client side methods to be invoked by Broadcaster Hub
    public interface INotification
    {
        Task SetConnectionId(string connectionId);
        //Task UpdateMatch(MatchViewModel match);
        //Task AddFeed(FeedViewModel feed);
        //Task AddChatMessage(ChatMessage message);
    }
}
