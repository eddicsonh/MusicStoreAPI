namespace MusicStore.Entities.Info
{
    public class ConcertInfo
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Place { get; set; } = default!;
        public decimal UnitePrice { get; set; }
        public int GenreId { get; set; }
        public string Genre { get; set; } = default!;
        public string DateEvent { get; set; } = default!;
        public string TimeEvent { get; set; } = default!;
        public string? ImageUrl { get; set; } = default!;
        public int TicketQuantity { get; set; }
        public bool Finalized { get; set; }
        public string Status { get; set; } = default!;
    }
}
