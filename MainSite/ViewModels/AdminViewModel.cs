namespace MainSite.ViewModels
{
    public class AdminViewModel
    {
        public string Message { get; set; } = string.Empty;
        public List<AdminSectionViewModel> Sections { get; set; }
    }
}
