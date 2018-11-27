using System;
using System.Threading.Tasks;
using Blazor.Extensions.Storage;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Layouts;
using Microsoft.AspNetCore.Blazor.Services;
using RentACar.Client.Services;
using RentACar.Shared.Models;

namespace RentACar.Client.Shared
{
    public class NavMenuBase : BlazorLayoutComponent
    {
        [Inject] public GlobalStateChange GlobalStateChange { get; set; }
        [Inject] public SessionStorage SessionStorage { get; set; }
        [Inject] public IUriHelper UriHelper { get; set; }

        public User CurrentUser { get; set; }

        protected async override Task OnInitAsync()
        {
            GlobalStateChange.StateHasChanged += UserLoggedIn;
            CurrentUser = await SessionStorage.GetItem<User>("currentUser");
            StateHasChanged();
        }

        private async void UserLoggedIn(object sender, EventArgs e) {
            CurrentUser = await SessionStorage.GetItem<User>("currentUser");
            StateHasChanged();
        }

        protected async Task OnLogoutClick()
        {
            await SessionStorage.RemoveItem("token");
            await SessionStorage.RemoveItem("currentUser");
            GlobalStateChange.InvokeStateChange();
        }
    }
}