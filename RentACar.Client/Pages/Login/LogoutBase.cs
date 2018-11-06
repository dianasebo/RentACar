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
    public class LogoutBase : BlazorComponent
    {        
        [Inject] public GlobalStateChange GlobalStateChange { get; set; }
        [Inject] public SessionStorage SessionStorage { get; set; }

        protected override async Task OnInitAsync()
        {
            await SessionStorage.RemoveItem("token");
            await SessionStorage.RemoveItem("currentUser");
            GlobalStateChange.InvokeStateChange();
        }
    }
}