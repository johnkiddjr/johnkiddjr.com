using Markdig;
using Markdig.Syntax;

namespace MainSite.Services
{
    public interface IMarkdownService
    {
        public string GetHtmlFromMarkdown(string markdown);
        public string GetHtmlFromMarkdown(string markdown, Action<MarkdownDocument> customProcessing);
        public Task<string> GetHtmlFromMarkdownUrl(string url);
        public Task<string> GetHtmlFromMarkdownUrl(string url, Action<MarkdownDocument> customProcessing);
    }

    public class MarkdownService : IMarkdownService
    {
        private readonly IRestService _restService;

        public MarkdownService(IRestService restService)
        {
            _restService = restService;
        }

        public string GetHtmlFromMarkdown(string markdown)
        {
            return GetHtmlFromMarkdown(markdown, null);
        }

        public string GetHtmlFromMarkdown(string markdown, Action<MarkdownDocument> customProcessing)
        {
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();

            var mDocument = Markdown.Parse(markdown, pipeline);
            
            if (customProcessing != null)
            {
                customProcessing(mDocument);
            }

            return mDocument.ToHtml(pipeline);
        }

        public async Task<string> GetHtmlFromMarkdownUrl(string url)
        {
            return await GetHtmlFromMarkdownUrl(url, null);
        }

        public async Task<string> GetHtmlFromMarkdownUrl(string url, Action<MarkdownDocument> customProcessing)
        {
            var markdown = await _restService.ProcessRequest(url, RestSharp.Method.Get);

            return GetHtmlFromMarkdown(markdown, customProcessing);
        }
    }
}
