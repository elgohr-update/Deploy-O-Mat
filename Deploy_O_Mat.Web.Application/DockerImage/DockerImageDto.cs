﻿using System;
using System.Collections.Generic;
using com.b_velop.Deploy_O_Mat.Web.Application.DockerImage;

namespace com.b_velop.Deploy_O_Mat.Web.Application.DockerImage
{
    public class DockerImageDto
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? StartTime { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Pusher { get; set; }
        public string Owner { get; set; }
        public string Dockerfile { get; set; }
        public bool IsOfficial { get; set; }
        public string RepoName { get; set; }
        public bool IsActive { get; set; } = false;
        public ICollection<BadgeDto> Badges { get; set; }
    }
}
