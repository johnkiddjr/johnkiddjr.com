namespace MainSite.ViewModels
{
    public class AboutViewModel
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public List<AboutSectionViewModel> Sections { get; set; }
    }
}
