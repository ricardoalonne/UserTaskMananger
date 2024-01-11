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
        public UserResponse User { get; set; }
        public PriorityResponse Priority { get; set; }

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
            this.User = new UserResponse(entity.User);
            this.Priority = new PriorityResponse(entity.Priority);
        }
    }
}
