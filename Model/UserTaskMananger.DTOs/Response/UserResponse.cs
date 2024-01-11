using UserTaskMananger.Entities;

namespace UserTaskMananger.DTOs.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UserResponse()
        {

        }

        public UserResponse(User entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.LastName = entity.LastName;
            this.Email = entity.Email;
            this.Phone = entity.Phone;
            this.CreatedAt = entity.CreatedAt;
            this.UpdatedAt = entity.UpdatedAt;
        }
    }
}
