using Infrastructure.Enumerations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class Project
    {
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
        public DateTime DateAdded { get; set; }
    }
}
