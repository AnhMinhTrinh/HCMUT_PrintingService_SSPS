using Microsoft.Identity.Client;

namespace Printing_Service.Models
{
    public class Printer
    {
        public string PrinterID { get; set;}
        public int Paper_exist { get; set; }
        public string PlaceAt {  get; set; }
        public string isDisable { get; set; }

    }
}
