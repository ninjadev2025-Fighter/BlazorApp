using Microsoft.JSInterop;

namespace NinjaDev.Components.Pages
{
    public partial class Ex5
    {
        private List<string> Colors = new() { "red", "green", "black", "orange" };

        private async Task Change(string color)
        {
            await JS.InvokeVoidAsync("console.log", $"clicked {color}");
            await JS.InvokeVoidAsync("changeBackgroundColor", color);
        }
    }
}
