using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace com.github.geforce_hisa0904.TrainServiceTracker.Func.TrainService.Line
{
    internal class DenenToshiLineTrainService : ILineTrainService
    {
        private static readonly Uri STATUS_PAGE_URL = new Uri("https://transit.yahoo.co.jp/traininfo/detail/114/0/");
        public async Task<string> GetStatusAsync()
        {
            var doc = default(IHtmlDocument);
            using (var client = new HttpClient())
            using (var stream = await client.GetStreamAsync(STATUS_PAGE_URL))
            {
                var parser = new HtmlParser();
                doc = await parser.ParseAsync(stream);
            }
            var statusElement = doc.QuerySelector("#mdServiceStatus>dl>dt");
            return statusElement.TextContent;
        }
    }
}
