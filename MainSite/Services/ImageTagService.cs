using Infrastructure.Contexts;
using Infrastructure.Models;
using MainSite.ViewModels;

namespace MainSite.Services
{
    public interface IImageTagService
    {
        public List<CardBackground> GetBackgroundByTags(List<TagViewModel> tags);
    }

    public class ImageTagService : IImageTagService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public ImageTagService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public List<CardBackground> GetBackgroundByTags(List<TagViewModel> tags)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<MainSiteContext>();

            var dbTagIds = context.Tags.AsEnumerable().Where(x => tags.Any(y => y.Name == x.Name)).Select(x => x.TagId).ToList();
            var possibleImages = context.CardBackgrounds.AsEnumerable().Where(x => dbTagIds.Any(y => y == x.TagId)).ToList();

            return possibleImages;
        }
    }
}
