namespace H_project1.Models.AccessData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int id { get; set; }

        [StringLength(50)]
        public string Fname { get; set; }

        [StringLength(100)]
        public string lname { get; set; }

        public string password { get; set; }

        [StringLength(20)]
        public string birthday { get; set; }

        [StringLength(20)]
        public string gender { get; set; }

        [StringLength(300)]
        public string Email { get; set; }

        [StringLength(15)]
        public string mobile { get; set; }

        [StringLength(50)]
        public string SignUpDate { get; set; }

        public bool? Smokes { get; set; }

        public string bodytype { get; set; }

        public string Diet { get; set; }

        public int? height { get; set; }

        [StringLength(50)]
        public string orientation { get; set; }

        public bool? pic { get; set; }

        [StringLength(300)]
        public string country { get; set; }

        [StringLength(300)]
        public string state { get; set; }

        [StringLength(300)]
        public string city { get; set; }

        [StringLength(500)]
        public string bio { get; set; }

        [StringLength(500)]
        public string BirthPlace { get; set; }

        public int? marriagestatus { get; set; }

        [StringLength(100)]
        public string occupation { get; set; }

        [StringLength(50)]
        public string religen { get; set; }

        public bool? Isfake { get; set; }
    }
}
