using Infrastructure.Contexts;
using MainSite.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MainSite.Services
{
    public interface IProjectService
    {
        public Task<List<ProjectViewModel>> GetProjects();
        public Task<List<PlatformViewModel>> GetPlatforms();
    }

    public class ProjectService : IProjectService
    {
        private readonly MainSiteContext _context;

        public ProjectService(MainSiteContext context)
        {
            _context = context;
        }

        public async Task<List<PlatformViewModel>> GetPlatforms()
        {
            var platforms = await (from plat in _context.Platforms
                                    select plat).ToListAsync();

            return platforms.Select(x => new PlatformViewModel { PlatformName = x.Name }).ToList();
        }

        public async Task<List<ProjectViewModel>> GetProjects()
        {
            var projects = await (from proj in _context.Projects
                                  select proj).ToListAsync();

            return projects.Select(x =>
                new ProjectViewModel
                {
                    Name = x.Name
                }).ToList();
        }
    }
}
