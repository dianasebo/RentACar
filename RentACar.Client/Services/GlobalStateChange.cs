using System;

namespace RentACar.Client.Services
{
    public class GlobalStateChange
    {

        public void InvokeStateChange()
        {
            this.StateHasChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler StateHasChanged;

    }
}