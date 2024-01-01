using Infrastructure.Models;
using MainSite.Services;
using MainSite.ViewModels;

namespace MainSite.Helpers
{
    public static class HtmlHelper
    {
        private static IHttpContextAccessor _accessor;
        private static IImageTagService _imageTagService;
        private static Random _random;

        public static void Configure(IHttpContextAccessor accessor, IImageTagService imageTagService)
        {
            _accessor = accessor;
            _imageTagService = imageTagService;
            
            var dtn = DateTime.Now;

            var psedoseed = dtn.Year + dtn.Month + dtn.Day + dtn.Hour + dtn.Minute + dtn.Second + dtn.Millisecond;
            _random = new Random(psedoseed);
        }

        public static string SelectedCssOnRequestPath(string testPath, string cssClass, string cssElseClass = "", bool matchEntirePath = true)
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

            return cssElseClass;
        }

        public static CardBackgroundViewModel GetImageByTags(List<TagViewModel> tags)
        {
            var possibleImages = _imageTagService.GetBackgroundByTags(tags);

            CardBackground selectedImage = null;

            if (possibleImages.Any())
            {
                #pragma warning disable SCS0005 // this is not used for cryptographic purposes
                selectedImage = possibleImages[_random.Next(possibleImages.Count)];
                #pragma warning restore SCS0005
            }

            var returnImage = new CardBackgroundViewModel();

            if (selectedImage != null)
            {
                returnImage.ImageFileName = ContentHelper.GetUrlForResource(ContentType.images, selectedImage.ImageFilename);
                returnImage.TitleFontColor = selectedImage.TitleFontColor;
                returnImage.DescriptionFontColor = selectedImage.DescriptionFontColor;
            }
            else
            {
                // set default background
                returnImage.ImageFileName = ContentHelper.GetUrlForResource(ContentType.images, "card-background-default.png");
                returnImage.TitleFontColor = "#fff";
                returnImage.DescriptionFontColor = "#fff";
            }

            return returnImage;
        }
    }
}
