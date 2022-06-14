using BasktballExampleForms.Interface;
using BasktballExampleForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasktballExampleForms.Repository
{
    public class GameRepository : IGameRepository
    {
        List<GameModel> dataTeam = NBAScrapper.GetGames();      

        public List<GameModel> GetAllGames()
        {
            RemoveGame(0);
            return dataTeam.OrderByDescending(g=> g.GameID).ToList();
        }

        public int GetDateLastGame()
        {
            throw new NotImplementedException();
        }

        public GameModel GetLastGame()
        {
            return dataTeam.AsEnumerable().LastOrDefault();
        }

        public List<GameModel> GetSomeGames(int quantity)
        {
            RemoveGame(0);
            return  dataTeam.OrderByDescending(g => g.GameID).Take(quantity).ToList();
        }

        public GameModel GetGameByID(int gameID)
        {
            if (gameID == 1)
            {
                return dataTeam.FirstOrDefault(e => e.GameID == gameID + 1);
            }
            else
            {
                return dataTeam.FirstOrDefault(e => e.GameID == gameID);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void RemoveGame(int index)
        {
            dataTeam.RemoveAt(index);
        }
    }
}
