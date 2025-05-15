using System.ComponentModel.DataAnnotations;

namespace Demo.Areas.Admin.Models
{
    public class UpdateAuthorModel
    {

        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Biography { get; set; }
        [Required]
        public double Rating { get; set; }


    }
}
