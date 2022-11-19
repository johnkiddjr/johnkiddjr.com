namespace MainSite.Helpers
{
    public static class HtmlHelper
    {
        private static IHttpContextAccessor _accessor;

        public static void Configure(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public static string SelectedCssOnRequestPath(string testPath, string cssClass, bool matchEntirePath = true)
        {
            var contextRequestPath = _accessor.HttpContext.Request.Path.Value.ToLowerInvariant();
            if (matchEntirePath)
            {
                if (contextRequestPath == testPath.ToLowerInvariant())
                {
                    return cssClass;
                }
            }
            else
            {
                if (contextRequestPath.StartsWith(testPath.ToLowerInvariant()))
                {
                    return cssClass;
                }
            }

            return string.Empty;
        }
    }
}
