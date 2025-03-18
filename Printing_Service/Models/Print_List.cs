namespace Printing_Service.Models
{
    public class Print_List
    {
        public string SID { get; set; }
        public string DName { get; set; }
        public int pages { get; set; }
        public DateTime Date { get; set; }
        public string Printer_Id { get; set; }
        public string Place { get; set; }
    }
}
