using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Extensions.Storage;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using RentACar.Client.Services;
using RentACar.Shared.Models;

namespace RentACar.Client.Pages
{
    public class LoginBase : BlazorComponent
    {
        [Inject] public HttpClient HttpClient { get; set; }
        [Inject] public IUriHelper UriHelper { get; set; }
        [Inject] public GlobalStateChange GlobalStateChange { get; set; }
        [Inject] public SessionStorage SessionStorage { get; set; }

        public LoginRequest LoginRequest { get; set; } = new LoginRequest();
        public bool InvalidAttempt { get; set; } = false;

        public async Task AttemptLogin()
        {
            var loginResponse = await HttpClient.PostJsonAsync<LoginResponse>("api/Login", LoginRequest);

            if (loginResponse.IsSuccessful) {
                await SaveLoginToken(loginResponse);
                await SaveCurrentUser(loginResponse);
                GlobalStateChange.InvokeStateChange();
                UriHelper.NavigateTo("/");
            }
            else
                PromptInvalidAttempt();
        }

        private async Task SaveCurrentUser(LoginResponse loginResponse) {
            var itemKey = "currentUser";
            var itemValue = loginResponse.User;
            await SessionStorage.SetItem(itemKey, itemValue);
        }

        private async Task SaveLoginToken (LoginResponse loginResponse) 
        {
            var itemKey = "token";
            var itemValue = loginResponse.Token;
            await SessionStorage.SetItem(itemKey, itemValue);
        }

        private void PromptInvalidAttempt()
        {
            InvalidAttempt = true;
            StateHasChanged();
        }
    }
}