using AngleSharp.Html.Dom;

namespace One.Core
{
    interface IParser<T> where T : class
    {
        T ParseModels(IHtmlDocument document);
        T ParseComplectations(IHtmlDocument document);
        T ParseSpares(IHtmlDocument document);
        T ParseSparesGroup(IHtmlDocument document);
        T ParseChoosePage(IHtmlDocument document);
    }
}
