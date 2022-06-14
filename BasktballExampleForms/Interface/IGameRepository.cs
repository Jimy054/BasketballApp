using BasktballExampleForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasktballExampleForms.Interface
{
    public interface IGameRepository : IDisposable
    {
        List<GameModel> GetAllGames();
        List<GameModel> GetSomeGames(int quantity);
        GameModel GetGameByID(int gameID);
        int GetDateLastGame();

        void RemoveGame(int index);
        GameModel GetLastGame();
    }
}
