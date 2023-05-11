using Blog_project.Models;
using Microsoft.AspNetCore.SignalR;

namespace Blog_project.Hubs
{
    public class PostHub:Hub
    {
        public async Task SendPost(Post post, User user)
        {
            //await Clients.All.SendCoreAsync("ReceivePost", new object[] { post });
        }


    }
}
