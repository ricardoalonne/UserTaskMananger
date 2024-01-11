using UserTaskMananger.Entities;

namespace UserTaskMananger.DTOs.Response
{
    public class PriorityResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PriorityResponse()
        {

        }

        public PriorityResponse(Priority entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }
    }
}
