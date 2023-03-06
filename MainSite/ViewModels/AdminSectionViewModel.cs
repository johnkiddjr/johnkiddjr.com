namespace MainSite.ViewModels
{
    public class AdminSectionViewModel
    {
        public string SectionId { get; set; }
        public string HeaderText { get; set; }
        public List<AdminSectionItemViewModel> SectionItems { get; set; }
    }
}