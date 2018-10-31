namespace H_project1.Models.AccessData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_user { get; set; }

        [StringLength(50)]
        public string Employee_Title { get; set; }

        public string Employee_place { get; set; }

        public string Describtion { get; set; }
    }
}
