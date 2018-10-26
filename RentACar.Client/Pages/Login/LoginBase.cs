using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Extensions.Storage;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using RentACar.Shared.Models;

namespace RentACar.Client.Pages
{
    public class LoginBase : BlazorComponent
    {
        [Inject] public HttpClient HttpClient { get; set; }
        [Inject] public IUriHelper UriHelper { get; set; }
        [Inject] public SessionStorage SessionStorage { get; set; }

        public LoginRequest LoginRequest { get; set; } = new LoginRequest();
        public bool InvalidAttempt { get; set; } = false;

        public async Task AttemptLogin()
        {
            var loginResponse = await HttpClient.PostJsonAsync<LoginResponse>("api/Login", LoginRequest);

            if (loginResponse.IsSuccessful) {
                await SaveLoginToken(loginResponse);
                UriHelper.NavigateTo("/");
            }
            else
                PromptInvalidAttempt();
        }

        private async Task SaveLoginToken (LoginResponse loginResponse) 
        {
            var tokenKey = "token";
            var tokenValue = loginResponse.Token;
            await SessionStorage.SetItem(tokenKey, tokenValue);
        }

        private void PromptInvalidAttempt()
        {
            InvalidAttempt = false;
            StateHasChanged();
        }
    }
}