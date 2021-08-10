using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace One.Core
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string ModelsUrl;
        readonly string ComplectationUrl;
        readonly string SparesUrl;
        readonly string SparesGroupUrl;
        readonly string ChoosePageUrl;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            ModelsUrl = settings.ModelsUrl;
            ComplectationUrl = settings.ComplectationUrl;
            SparesUrl = settings.SparesUrl;
            SparesGroupUrl = settings.SparesGroupUrl;
            ChoosePageUrl = settings.ChoosePageUrl;
        }

        public async Task<string> GetModelsPage()
        {
            var response = await client.GetAsync(ModelsUrl);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }

        public async Task<string> GetComplectation()
        {
            var response = await client.GetAsync(ComplectationUrl);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }

        public async Task<string> GetSpares()
        {
            var response = await client.GetAsync(SparesUrl);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }

        public async Task<string> GetSparesGroup()
        {
            var response = await client.GetAsync(SparesGroupUrl);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }

        public async Task<string> GetChoosePage()
        {
            var response = await client.GetAsync(ChoosePageUrl);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
