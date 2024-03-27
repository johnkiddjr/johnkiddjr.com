using Infrastructure.Contexts;
using MainSite.Helpers;
using MainSite.Options;
using MainSite.Services;
using MainSite.ViewModels;
using Markdig.Extensions.CustomContainers;
using Markdig.Renderers.Html;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MainSite.Controllers
{
    public class ObjectivesController : Controller
    {
        private readonly ILogger<ObjectivesController> _logger;
        private readonly MainSiteContext _context;
        private readonly IMarkdownService _markdownService;
        private readonly CDNOptions _cdnOptions;

        public ObjectivesController(ILogger<ObjectivesController> logger,
            MainSiteContext context,
            IMarkdownService markdownService,
            IOptions<CDNOptions> cdnOption)
        {
            _logger = logger;
            _context = context;
            _markdownService = markdownService;
            _cdnOptions = cdnOption.Value;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await GenerateViewModel();

            return View(viewModel);
        }

        private async Task<ObjectivesViewModel> GenerateViewModel()
        {
            // hard coding part of this for time, but should be done via DB in a not my portfolio situation
            var acsProgram = new ProgramObjectiveViewModel
            {
                ProgramName = "Advancing Computer Science",
                Description = "ACS",
                RawSectionHtml = await GetMarkdownFileContents("ACS.MD")
            };

            var gpProgram = new ProgramObjectiveViewModel
            {
                ProgramName = "Game Programming",
                Description = "GP",
                RawSectionHtml = await GetMarkdownFileContents("GP.MD")
            };

            var viewModel = new ObjectivesViewModel { Programs = new List<ProgramObjectiveViewModel> { acsProgram, gpProgram } };

            return viewModel;
        }

        private async Task<string> GetMarkdownFileContents(string filename) =>
            await _markdownService.GetHtmlFromMarkdownUrl($"{_cdnOptions.ArticlesStub}/{filename}", md =>
            {
                void ProcessCustomContainerChildren(CustomContainer container)
                {
                    foreach (var childItem in container)
                    {
                        if (childItem is CustomContainer childContainer)
                        {
                            var attributes = childContainer.GetAttributes();

                            if (attributes != null && attributes.Classes != null && attributes.Classes.Contains("collapse"))
                            {
                                if (attributes == null)
                                {
                                    continue;
                                }

                                var target = attributes?.Id;

                                var childDivProps = new List<KeyValuePair<string, string>>
                                {
                                    new KeyValuePair<string, string>("data-bs-target", $"#{target}"),
                                    new KeyValuePair<string, string>("aria-controls", target)
                                };

                                attributes.Properties.AddRange(childDivProps);

                                childContainer.SetAttributes(attributes);
                            }

                            ProcessCustomContainerChildren(childContainer);
                        }
                        else if (childItem is HeadingBlock childHeader && childHeader.GetAttributes()?.Id == "objectiveHeader")
                        {
                            var attributes = childHeader.TryGetAttributes();

                            if (attributes == null)
                            {
                                continue;
                            }

                            var targetProperty = attributes.Properties.FirstOrDefault(x => x.Key == "data-mdig-target");

                            var bsTarget = targetProperty.Equals(default(KeyValuePair<string, string>)) ? string.Empty : targetProperty.Value;

                            var literalContent = childHeader.Inline.FirstChild?.ToString() ?? "ERROR";

                            childHeader.Inline.Clear();

                            var accordionButton = $"<button class=\"accordion-button collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#{bsTarget}\" aria-expanded=\"false\" aria-controls=\"{bsTarget}\">";

                            childHeader.Inline.AppendChild(new HtmlInline(accordionButton));
                            childHeader.Inline.AppendChild(new LiteralInline(literalContent));
                            childHeader.Inline.AppendChild(new HtmlInline("</button>"));

                            continue;
                        }
                    }
                }

                foreach (var mdItem in md)
                {
                    if (mdItem is CustomContainer customContainer)
                    {
                        ProcessCustomContainerChildren(customContainer);
                    }

                    if (mdItem is HeadingBlock headingBlock)
                    {
                        headingBlock.SetAttributes(new HtmlAttributes { Classes = new List<string> { "text-center" } });
                    }

                    if (mdItem is ParagraphBlock)
                    {
                        foreach (var inlineItem in (mdItem as ParagraphBlock).Inline)
                        {
                            if (inlineItem is LinkInline && (inlineItem as LinkInline).IsImage)
                            {
                                var imageLinkInline = inlineItem as LinkInline;
                                imageLinkInline.Url = imageLinkInline.Url.ToLowerInvariant().StartsWith("http") ? imageLinkInline.Url : ContentHelper.GetUrlForResource(ContentType.images, imageLinkInline.Url);
                                imageLinkInline.SetAttributes(new HtmlAttributes() { Classes = new List<string>() { "article-image" } });
                            }
                        }
                    }
                }
            });
    }
}
