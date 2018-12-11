using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Blazor.Extensions.Storage;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using RentACar.Shared.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Blazor.Services;

namespace RentACar.Client.Pages
{
    public class InboxBase : BlazorComponent
    {
        [Inject] SessionStorage SessionStorage { get; set; }
        [Inject] HttpClient HttpClient { get; set; }

        [Inject] IUriHelper UriHelper { get; set; }
        public Dictionary<User, IList<Message>> Conversations { get; set; }
        public IList<Message> SelectedConversation { get; set; }
        [Parameter] private int OtherUserId { get; set; }

        public User CurrentUser { get; set; }
        public User OtherUser { get; set; }
        public string MessageText { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            OtherUser = await HttpClient.GetJsonAsync<User>($"api/Users/{OtherUserId}");
        }

        protected override async Task OnInitAsync() 
        {
            var token = await SessionStorage.GetItem<string>("token");
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            CurrentUser = await SessionStorage.GetItem<User>("currentUser");

            var messages = await 
            HttpClient.GetJsonAsync<IEnumerable<Message>>($"api/Messages/{CurrentUser.UserId}");

            Conversations = new Dictionary<User, IList<Message>>();
            foreach (var message in messages) {
                if (message.SenderId == CurrentUser.UserId) 
                {
                    if(!Conversations.ContainsKey(message.Receiver))
                        Conversations.Add(message.Receiver, new List<Message>());
                    Conversations[message.Receiver].Add(message);
                }
                else
                {
                    if(!Conversations.ContainsKey(message.Sender))
                        Conversations.Add(message.Sender, new List<Message>());
                    Conversations[message.Sender].Add(message);
                }
            }
        }

        public string GetFloatValue(Message message)
        {
            return message.SenderId == CurrentUser.UserId ? "right" : "left";
        }

        public async Task SendMessage() 
        {
            var message = new Message 
                {
                    SenderId = CurrentUser.UserId,
                    ReceiverId = OtherUser.UserId,
                    Text = MessageText,
                    Timestamp = DateTime.Now
                };
            await HttpClient.PostJsonAsync<GenericResponse>($"api/Messages/Send", message);
            StateHasChanged();
        }

        // public DateTime GetTimeOfLastMessageWith(User user)
        // {
        //     return Conversations.Where(kvp => kvp.Key == user).Single().Value.OrderBy(m => m.Timestamp).Single().Timestamp;
        // }
    }
}