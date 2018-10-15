using System;
using System.Linq;
using System.Net;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();
        
            //https://rooster.ehb.be/Scientia/SWS/SYL_PRD_1819/showtimetable.aspx

            var text = client.DownloadString("https://desiderius.ehb.be/index.php?application=Ehb%5CApplication%5CCalendar%5CExtension%5CSyllabusPlus&syllabus_action=UserBrowser");
            Console.WriteLine(text);

            /*HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://desiderius.ehb.be/index.php?application=Ehb%5CApplication%5CCalendar%5CExtension%5CSyllabusPlus&syllabus_action=UserBrowser");
            var HeaderNames = doc.DocumentNode.SelectNodes("//a[class='table-calender table-month']").ToList();

            foreach (var item in HeaderNames)
            {
                Console.WriteLine(item.InnerText);
            }*/


        }
    }
}
