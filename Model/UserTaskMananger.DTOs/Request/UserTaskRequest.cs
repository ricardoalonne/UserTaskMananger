using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UserTaskMananger.Entities;

namespace UserTaskMananger.DTOs.Request
{
    public class UserTaskRequest
    {
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
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PriorityId { get; set; }

        public void SetTimeOnCreation()
        {
            var currentDate = DateTime.Now;
            CreatedAt = currentDate;
            UpdatedAt = currentDate;
        }

        public void SetTimeOnUpdation()
        {
            UpdatedAt = DateTime.Now;
        }

        public UserTask ToEntity()
        {
            return new UserTask
            {
                Description = this.Description,
                Tags = this.Tags,
                Finished = this.Finished,
                Deleted = this.Deleted,
                ExpirationAt = this.ExpirationAt,
                CreatedAt = this.CreatedAt,
                UpdatedAt = this.UpdatedAt,
                User = new User() { Id = this.UserId },
                Priority = new Priority() { Id = this.PriorityId },
            };
        }
    }
}
