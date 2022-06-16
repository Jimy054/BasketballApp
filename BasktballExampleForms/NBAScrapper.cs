using BasktballExampleForms.Models;
using HtmlAgilityPack;
using System.Net;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace BasktballExampleForms
{
    internal class NBAScrapper
    {

       public static List<TeamModel> GetTeams()
        {
            List<TeamModel> teams = new List<TeamModel>();
            WebClient client = new WebClient();
            HtmlDocument doc = new HtmlDocument();
            HtmlNode.ElementsFlags["br"] = HtmlElementFlag.Empty;
            doc.OptionWriteEmptyNodes = true;
            var web = HttpWebRequest.Create("https://www.espn.com/nba/team/schedule/_/name/lal/los-angeles-lakers");
            Stream stream = web.GetResponse().GetResponseStream();
            doc.Load(stream);
            int id = 1;
            string selector = "//option[@class='dropdown__option']";

            HtmlNodeCollection nodoColecion = doc.DocumentNode.SelectNodes(selector);

            foreach (HtmlNode nodo in nodoColecion)
            {
                if (id < 30)
                {
                    bool verify = nodo.Attributes["value"].Value == "Selected" ? true : false;
                    if (!verify)
                    {
                        string href = nodo.Attributes["data-param-value"].Value;
                        TeamModel teamModel = new TeamModel();
                        teamModel.Id = id;
                        teamModel.Name = nodo.ChildNodes[0].InnerText;
                        teamModel.Acronym = href;
                        teams.Add(teamModel);
                        id++;
                    }
                }
               
                //   / teamRival = getTeam(nodo.ChildNodes[1].InnerText.Substring(2).Trim());
                  //  gameModel.GameRival = teamRival;
                  //  gameModel.Result = nodo.ChildNodes[2].InnerText.Substring(0, 1);
                    /*
                    Dictionary<string, string> dataHelper = new Dictionary<string, string>();
                    idHelper = id.ToString();
                    dataHelper.Add("ID", idHelper);
                    dataHelper.Add("Date", nodo.ChildNodes[0].InnerText);
                    
                    dataHelper.Add("Rival", teamRival)
                    dataHelper.Add("Result", nodo.ChildNodes[2].InnerText.Substring(0, 1));
                    Console.WriteLine("------------------------------------");*/
                   // dataTeam.Add(gameModel);
                   
                
            }
            return teams;
        }

       

       public static List<GameModel> GetGames(string team)
        {
          //  List<Dictionary<string, string>> dataTeam = new List<Dictionary<string, string>>();
            List<GameModel> dataTeam = new List<GameModel>();
            WebClient client = new WebClient();
            HtmlDocument doc = new HtmlDocument();
            HtmlNode.ElementsFlags["br"] = HtmlElementFlag.Empty;
            doc.OptionWriteEmptyNodes = true;
            var web = HttpWebRequest.Create("https://www.espn.com/nba/team/schedule/_/name/"+team+"/seasontype/2");
            Stream stream = web.GetResponse().GetResponseStream();
            doc.Load(stream);
            string teamRival;
            int id = 1;
            string selector = "//table[@class='Table']//tr";

            HtmlNodeCollection nodoColecion = doc.DocumentNode.SelectNodes(selector);

            foreach (HtmlNode nodo in nodoColecion)
            {
                if (nodo.InnerHtml.Contains("<td"))
                {
                    GameModel gameModel = new GameModel();
                    gameModel.GameID = id;
                    gameModel.GameDate = nodo.ChildNodes[0].InnerText;
                    teamRival = getTeam(nodo.ChildNodes[1].InnerText.Substring(2).Trim());
                    gameModel.GameRival = teamRival;
                    gameModel.Result = nodo.ChildNodes[2].InnerText.Substring(0, 1);

                    /*
                    Dictionary<string, string> dataHelper = new Dictionary<string, string>();
                    idHelper = id.ToString();
                    dataHelper.Add("ID", idHelper);
                    dataHelper.Add("Date", nodo.ChildNodes[0].InnerText);
                    
                    dataHelper.Add("Rival", teamRival)
                    dataHelper.Add("Result", nodo.ChildNodes[2].InnerText.Substring(0, 1));
                    Console.WriteLine("------------------------------------");*/
                    dataTeam.Add(gameModel);
                    id++;
                }
            }

            return dataTeam;
        }


        static string getTeam(string team)
        {
            string fullTeam = String.Empty;
            switch (team)
            {
                case "Boston":
                    fullTeam = "Boston Celtics";
                    break;
                case "Brooklyn":
                    fullTeam = "Brooklyn Nets";
                    break;
                case "New York":
                    fullTeam = "New York Knicks";
                    break;
                case "Philadelphia":
                    fullTeam = "Philadelphia 76ers";
                    break;
                case "Toronto":
                    fullTeam = "Toronto Raptors";
                    break;
                case "Chicago":
                    fullTeam = "Chicago Bulls";
                    break;
                case "Cleveland":
                    fullTeam = "Cleveland Cavaliers";
                    break;
                case "Detroit":
                    fullTeam = "Detroit Pistons";
                    break;
                case "Indiana":
                    fullTeam = "Indiana Pacers";
                    break;
                case "Milwaukee":
                    fullTeam = "Milwaukee Bucks";
                    break;
                case "Denver":
                    fullTeam = "Denver Nuggets";
                    break;
                case "Minnesota":
                    fullTeam = "Minnesota Timberwolves";
                    break;
                case "Oklahoma City":
                    fullTeam = "Oklahoma City Thunder";
                    break;
                case "Portland":
                    fullTeam = "Portland Trail Blazers";
                    break;
                case "Utah":
                    fullTeam = "Utah Jazz";
                    break;
                case "Golden State":
                    fullTeam = "Golden State Warriors";
                    break;
                case "LA":
                    fullTeam = "LA Clippers";
                    break;
                case "Los Angeles":
                    fullTeam = "Los Angeles Lakers";
                    break;
                case "Sacramento":
                    fullTeam = "Sacramento Kings";
                    break;
                case "Phoenix":
                    fullTeam = "Phoenix Suns";
                    break;
                case "Atlanta":
                    fullTeam = "Atlanta Hawks";
                    break;
                case "Charlotte":
                    fullTeam = "Charlotte Hornets";
                    break;
                case "Miami":
                    fullTeam = "Miami Heat";
                    break;
                case "Orlando":
                    fullTeam = "Orlando Magic";
                    break;
                case "Washington":
                    fullTeam = "Washington Wizards";
                    break;
                case "Dallas":
                    fullTeam = "Dallas Mavericks";
                    break;
                case "Houston":
                    fullTeam = "Houston Rockets";
                    break;
                case "Memphis":
                    fullTeam = "Memphis Grizzlies";
                    break;
                case "New Orleans":
                    fullTeam = "New Orleans Pelicans";
                    break;
                case "San Antonio":
                    fullTeam = "San Antonio Spurs";
                    break;
                case "New Jersey":
                    fullTeam = "New Jersey Nets";
                    break;
                case "Vancover":
                    fullTeam = "Vancover Grizlies";
                    break;
                case "Seattle":
                    fullTeam = "Seattle";
                    break;
                default:
                    break;
            }
            return fullTeam;
        }
    }
}
