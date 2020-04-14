﻿using Deploy_O_Mat.Service.Application.Services;
using Deploy_O_Mat.Service.Data.Repository;
using Deploy_O_Mat.Service.Domain.EventHandlers;
using Deploy_O_Mat.Service.Domain.Events;
using Deploy_O_Mat.Service.Domain.Interfaces;

using MediatR;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using com.b_velop.Utilities.Docker;
using com.b_velop.Deploy_O_Mat.Web.Domain.Commands;
using com.b_velop.Deploy_O_Mat.Web.Domain.CommandHandlers;
using com.b_velop.Deploy_O_Mat.Web.Application.Services;
using com.b_velop.Deploy_O_Mat.Web.Domain.Interfaces;
using com.b_velop.Deploy_O_Mat.Web.Application.Interfaces;
using com.b_velop.Deploy_O_Mat.Web.Data.Repository;
using com.b_velop.Deploy_O_Mat.Web.Data.Context;

namespace MicroRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<SecretProvider>();

            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, sp.GetService<SecretProvider>());
            });


            //Subscriptions
            services.AddTransient<ServiceUpdateEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<ServiceUpdatedEvent>, ServiceUpdateEventHandler>();

            //Domain Commands
            services.AddTransient<IRequestHandler<CreateServiceUpdateCommand, bool>, ServiceUpdateCommandHandler>();

            //Application Services
            services.AddTransient<IDockerServiceService, DockerServiceService>();
            services.AddTransient<IDockerImageService, DockerImageService>();

            //Data
            services.AddTransient<IDockerServiceRepository, DockerServiceRepository>();
            services.AddTransient<IDockerImageRepository, DockerImageRepository>();
            services.AddTransient<IDockerStackServiceRepository, DockerStackServiceRespository>();
            //services.AddTransient<DockerServiceDbContext>();
            services.AddTransient<WebContext>();
        }
    }
}
