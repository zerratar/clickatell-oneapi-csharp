namespace Clickatell.OneApi.Sdk.Models.Requests
{
    public interface ITextContent : IContent
    {
        string Content { get; }
    }

    public class TextContent : ITextContent
    {
        private readonly string content;
        public TextContent(string content)
        {
            this.content = content;
        }

        public string Content => content;
    }
}
