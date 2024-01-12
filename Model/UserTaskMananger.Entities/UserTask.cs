using System.ComponentModel.DataAnnotations;

namespace UserTaskMananger.Entities
{
    public class UserTask
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string Tags { get; set; }
        [Required]
        public bool Finished { get; set; } = false;
        [Required]
        public bool Deleted { get; set; } = false;
        [Required]
        public DateTime ExpirationAt { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PriorityId { get; set; }


        [Required]
        public User User { get; set; }
        [Required]
        public Priority Priority { get; set; }

        public void Copy(UserTask userTask)
        {
            Description = userTask.Description;
            Tags = userTask.Tags;
            Finished = userTask.Finished;
            Deleted = userTask.Deleted;
            ExpirationAt = userTask.ExpirationAt;
            UpdatedAt = userTask.UpdatedAt;
            UserId = userTask.UserId;
            PriorityId = userTask.PriorityId;
        }
    }
}