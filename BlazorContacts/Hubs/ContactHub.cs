using BlazorContacts.Pages;
using Microsoft.AspNetCore.SignalR;

namespace BlazorContacts.Hubs
{
    public class ContactHub: Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage");
        }
    }
}
