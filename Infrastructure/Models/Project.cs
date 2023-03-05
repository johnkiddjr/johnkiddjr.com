using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class Project
    {
        private List<ProjectImage> _images;
        private List<ProjectLink> _links;
        private ILazyLoader _loader { get; set; }

        public Project() { }
        private Project(ILazyLoader loader)
        {
            _loader = loader;
        }

        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string ProjectSlug { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string RepositoryUrl { get; set; }
        public RepositoryType RepositoryType { get; set; }
        public ProjectType ProjectType { get; set; }
        public string DownloadUrl { get; set; }
        public string NetVersion { get; set; }
        public string LibrariesUsed { get; set; }
        public string LanguageUsed { get; set; }

        public List<ProjectImage> Images
        {
            get => _loader.Load(this, ref _images);
            set => _images = value;
        }
        public List<ProjectLink> Links
        {
            get => _loader.Load(this, ref _links);
            set => _links = value;
        }
    }
}
