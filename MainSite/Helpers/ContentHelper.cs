namespace MainSite.Helpers
{
    public static class ContentHelper
    {
        private static string ContentEndpoint { get; set; } = "https://content.stage.johnkiddjr.com/";

        public static string GetUrlForResource(ContentType type, string resourceName)
        {
            return $"{ContentEndpoint}{type.ToString()}/{resourceName}";
        }
    }

    public enum ContentType
    {
        images,
        other
    };
}
