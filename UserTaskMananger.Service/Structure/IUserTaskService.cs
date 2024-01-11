﻿using UserTaskMananger.DTOs.Request;
using UserTaskMananger.DTOs.Response;
using UserTaskMananger.Service.Base;

namespace UserTaskMananger.Service.Structure
{
    public interface IUserTaskService : IServiceBase<UserTaskResponse, UserTaskRequest>
    {
    }
}
