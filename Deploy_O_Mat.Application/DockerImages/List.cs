﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using com.b_velop.Deploy_O_Mat.Domain.Interfaces;
using com.b_velop.Deploy_O_Mat.Domain.Models;
using MediatR;

namespace com.b_velop.Deploy_O_Mat.Application.DockerImages
{
    public class List
    {
        public class Query : IRequest<IEnumerable<DockerImage>> { }

        public class Handler : IRequestHandler<Query, IEnumerable<DockerImage>>
        {
            private readonly IRepositoryWrapper _repository;

            public Handler(
                IRepositoryWrapper repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<DockerImage>> Handle(
                Query request,
                CancellationToken cancellationToken)
                => await _repository.DockerImages.SelectAllAsync(cancellationToken);
        }
    }
}
