namespace H_project1.Models.AccessData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Page_index
    {
        public int id { get; set; }

        public bool active { get; set; }

        [StringLength(50)]
        public string logo { get; set; }

        public string Title { get; set; }

        public string ContetDescription { get; set; }

        public string MetaDescription { get; set; }

        [StringLength(50)]
        public string pic1 { get; set; }

        [StringLength(50)]
        public string pic2 { get; set; }

        [StringLength(50)]
        public string pic3 { get; set; }

        [StringLength(50)]
        public string instagram { get; set; }

        [StringLength(50)]
        public string telegram { get; set; }

        [StringLength(50)]
        public string facebook { get; set; }

        [StringLength(50)]
        public string twitter { get; set; }

        [StringLength(20)]
        public string Datemodified { get; set; }
    }
}
