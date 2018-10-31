namespace H_project1.Models.AccessData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("message")]
    public partial class message
    {
        public int id { get; set; }

        public int IdUserSender { get; set; }

        public int IdUserResiver { get; set; }

        [Required]
        [StringLength(50)]
        public string Date { get; set; }

        [Column("message", TypeName = "ntext")]
        [Required]
        public string message1 { get; set; }

        public bool seen { get; set; }
    }
}
