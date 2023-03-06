namespace MainSite.ViewModels
{
    public class ProjectViewModel
    {
        public string Slug { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string RepositoryUrl { get; set; }
        public string RepositoryType { get; set; }
        public string ProjectType { get; set; }
        public string DownloadUrl { get; set; }
        public string NetVersion { get; set; }
        public string LibrariesUsed { get; set; }
        public string LanguageUsed { get; set; }
        public List<ProjectLinkViewModel> AdditionalLinks { get; set; }
        public List<ProjectImageViewModel> Images { get; set; }
    }
}