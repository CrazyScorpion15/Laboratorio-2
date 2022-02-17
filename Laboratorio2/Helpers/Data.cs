using Laboratorio2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio2.Helpers
{
    public class Data
    {
        private static Data _instance = null;

        public static Data Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Data();
                }
                return _instance;
            }
        }

        public List<TeamModel> TeamList = new List<TeamModel>
        {
            new TeamModel
            {
                Name = "G2 ESPORTS",
                Coach = "Dylan Falco",
                Ligue = "LEC",
                CreationDate = "15 October 2015",
            }
        };

        public List<PlayerModel> PlayerList = new List<PlayerModel>
        {
            new PlayerModel
            {
                Team = "G2 ESPORTS",
                Name = "Rasmus",
                LName = "Winther",
                Role = "MID LANER",
                KDA  = 3.9,
                CreepScore = 8.7,

            }
        };
    }
}
