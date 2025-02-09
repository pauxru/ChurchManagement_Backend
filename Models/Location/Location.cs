namespace Churchmanagement.Models
{
    public class Location
    {
        public int Id { get; set; } // Primary key
        public string? Address { get; set; }
        public double Latitude { get; set; } // Geographical latitude
        public double Longitude { get; set; } // Geographical longitude
        public string? Region { get; set; } // Optional region or city name

        // Method to generate a Google Maps link dynamically
        public string GetGoogleMapsUrl()
        {
            return $"https://www.google.com/maps?q={Latitude},{Longitude}";
        }
    }
}

