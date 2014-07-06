using System;
using System.Web;
using MarkdownSharp;

namespace DemoBlog.Application
{
    public static class MarkdownHelpers
    {
        public static Lazy<Markdown> _markdown = new Lazy<Markdown>(() =>
        {
            var options = new MarkdownOptions
            {
                AutoHyperlink=true,
            };

            var result = new Markdown(options);
            return result;
        });
        public static IHtmlString TransformMarkdown(this string content)
        {
            var result = _markdown.Value.Transform(content);

            return new HtmlString(result);
        }
    }
}