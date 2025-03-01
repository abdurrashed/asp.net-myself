namespace Demo.Areas.Admin.Models
{
    public class AddBookModel
    {

        public string Title { get; set; }
        public Guid? AuthorId { get; set; }
        public DateTime? PublisDate { get; set; }



    }
}
