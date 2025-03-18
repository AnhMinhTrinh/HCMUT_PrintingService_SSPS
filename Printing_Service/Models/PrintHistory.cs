namespace Printing_Service.Models
{
    public class PrintHistory
    {
        public DateTime Date { get; set; }
        
        public string FileName { get; set; }

        public string PageA4 { get; set; }

        public string Printer_Id { get; set; }

        public int Side { get; set; }

        public string Ratio{ get; set; }
        public string Orient { get; set; }

    }
}
