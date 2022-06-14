using BasktballExampleForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasktballExampleForms.Interface
{
    public interface ITeamRepository : IDisposable
    {
        List<TeamModel> GetTeams();
    }
}
