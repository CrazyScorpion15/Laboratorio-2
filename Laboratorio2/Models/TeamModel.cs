using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio2.Models
{
    public class TeamModel
    {
        public string Name { get; set; }
        public string Coach { get; set; }
        public string Ligue { get; set; }
        public string CreationDate { get; set; }


        internal static bool Save(TeamModel teamModel)
        {
            throw new NotImplementedException();
        }
    }
}
