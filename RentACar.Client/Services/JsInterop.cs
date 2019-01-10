using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;

namespace RentACar.Client.Services
{
    public static class JsInterop
    {
        
        public static async Task<IEnumerable<string>> GetPicturesAsStrings(string fileInputRef)
        {
            var pictures = await JSRuntime.Current.InvokeAsync<IEnumerable<StringHolder>>("getPicturesData", fileInputRef);
            return pictures.Select(picture => picture.Content);
        }
        
        public static async Task ToggleFilters()
        {
            await JSRuntime.Current.InvokeAsync<Task>("toggleFilters");
        }        

        public static async Task ToggleModal(string modalId) {
            await JSRuntime.Current.InvokeAsync<Task>("toggleModal", modalId);
        }
        
        private class StringHolder
        {
            public string Content { get; set; }
        }
    }
}