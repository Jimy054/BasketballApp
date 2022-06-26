using BasktballExampleForms.Interface;
using BasktballExampleForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasktballExampleForms.Repository
{
    public class TeamRepository : ITeamRepository
    {
        List<TeamModel> dataTeam = NBAScrapper.GetTeams();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<TeamModel> GetTeams()
        {
         //   dataTeam.RemoveAt(0);
            return dataTeam.ToList();
        }
    }
}
