﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.Deploy_O_Mat.Web.Domain.Models;

namespace com.b_velop.Deploy_O_Mat.Web.Domain.Interfaces
{
    public interface IDeployOMatWebRepository
    {
        Task CreateOrUpdateDockerStackLog(IEnumerable<DockerStackLog> stackLogs);

        Task<IEnumerable<DockerStackLog>> GetDockerStackLogs();
        Task<IEnumerable<DockerStack>> GetDockerStacks();
        Task<IEnumerable<DockerService>> GetDockerServices();

        Task<DockerService> GetDockerService(Guid id);
    }
}
