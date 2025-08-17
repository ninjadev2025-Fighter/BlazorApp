using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace NinjaDev.Components.Pages
{
    public partial class EX3
    {
        public string Message = "احمد";
        public List<string> Students = new() { "احمد", "محمد", "كامل", "احمد", "محمد"};


        private void AddStudent(KeyboardEventArgs e)
        {
            if (e.Key == "Enter" && !string.IsNullOrEmpty(Message))
                Students.Add(Message);
        }




        private async Task RemoveStudent(int index)
        {
            Console.WriteLine(index);
            Students.RemoveAt(index);
        }















        //private void RemoveStudent(int index)
        //{
        //    Console.Write(index);
        //    Students.RemoveAt(index);
        //}
    }
}
