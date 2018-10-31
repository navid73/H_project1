namespace H_project1.Models.AccessData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class page_login
    {
        public int id { get; set; }

        [StringLength(50)]
        public string pic { get; set; }

        [StringLength(1000)]
        public string title { get; set; }

        public string Describtion { get; set; }
    }
}
