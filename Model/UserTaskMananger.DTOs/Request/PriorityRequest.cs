using System.ComponentModel.DataAnnotations;
using UserTaskMananger.Entities;

namespace UserTaskMananger.DTOs.Request
{
    public class PriorityRequest
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public Priority ToEntity(int id = 0)
        {
            return new Priority { Name = this.Name };
        }
    }
}
