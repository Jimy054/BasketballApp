using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasktballExampleForms.Models
{
    public class GameModel
    {
        public int GameID { get; set; }
        public string GameName { get; set; }
        public string GameRival { get; set; }
        public string GameDate { get; set; }
        public string Result { get; set; }
    }
}
