using System.ComponentModel.DataAnnotations;

namespace UserTaskMananger.Entities
{
    public class Priority
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        public void Copy(Priority priority)
        {
            Name = priority.Name;
        }
    }
}
