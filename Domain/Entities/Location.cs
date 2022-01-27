namespace Domain.Entities
{
    public class Location 
    {
        public int Id { get; set; }
        public string Voivodeship { get; set; }
        public string County { get; set; }
        public string Municipality { get; set; }
        public string PostalCode { get; set; }  
        public string Locality { get; set; }
        public string Street { get; set; }
        public string HomeCode { get; set; }
    }
}
