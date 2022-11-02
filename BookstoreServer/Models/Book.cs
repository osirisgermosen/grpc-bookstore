namespace BookstoreServer.Models
{
    public class Book
    {
        public int Id { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'Title' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Title { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Title' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Author' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Author { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Author' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Isbn' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Isbn { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Isbn' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public int Year { get; set; }
    }
}
