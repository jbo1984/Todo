using System.ComponentModel.DataAnnotations;

namespace Todo.Model
{
    public class TodoData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Item { get; set; }

        public bool Done { get; set; }

    }
}
