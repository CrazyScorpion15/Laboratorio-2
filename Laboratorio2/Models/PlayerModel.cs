using CsvHelper.Configuration.Attributes;
using Laboratorio2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio2.Models
{
    public class PlayerModel
    {
        [Index(0)]
        public string Team { get; set; }
        [Index(1)]
        public string Name { get; set; }
        [Index(2)]
        public string LName { get; set; }
        [Index(3)]
        public string Role { get; set; }
        [Index(4)]
        public double KDA { get; set; }
        [Index(5)]
        public double CreepScore { get; set; }

        internal static bool Save(PlayerModel playerModel)
        {
            Data.Instance.ListaPlayers.Add<PlayerModel>(playerModel);
            return true;
        }
        public static bool Edit(string id, PlayerModel model)
        {
            var position = Data.Instance.ListaPlayers.Search(group => group.Name == id);
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
