namespace H_project1.Models.AccessData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REportUser")]
    public partial class REportUser
    {
        public int id { get; set; }

        public int? id_reporte { get; set; }

        public int? id_reported { get; set; }

        public string DescibleProblem { get; set; }
    }
}
