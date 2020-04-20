﻿using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.Deploy_O_Mat.Service.Util.Contracts;
using Deploy_O_Mat.Service.Domain.Interfaces;
using Deploy_O_Mat.Service.Domain.Models;
using MicroRabbit.Domain.Core.Bus;
using Microsoft.Extensions.Logging;

namespace Deploy_O_Mat.Service.Application.Services
{
    public class DockerServiceService : IDockerServiceService
    {
        private readonly IProcessor processor;
        private readonly IDockerServiceRepository _dockerServiceRepository;
        private readonly ILogger<DockerServiceService> _logger;
        private readonly IEventBus _bus;

        public DockerServiceService(
            IProcessor processor,
            IDockerServiceRepository dockerServiceRepository,
            ILogger<DockerServiceService> logger,
            IEventBus bus)
        {
            this.processor = processor;
            _dockerServiceRepository = dockerServiceRepository;
            _logger = logger;
            _bus = bus;
        }

        public IEnumerable<DockerService> GetDockerServices()
        {
            return _dockerServiceRepository.GetDockerServices();
        }

        public Task<int> StartService(
            string service)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> StopService(
            string service)
        {
            var result = await processor.Process("docker", $"service rm {service}");

            if (result.Success)
                _logger.LogInformation($"Remove Docker Service '{service}' completed");
            else
                _logger.LogWarning($"Error while removing '{service}': ({result.ReturnCode}) - {result.ErrorMessage}");

            return result.ReturnCode;
        }

        public async Task<int> UpdateService(
            DockerService service)
        {
            var result = await processor.Process("docker", $"service update --image {service.RepoName}:{service.Tag} {service.Name}");

            if (result.Success)
                _logger.LogInformation($"Update Docker Service '{service.Name}' to BuildId '{service.BuildId}' completed");
            else
                _logger.LogWarning($"Error while updating '{service.Name}' to BuildId '{service.BuildId}': ({result.ReturnCode}) - {result.ErrorMessage}");

            return result.ReturnCode;
        }
    }
}
