using HtmlAgilityPack;

namespace Garage.Parser
{
    public static class Parser
    {
        public static List<string> GetInfo()
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(@"https://av.by");

            var nodes = htmlDoc.DocumentNode.SelectNodes("//span[@class='catalog__title']");

            List<string> info = new List<string>();

            if (nodes is not null)
            {
                foreach (HtmlNode item in nodes)
                {
                    info.Add(item.InnerText);
                }
            }

            return info;
        }
    }
}
