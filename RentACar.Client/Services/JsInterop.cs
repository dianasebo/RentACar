using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;

namespace RentACar.Client
{
    public static class JsInterop
    {
        
        public static async Task<string> GetFileData(string fileInputRef)
        {
            return (await JSRuntime.Current.InvokeAsync<StringHolder>("getFileData", fileInputRef)).Content;
        }
        
        public static async Task ToggleFilters()
        {
            await JSRuntime.Current.InvokeAsync<Task>("toggleFilters");
        }

        private class StringHolder
        {
            public string Content { get; set; }
        }
    }
}