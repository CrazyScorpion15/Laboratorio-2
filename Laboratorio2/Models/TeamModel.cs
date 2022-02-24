using CsvHelper.Configuration.Attributes;
using Laboratorio2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio2.Models
{
    public class TeamModel
    {
        [Index(0)]
        public string Name { get; set; } = "";
        [Index(1)]
        public string Coach { get; set; } = "";
        [Index(2)]
        public string Ligue { get; set; } = "";
        [Index(3)]
        public string CreationDate { get; set; } = "";

        public static bool Guardar(TeamModel model)
        {
            Data.Instance.ListTeam.Add<TeamModel>(model);
            return true;
        }

        public static bool Editar(string id, TeamModel model)
        {
           int position = Data.Instance.ListTeam.Search<TeamModel>(id);
            Data.Instance.TeamList[position] = new TeamModel
            {
                Name = id,
                Coach = model.Coach,
                Ligue = model.Ligue ,
                CreationDate = model.CreationDate
            };
            return true;
        }

        public static void Borrar(string id)
        {
            var position = Data.Instance.TeamList.FindIndex(equipo => equipo.Name == id);
            Data.Instance.TeamList.RemoveAt(position);
        }
    }
}