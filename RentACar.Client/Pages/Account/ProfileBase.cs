using System.Threading.Tasks;
using Blazor.Extensions.Storage;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Layouts;
using Microsoft.AspNetCore.Blazor.Services;
using RentACar.Shared.Models;

namespace RentACar.Client.Pages
{
    public class ProfileBase : BlazorLayoutComponent
    {
        [Inject] public SessionStorage SessionStorage { get; set; }        
        [Inject] public IUriHelper UriHelper { get; set; }
        public User CurrentUser { get; set; }
        public string SelectedPage { get; set; }
        protected override async Task OnInitAsync() 
        {
            CurrentUser = await SessionStorage.GetItem<User>("currentUser");
            System.Console.WriteLine(CurrentUser);
            if (CurrentUser == null)
                UriHelper.NavigateTo("/login");
        }
    }
}