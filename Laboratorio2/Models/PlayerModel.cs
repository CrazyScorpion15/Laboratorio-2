using Laboratorio2.Helpers;
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

        internal static bool Save(PlayerModel playerModel)
        {
            Data.Instance.PlayerList.Add(playerModel);
            return true;
        }
        public static bool Edit(string id, PlayerModel model)
        {
            var position = Data.Instance.PlayerList.FindIndex(group => group.Name == id);
            Data.Instance.PlayerList[position] = new PlayerModel
            {
                Team = model.Team,
                Name = id,
                LName = model.LName,
                Role = model.Role,
                KDA = model.KDA,
                CreepScore = model.CreepScore
            };
            return true;
        }
        public static bool Delete(string id)
        {
            var position = Data.Instance.PlayerList.FindIndex(player => player.Name == id);
            Data.Instance.PlayerList.RemoveAt(position);
            return true;
        }
    }
}
