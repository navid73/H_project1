namespace H_project1.Models.AccessData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hoby
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_user { get; set; }

        public string Hobbies { get; set; }

        public string favorite_music { get; set; }

        public string favorite_tvshow { get; set; }

        public string favorite_book { get; set; }

        public string favorite_movie { get; set; }

        public string favorite_writers { get; set; }

        public string favorite_game { get; set; }
    }
}
