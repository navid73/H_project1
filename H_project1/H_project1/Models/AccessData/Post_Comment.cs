namespace H_project1.Models.AccessData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post_Comment
    {
        public int id { get; set; }

        public int? UserId { get; set; }

        public int PostId { get; set; }

        public bool? active { get; set; }

        [StringLength(15)]
        public string date { get; set; }

        [StringLength(15)]
        public string time { get; set; }
    }
}
