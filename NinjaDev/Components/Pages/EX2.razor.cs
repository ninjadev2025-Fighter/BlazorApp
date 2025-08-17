namespace NinjaDev.Components.Pages
{
    public partial class EX2
    {
        public string Message = " مرحبا بك";

        public bool changed = false;

        private void ChangeMessage()
        {
            Message += "<br />";
            Message += changed ? "رسالة افتتاحية" : "تم تغيير الرسالة بنجاح";
            Message += "<br />";

            changed = !changed;
        }
    }
}
