namespace Talabat.presentations.DTOs
{
    public class OrderAddressDto
    {
        public required string FirstName { get; set; }
        public string LastName { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string country { get; set; } = null!;

    }
}
