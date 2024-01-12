using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskMananger.Entities;

namespace UserTaskMananger.DTOs.Response
{
    public class UserResumeResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public UserResumeResponse()
        {

        }

        public UserResumeResponse(User entity)
        {
            this.Id = entity.Id;
            this.FullName = $"{entity.Name} {entity.LastName}";
        }
    }
}
