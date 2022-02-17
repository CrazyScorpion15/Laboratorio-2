using Laboratorio2.Helpers;
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

        public static bool Guardar(TeamModel model)
        {
            Data.Instance.TeamList.Add(model);
            return true;
        }

        public static bool Editar(string id, TeamModel model)
        {
            var position = Data.Instance.TeamList.FindIndex(grupo => grupo.Name == id);
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