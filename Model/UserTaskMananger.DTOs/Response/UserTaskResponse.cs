using UserTaskMananger.Entities;

namespace UserTaskMananger.DTOs.Response
{
    public class UserTaskResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public bool Finished { get; set; } = false;
        public bool Deleted { get; set; } = false;
        public DateTime ExpirationAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public int PriorityId { get; set; }
        public string PriorityName { get; set; }

        public UserTaskResponse()
        {

        }

        public UserTaskResponse(UserTask entity)
        {
            this.Id = entity.Id;
            this.Description = entity.Description;
            this.Tags = entity.Tags;
            this.Finished = entity.Finished;
            this.Deleted = entity.Deleted;
            this.ExpirationAt = entity.ExpirationAt;
            this.CreatedAt = entity.CreatedAt;
            this.UpdatedAt = entity.UpdatedAt;
            this.UserId = entity.UserId;
            this.UserFullName = $"{entity.User.Name} {entity.User.LastName}";
            this.PriorityId = entity.PriorityId;
            this.PriorityName = entity.Priority.Name;
        }
    }
}
