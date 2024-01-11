using System.ComponentModel.DataAnnotations;

namespace UserTaskMananger.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
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
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }


        public void Copy(User user)
        {
            Name = user.Name;
            LastName = user.LastName;
            Email = user.Email;
            Phone = user.Phone;
            UpdatedAt = user.UpdatedAt;
        }
    }
}
