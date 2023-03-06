namespace MainSite.Extensions
{
    public static class IFormFileExtensions
    {
        public static bool IsImageFile(this IFormFile file)
        {
            var fileName = file.FileName;

            if (fileName.EndsWith(".jpg"))
            {
                return true;
            }

            if (fileName.EndsWith(".jpeg"))
            {
                return true;
            }

            if (fileName.EndsWith(".png"))
            {
                return true;
            }

            if (fileName.EndsWith(".gif"))
            {
                return true;
            }

            return false;
        }

        public static string GenerateRandomFilename(this IFormFile file)
        {
            var originalFileName = file.FileName;

            // find the file extension
            int lastPeriod = originalFileName.LastIndexOf(".");
            var extension = originalFileName.Substring(lastPeriod + 1);

            return $"{Guid.NewGuid().ToString("N")}.{extension}";
        }
    }
}
