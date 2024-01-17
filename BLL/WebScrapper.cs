using HtmlAgilityPack;

namespace BLL
{
    public class WebScrapper
    {
        const string filePath = @"C:\Projetos\Flopinguim\WebScraper_CSharp\Data.txt";
        public static void getDividend(string dividend)
        {
            try
            {
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
                    if (!File.Exists(filePath))
                        File.Create(filePath);

                    var values = dividendhtml.Descendants("p").ToList();
                    using var file = File.AppendText(filePath);
                    file.WriteLine(dividendhtml.InnerText.Replace("  ", "").Replace("\t", "").Replace("\n", ""));
                    file.Close();
                }
            }
            catch { }
        }
    }
}