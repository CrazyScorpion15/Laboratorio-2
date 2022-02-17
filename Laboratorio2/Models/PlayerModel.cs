using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio2.Models
{
    public class PlayerModel
    {
        public string Team { get; set; }

        public string Name { get; set; }

        public string LName { get; set; }

        public string Role { get; set; }

        public double KDA { get; set; }

        public double CreepScore { get; set; }

        internal static bool Save(PlayerModel teamModel)
        {
            throw new NotImplementedException();
        }

    }
}
