using HtmlAgilityPack;
using Model.Entities;
using Utils;

namespace BLL
{
    public class DividendBLL
    {
        const string filePath = @"C:\Projetos\Flopinguim\WebScraper_CSharp\Data.txt";
        public static Dividend scrapperValuesTolist(string dividend)
        {
            try
            {
                Dividend fundInfo = new Dividend();

                // Send get requent to site
                string url = $"https://www.fundsexplorer.com.br/funds/{dividend.ToLower()}";
                var httpClient = new HttpClient();
                var html = httpClient.GetStringAsync(url).Result;
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                // Remove as tags <small> do HTML usando LINQ
                htmlDocument.DocumentNode.Descendants("small").ToList().ForEach(smallTag => smallTag.Remove());

                // Extrai os valores das tags <b>
                var valueTags = htmlDocument.DocumentNode.SelectNodes("//div[@class='indicators__box']/p/b");

                List<string> objValues = new List<string>();
                if (valueTags != null)
                {
                    foreach (var boldTag in valueTags)
                    {
                        objValues.Add(boldTag.InnerText.Trim().filterChar());
                    }

                    fundInfo.AverageDailytrading = decimal.Parse(objValues[0]);
                    fundInfo.LastYield = decimal.Parse(objValues[1]);
                    fundInfo.DividendYield = decimal.Parse(objValues[2]);
                    fundInfo.NetWorth = decimal.Parse(objValues[3]);
                    fundInfo.AssetValue = decimal.Parse(objValues[4]);
                    fundInfo.RentabilityPerMonth = decimal.Parse(objValues[5]);
                    fundInfo.PVP = decimal.Parse(objValues[6]);
                }

                objValues = new List<string>();
                foreach (var div in htmlDocument.DocumentNode.SelectNodes("//div[@class='basicInformation__grid__box']"))
                {
                    // Obtendo o texto das tags 'p' dentro da div
                    string label = div.SelectSingleNode("p[1]").InnerText.Trim();
                    string value = div.SelectSingleNode("p[2]/b").InnerText.Trim();
                    objValues.Add(value);
                }
                fundInfo.CompanyName = objValues[0];
                fundInfo.CNPJ = objValues[1];
                fundInfo.Name = objValues[2];
                fundInfo.Segment = objValues[5];
                return fundInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
