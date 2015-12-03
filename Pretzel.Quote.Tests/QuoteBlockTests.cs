using DotLiquid;
using NUnit.Framework;
using System;

namespace Pretzel.Quote.Tests
{
    [TestFixture]
    public class QuoteBlockTests
    {
        [Test]
        public void TestGoodPatterns()
        {
            Template.RegisterTag<QuoteBlock>("quote");
            var templateOk1 = Template.Parse("{% quote %}{% endquote %}");
            var templateOk2 = Template.Parse("{% quote %}content{% endquote %}");
            var templateOk3 = Template.Parse("{% quote author %}content{% endquote %}");
            var templateOk4 = Template.Parse("{% quote author, source%}content{% endquote %}");
            var templateOk5 = Template.Parse("{% quote \"author in quote\", source%}content{% endquote %}");
            var templateOk6 = Template.Parse("{% quote \"author in quote\", source in \"long\" [text](link) %}content{% endquote %}");

            Assert.AreEqual("<blockquote><p></p></blockquote>", templateOk1.Render());
            Assert.AreEqual("<blockquote><p>content</p></blockquote>", templateOk2.Render());
            Assert.AreEqual("<blockquote><p>content</p><footer>&mdash; <strong>author</strong></footer></blockquote>", templateOk3.Render());
            Assert.AreEqual("<blockquote><p>content</p><footer>&mdash; <strong>author</strong>, <cite>source</cite></footer></blockquote>", templateOk4.Render());
            Assert.AreEqual("<blockquote><p>content</p><footer>&mdash; <strong>author in quote</strong>, <cite>source</cite></footer></blockquote>", templateOk5.Render());
            Assert.AreEqual("<blockquote><p>content</p><footer>&mdash; <strong>author in quote</strong>, <cite>source in \"long\" [text](link)</cite></footer></blockquote>", templateOk6.Render());
        }

        [Test]
        public void TestCharacterRange()
        {
            Template.RegisterTag<QuoteBlock>("quote");

            var templateOk1 = Template.Parse("{% quote auth'or %}content{% endquote %}");
            var templateOk2 = Template.Parse("{% quote auth-or %}content{% endquote %}");
            var templateOk3 = Template.Parse("{% quote Teal'c, Stargate SG-1 - 7x21 %}content{% endquote %}");

            Assert.AreEqual("<blockquote><p>content</p><footer>&mdash; <strong>auth'or</strong></footer></blockquote>", templateOk1.Render());
            Assert.AreEqual("<blockquote><p>content</p><footer>&mdash; <strong>auth-or</strong></footer></blockquote>", templateOk2.Render());
            Assert.AreEqual("<blockquote><p>content</p><footer>&mdash; <strong>Teal'c</strong>, <cite>Stargate SG-1 - 7x21</cite></footer></blockquote>", templateOk3.Render());
        }

        [Test]
        public void TestWrongPatterns()
        {
            Template.RegisterTag<QuoteBlock>("quote");

            Assert.Throws<DotLiquid.Exceptions.SyntaxException>(() => Template.Parse("{% quote %}"));
            Assert.Throws<DotLiquid.Exceptions.SyntaxException>(() => Template.Parse("{% quote %}{% endqoute %}"));
            Assert.Throws<ArgumentException>(() => Template.Parse("{% quote author, %}{% endquote %}"));
        }
    }
}