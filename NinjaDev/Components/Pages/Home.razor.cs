using Microsoft.AspNetCore.Components;

namespace NinjaDev.Components.Pages
{
    public partial class Home
    {
        public int number = 2;

        [Parameter]
        public string StudentName { get; set; }



        private void ChangeNumber()
        {
            number *= 2;
        }
    }
}
