using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text.RegularExpressions;
using DotLiquid;
using Pretzel.Logic.Extensibility;

namespace Pretzel.Quote
{
    [Export(typeof(ITag))]
    public class QuoteBlock : Block, ITag
    {
        private string htmlAuthor = string.Empty;

        public new string Name => "Quote";

        public override void Initialize(string tagName, string markup, List<string> tokens)
        {
            base.Initialize(tagName, markup, tokens);

            if (!string.IsNullOrWhiteSpace(markup))
            {
                // Maybe some characters are missing.
                // Links are not supported.
                const string wordPattern = @"[\w'\s\-]+";
                const string wordPatternExt = @"""[\w'\s\-,]+""";

                var regex = new Regex($"^(?:({wordPatternExt}|{wordPattern}))(?:,\\s(.+))?$");
                var match = regex.Match(markup.Trim());
                if (match.Success)
                {
                    var author = string.Empty;
                    var source = string.Empty;

                    author = $"<strong>{match.Groups[1].Value.Replace("\"", string.Empty)}</strong>";
                    if (match.Groups[2].Success)
                    {
                        source = $", <cite>{match.Groups[2].Value}</cite>";
                    }

                    this.htmlAuthor = $"<footer>&mdash; {author}{source}</footer>";
                }
                else
                {
                    throw new ArgumentException("Expected syntax: {% quote [author[, source]] %}Content{% endquote %}");
                }
            }
        }

        public override void Render(Context context, System.IO.TextWriter result)
        {
            result.Write("<blockquote>");

            result.Write("<p>");
            base.Render(context, result);
            result.Write("</p>");

            result.Write(this.htmlAuthor);

            result.Write("</blockquote>");
        }
    }
}