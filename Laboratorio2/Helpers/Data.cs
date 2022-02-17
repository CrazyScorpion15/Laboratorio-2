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
                Name = "Saber",
                Coach = "Buenas",
                Legue = "Como",
                CreationDate = "2/3/2002"
            }
        };
    }
}
