namespace H_project1.Models.AccessData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notification")]
    public partial class Notification
    {
        public int id { get; set; }

        public int Id_user { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string NotificationHtml { get; set; }

        public bool seen { get; set; }
    }
}
