using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Layouts;
using Microsoft.AspNetCore.Blazor.Services;
using RentACar.Shared.Models;

namespace RentACar.Client.Pages
{
    public class RegisterBase : BlazorLayoutComponent
    {
        [Inject] public HttpClient HttpClient { get; set; }
        [Inject] public IUriHelper UriHelper { get; set; }
        
        public RegistrationRequest RegistrationRequest { get; set; } = new RegistrationRequest();
        public string ConfirmPassword { get; set; }
        public Dictionary<string, IEnumerable<string>> Errors { get; private set; }

        public bool PasswordsMatch => string.IsNullOrEmpty(RegistrationRequest.Password) 
                                   || string.IsNullOrEmpty(ConfirmPassword)
                                   || string.Equals(RegistrationRequest.Password, ConfirmPassword);
                                   
        public bool ValidEmail => string.IsNullOrEmpty(RegistrationRequest.Email)
                               || new EmailAddressAttribute().IsValid(RegistrationRequest.Email);

        public async Task RegisterUser()
        {
            if (ValidEmail && PasswordsMatch)
                await AttemptRegistration();
        }

        private async Task AttemptRegistration() 
        {
            var registrationResponse = await HttpClient.PostJsonAsync<RegistrationResponse> ("api/Registration", RegistrationRequest);

            if (registrationResponse.IsSuccessful)
                UriHelper.NavigateTo ("/success");
            else
            {
                Errors = registrationResponse.Errors;
                StateHasChanged ();
            }
        }

        public void Cancel()
        {
            UriHelper.NavigateTo("/index");
        }

    }
}