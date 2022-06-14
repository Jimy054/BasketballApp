using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasktballExampleForms.Models
{
    public class TeamModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Acronym { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
