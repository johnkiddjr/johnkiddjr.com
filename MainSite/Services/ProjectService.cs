using Infrastructure.Contexts;
using Infrastructure.Models;
using MainSite.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MainSite.Services
{
    public interface IProjectService
    {
        public Task<List<ProjectViewModel>> GetProjects();
        public Task<List<PlatformViewModel>> GetPlatforms();
        public Task<ProjectViewModel> GetProjectBySlug(string slug);
        public Task<bool> DeleteProjectBySlug(string slug);
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

            var projectViewModels = projects.Select(CompleteProjectViewModel).Select(x => x.Result).ToList();

            return projectViewModels;
        }

        public async Task<ProjectViewModel> GetProjectBySlug(string slug)
        {
            var project = await (from proj in _context.Projects
                                 where proj.ProjectSlug == slug
                                 select proj).FirstOrDefaultAsync();

            if (project != null)
            {
                return await CompleteProjectViewModel(project);
            }

            return null;
        }

        public async Task<bool> DeleteProjectBySlug(string slug)
        {
            // get project id
            var project = await (from proj in _context.Projects
                                   where proj.ProjectSlug == slug
                                   select proj).FirstOrDefaultAsync();

            // delete from images
            var projectImages = await (from img in _context.ProjectImages
                                       where img.ProjectId == project.ProjectId
                                       select img).ToListAsync();

            foreach (var image in projectImages)
            {
                _context.ProjectImages.Remove(image);
            }

            // delete from links
            var projectLinks = await (from link in _context.ProjectLinks
                                      where link.ProjectId == project.ProjectId
                                      select link).ToListAsync();

            foreach (var link in projectLinks)
            {
                _context.ProjectLinks.Remove(link);
            }

            // delete from projectplatforms
            var projectPlatforms = await (from projplat in _context.ProjectPlatforms
                                          where projplat.ProjectId == project.ProjectId
                                          select projplat).ToListAsync();

            foreach (var projPlat in projectPlatforms)
            {
                _context.ProjectPlatforms.Remove(projPlat);
            }
            // objectives?


            // delete from projects
            _context.Projects.Remove(project);

            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<ProjectViewModel> CompleteProjectViewModel(Project project)
        {
            var platforms = await (from projplat in _context.ProjectPlatforms
                             join plat in _context.Platforms on projplat.PlatformId equals plat.PlatformId
                             where projplat.ProjectId == project.ProjectId
                             select plat.Name).ToListAsync();

            var platform = platforms == null ? string.Empty : string.Join(",", platforms);

            var viewModel = new ProjectViewModel
            {
                Name = project.Name,
                Description = project.Description,
                DownloadUrl = project.DownloadUrl,
                LanguageUsed = project.LanguageUsed,
                LibrariesUsed = project.LibrariesUsed,
                NetVersion = project.NetVersion,
                RepositoryType = project.RepositoryType.ToString(),
                RepositoryUrl = project.RepositoryUrl,
                ShortDescription = project.ShortDescription,
                Slug = project.ProjectSlug,
                Platform = platform,
                ProjectType = project.ProjectType.ToString()
            };

            //we need to check for images and extra links
            var projectImages = await (from pimg in _context.ProjectImages
                                 where pimg.ProjectId.ToString() == project.ProjectId.ToString()
                                 select pimg).ToListAsync();

            if (projectImages.Any())
            {
                viewModel.Images = new List<ProjectImageViewModel>();

                projectImages.ForEach(x =>
                    viewModel.Images.Add(new ProjectImageViewModel
                    {
                        AltText = x.AltText,
                        ImageUrl = x.Url
                    }));
            }

            var projectLinks = await (from plink in _context.ProjectLinks
                                where plink.ProjectId.ToString() == project.ProjectId.ToString()
                                select plink).ToListAsync();

            if (projectLinks.Any())
            {
                viewModel.AdditionalLinks = new List<ProjectLinkViewModel>();

                projectLinks.ForEach(x =>
                    viewModel.AdditionalLinks.Add(new ProjectLinkViewModel
                    {
                        LinkText = x.Text,
                        LinkUrl = x.Url
                    }));
            }

            return viewModel;
        }
    }
}
