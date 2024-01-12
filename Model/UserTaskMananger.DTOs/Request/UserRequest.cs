using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UserTaskMananger.Entities;

namespace UserTaskMananger.DTOs.Request
{
    public class UserRequest
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [Phone]
        public string Phone { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }

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

        public User ToEntity(int id = 0)
        {
            return new User
            {
                Name = this.Name,
                LastName = this.LastName,
                Email = this.Email,
                Phone = this.Phone,
                CreatedAt = this.CreatedAt,
                UpdatedAt = this.UpdatedAt,
            };
        }
    }
}
