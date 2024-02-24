namespace MusicStore.Entities
{
    public class Concert
    {
        public int id { get; set; }
        public string Title { get; set; } = default!; //default! it is same to string.empty
        public string Description { get; set; } = default!;
        public string Place { get; set; } = default!;
        public decimal UnitPrice { get; set; }
        public DateTime DateEvent { get; set; }
        public int TicketsQuantity { get; set; }
        public bool Status { get; set; } = true;
        public bool Finalized { get; set; }
        public int GenreId { get; set; }
        public string? ImageUrl { get; set; }


        //Navigation Properties
        public Genre Genre { get; set; } = default!;
    }
}
