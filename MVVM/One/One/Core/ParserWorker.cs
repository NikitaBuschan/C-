using AngleSharp.Html.Parser;
using System;

namespace One.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;

        HtmlLoader loader;

        bool isActive;

        #region Properties

        public IParser<T> Parser
        {
            get
            {
                return parser;
            }

            set
            {
                parser = value;
            }
        }

        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }

        #endregion

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }

        public void Start()
        {
            isActive = true;
            getModels();
        }

        public void Abort()
        {
            isActive = false;
        }

        private async void getModels()
        {
            if (!isActive)
            {
                OnCompleted?.Invoke(this);
                return;
            }

            var source = await loader.GetModelsPage();
            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(source);
            var result = parser.ParseModels(document);
            OnNewData?.Invoke(this, result);

            getComplectations();
        }

        private async void getComplectations()
        {
            var source = await loader.GetComplectation();
            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(source);
            var result = parser.ParseComplectations(document);
            OnNewData?.Invoke(this, result);

            getSpares();
        }

        private async void getSpares()
        {
            var source = await loader.GetSpares();
            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(source);
            var result = parser.ParseSpares(document);
            OnNewData?.Invoke(this, result);

            getSparesGroup();

        }

        private async void getSparesGroup()
        {
            var source = await loader.GetSparesGroup();
            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(source);
            var result = parser.ParseSparesGroup(document);
            OnNewData?.Invoke(this, result);

            getChoosePage();
        }


        private async void getChoosePage()
        {
            var source = await loader.GetChoosePage();
            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(source);
            var result = parser.ParseChoosePage(document);
            OnNewData?.Invoke(this, result);

            OnCompleted?.Invoke(this);
            isActive = false;
        }
    }
}
