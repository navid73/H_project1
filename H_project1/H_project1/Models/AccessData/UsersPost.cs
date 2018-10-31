namespace H_project1.Models.AccessData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsersPost")]
    public partial class UsersPost
    {
        public int id { get; set; }

        public string pic { get; set; }

        [Column(TypeName = "ntext")]
        public string text { get; set; }

        public int? id_User { get; set; }

        [StringLength(15)]
        public string date { get; set; }

        [StringLength(15)]
        public string time { get; set; }

        public int? likeNumber { get; set; }

        public int? commentsNumber { get; set; }
    }
}
