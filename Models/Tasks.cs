﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P_Asignación_de_Tareas.Models
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTask { get; set; }
        public int idProyect {  get; set; }
        public string nameTask { get; set; }
        public string descriptionTask { get; set; }
        public DateTime dateTask { get; set; }
        public DateTime dateTaskCompletion { get; set; }
        public string state {  get; set; }
        public virtual Proyects Proyects { get; set; }
        public virtual ICollection<Comments> Comment { get; set; } = new List<Comments>();

    }
}
