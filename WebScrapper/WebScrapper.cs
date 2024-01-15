using HtmlAgilityPack;
using System.Net.Http;

namespace WebScrapper
{
    class WebScrapper
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Write the name of an Dividend");
            string dividend = Console.ReadLine();

            // Send get requent to site
            string url = $"https://www.fundsexplorer.com.br/funds/{dividend.ToLower()}";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Get values
            var dividendYieldElement = htmlDocument.DocumentNode.SelectNodes("//div[@class='indicators__box']");

            foreach (var dividendhtml in dividendYieldElement)
            {
                var values = dividendhtml.Descendants("p").ToList();
                Console.WriteLine(dividendhtml.InnerText.Replace("  ","").Replace("\t","").Replace("\n",""));
                // Console.WriteLine(string.Concat(dividendhtml.InnerText.Where(Char.IsDigit)));
            }
        }
    }
}