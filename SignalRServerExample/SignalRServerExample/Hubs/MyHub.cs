using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRServerExample.Hubs
{
    public class MyHub : Hub <IMessageClient>
    {
        public static List<string> clients = new List<string>();
        //public async Task SendMessageAsync(string message)
        //{
        //    await Clients.All.SendAsync("receiveMessage" , message);
        //}

        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userJoined", Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);

        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserLeaved(Context.ConnectionId);
        }
    }
}
