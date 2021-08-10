
namespace One.Core.Habra
{
    class AutoProSettings : IParserSettings
    {
        public string ModelsUrl { get; set; } = "https://www.ilcats.ru/toyota/?function=getModels&market=EU";
        public string ComplectationUrl { get; set; } = "https://www.ilcats.ru/toyota/?function=getComplectations&market=EU&model=281220&startDate=198210&endDate=198610";
        public string SparesUrl { get; set; } = "https://www.ilcats.ru/toyota/?function=getGroups&market=EU&model=671440&modification=LN51L-KRA&complectation=001";
        public string SparesGroupUrl { get; set; } = "https://www.ilcats.ru/toyota/?function=getSubGroups&market=EU&model=671440&modification=LN51L-KRA&complectation=001&group=1";
        public string ChoosePageUrl { get; set; } = "https://www.ilcats.ru/toyota/?function=getParts&market=EU&model=281220&modification=CV10L-UEMEXW&complectation=001&group=3&subgroup=5202";
    }
}
