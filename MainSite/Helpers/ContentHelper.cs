namespace MainSite.Helpers
{
    public static class ContentHelper
    {
        private static string ContentEndpoint { get; set; }

        public static void Configure(string endpoint)
        {
            if (!endpoint.EndsWith('/'))
            {
                endpoint+= "/";
            }

            ContentEndpoint = endpoint;
        }

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
