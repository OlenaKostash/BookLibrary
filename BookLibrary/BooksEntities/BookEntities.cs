namespace BookLibrary.Entities
{
    public class BookEntities: IEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int LibraryId { get; set; }
        public int Id { get; set ; }
    }
}
