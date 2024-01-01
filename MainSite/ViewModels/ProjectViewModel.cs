using System.ComponentModel.DataAnnotations;

namespace MainSite.ViewModels
{
    public class ProjectViewModel
    {
        public string Slug { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        [Display(Name = "Code Repository")]
        public string RepositoryUrl { get; set; }
        public string RepositoryType { get; set; }
        public string ProjectType { get; set; }
        [Display(Name = "Download Binary")]
        public string DownloadUrl { get; set; }
        [Display(Name = ".NET Version")]
        public string NetVersion { get; set; }
        [Display(Name = "Libraries Used")]
        public string LibrariesUsed { get; set; }
        [Display(Name = "Language Used")]
        public string LanguageUsed { get; set; }
        public string Platform { get; set; }
        public List<ProjectLinkViewModel> AdditionalLinks { get; set; }
        public List<ProjectImageViewModel> Images { get; set; }
    }
}