using System.ComponentModel.DataAnnotations;

namespace repos.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; } // this will be treated as primary key
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}