namespace Lab4.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }
        public string Status { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
