using LataPrzestepne.Interfaces;
using LataPrzestepne.Filters;
using LataPrzestepne.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace LataPrzestepne.Filters
{
    public class Filter : IAsyncPageFilter
    {
        private readonly IFilter _filterService;
        public Filter(IFilter browser)
        {
            _filterService = browser;
        }
        public async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            await Task.CompletedTask;
        }
        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            var useragent = context.HttpContext.Request.Headers;
            var builder = new StringBuilder(Environment.NewLine);
            foreach (var header in useragent)
            {
                builder.AppendLine($"{header.Key}: {header.Value}");
            }
            var headersDump = builder.ToString();

            var result = await _filterService.GetName(headersDump);
            if (result != "") context.HttpContext.Response.Redirect(result);

            await next.Invoke();
        }
    }
}
