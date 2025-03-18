namespace Printing_Service.Models
{
    public class Document
    {
        public string Document_ID { get; set; }
        public string A3page { get; set; }
        public int Page { get; set; }
        public string Type { get; set; }
        public string Ratio { get; set; }
        public string Name { get; set; }
        public string Orient { get; set; }
        public int Side {  get; set; }

    }
}
