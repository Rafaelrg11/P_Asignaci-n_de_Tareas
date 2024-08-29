﻿using P_Asignación_de_Tareas.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace P_Asignación_de_Tareas.Dto
{
    public class ProyectsDto
    {
        public int idProyect { get; set; }
        public string nameProyect { get; set; }
        public virtual ICollection<TasksDto> task { get; set; } = new List<TasksDto>();
        public virtual ICollection<AuxiliarTDto> Auxiliar { get; set; } = new List<AuxiliarTDto>();

    }
}
