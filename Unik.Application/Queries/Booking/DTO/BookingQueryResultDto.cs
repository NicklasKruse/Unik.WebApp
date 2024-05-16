namespace Unik.Application.Queries.Booking.DTO
{
    public class BookingQueryResultDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        //public Domain.ValueObjects.Item Item { get; set; }
        //public List<Item> Items { get; set; }
        public string UserId { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
