namespace MainSite.ViewModels
{
    public class ProgramObjectiveViewModel
    {
        public string ProgramName { get; set; }
        public string Description { get; set; }
        public string RawSectionHtml { get; set; }

        public string ProgramNameId => ProgramName.Replace(' ', '_');
    }
}
